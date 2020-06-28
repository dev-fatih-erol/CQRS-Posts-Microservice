using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Posts.Api.Filters;
using Posts.Application.Configurations;
using Posts.Application.Validators;
using Posts.Infrastructure;
using Posts.Infrastructure.Configurations;
using Posts.Infrastructure.Services;

namespace Posts.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoConfiguration>(Configuration.GetSection(nameof(MongoConfiguration)));

            services.AddSingleton<IMongoConfiguration>(o => o.GetRequiredService<IOptions<MongoConfiguration>>().Value);

            services.AddSingleton<PostDbContext>();

            services.AddTransient<IPostService, PostService>();

            services
                .AddApplication()
                .AddMediatR(typeof(ApplicationServiceExtensions).Assembly);

            services
                .AddControllers(o => o.Filters.Add(typeof(GlobalExceptionFilter)))
                .AddNewtonsoftJson(o => o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore)
                .AddFluentValidation(o => o.RegisterValidatorsFromAssemblyContaining<CreatePostValidator>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}