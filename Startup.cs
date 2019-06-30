using System;
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
            // Добавляем и настраиваем httpClient для получения json данных в users dao
            services.AddHttpClient<IUsersDao, UsersDao>("_httpClient", c =>
            {
                c.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.AcceptEncoding.TryParseAdd("gzip");
                c.DefaultRequestHeaders.AcceptEncoding.TryParseAdd("deflate");
                c.DefaultRequestHeaders.AcceptEncoding.TryParseAdd("br");
                c.DefaultRequestHeaders.Connection.TryParseAdd("keep-alive");
                c.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
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

            // Добавляем и настраиваем httpClient для получения json данных в albums dao
            services.AddHttpClient<IAlbumsDao, AlbumsDao>("_httpClient", c =>
            {
                c.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.AcceptEncoding.TryParseAdd("gzip");
                c.DefaultRequestHeaders.AcceptEncoding.TryParseAdd("deflate");
                c.DefaultRequestHeaders.AcceptEncoding.TryParseAdd("br");
                c.DefaultRequestHeaders.Connection.TryParseAdd("keep-alive");
                c.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
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

            // DI для сервиса пользователей
            services.AddSingleton<IUsersService, UsersService>();
            // DI для шифрования email
            services.AddSingleton<IEncryptor, AesEncryptor>();
            // DI для сервиса альбомов
            services.AddSingleton<IAlbumsService, AlbumsService>();

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
