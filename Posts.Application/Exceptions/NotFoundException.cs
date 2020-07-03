using System;
namespace Posts.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity)
            : base($"{entity} not found.")
        {
        }
    }
}