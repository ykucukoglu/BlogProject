﻿using Blog.Service.FluentValidations;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
          {
              opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
              opt.DisableDataAnnotationsValidation = true;
              opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
          });


            return services;
        }
    }
}
