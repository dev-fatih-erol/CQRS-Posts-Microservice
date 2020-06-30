﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Posts.Application.Dtos;

namespace Posts.Application.Configurations
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(o =>
            {
                o.AllowNullCollections = true;
                o.AllowNullDestinationValues = true;
                o.AddProfile(new Mapping());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

            services.AddMediatR(typeof(ApplicationServiceExtensions).Assembly);

            return services;
        }
    }
}