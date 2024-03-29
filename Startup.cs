﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testLoginet.Controllers;
using testLoginet.Dao;
using testLoginet.Helpers;
using testLoginet.Interfaces;
using testLoginet.Models;
using testLoginet.Models.Interfaces;
using testLoginet.Options;
using testLoginet.Services;

namespace testLoginet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Настройки httpClient
            var httpClientConfig = Configuration.GetSection("HttpClientOptions").Get<HttpClientOptions>();
            
            // Добавляем и настраиваем httpClient для получения json данных в dao
            services.AddHttpClient("httpClient", c =>
            {
                c.BaseAddress = httpClientConfig.BaseAddress;
                c.DefaultRequestHeaders.Accept.TryParseAdd(httpClientConfig.Accept);
                c.DefaultRequestHeaders.AcceptEncoding.TryParseAdd( httpClientConfig.AcceptEncoding);
                c.DefaultRequestHeaders.Connection.TryParseAdd(httpClientConfig.Connection);
                c.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true,
                    NoStore = true,
                    MaxAge = new TimeSpan(0),
                    MustRevalidate = true
                };
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AllowAutoRedirect = false,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            });


            // DI для dao альбомов
            services.AddScoped<IAlbumsDao, AlbumsDao>();
            // DI для dao пользователей
            services.AddScoped<IUsersDao, UsersDao>();
            // DI для сервиса пользователей
            services.AddScoped<IUsersService, UsersService>();
            // DI для шифрования email
            services.AddScoped<IEncryptor, AesEncryptor>();
            // DI для сервиса альбомов
            services.AddScoped<IAlbumsService, AlbumsService>();

            // Для отправки ответа в xml формате
            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
