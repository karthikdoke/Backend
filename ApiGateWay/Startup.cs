﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using System;
using CacheManager.Core;
using Ocelot.Middleware;

namespace ApiGateWay
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath)
                .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Action<ConfigurationBuilderCachePart> settings = (x) =>
            //{
            //    x.WithMicrosoftLogging(log =>
            //    {
            //        log.AddConsole(LogLevel.Debug);
            //    }).WithDictionaryHandle();
            //};
            services.AddOcelot(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            await app.UseOcelot();
        }
    }
}