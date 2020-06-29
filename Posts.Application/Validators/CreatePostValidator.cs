using System.Linq;
using FluentValidation;
using Posts.Application.Commands;

namespace Posts.Application.Validators
{
    public class CreatePostValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostValidator()
        {
            RuleFor(p => p.Text)
                .Length(1, 300)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.");

            RuleFor(p => p.User)
                .NotNull()
                .WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Photos)
                .Must(p => p != null && p.Any())
                .When(p => p.Videos == null || !p.Videos.Any())
                .WithMessage("No {PropertyName} found.");

            RuleFor(p => p.Videos)
                .Must(p => p != null && p.Any())
                .When(p => p.Photos == null || !p.Photos.Any())
                .WithMessage("No {PropertyName} found.");
        }
    }
}