using System;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Serialization;
using WebDemo.Formatters;
using WebDemo.Models;

namespace WebDemo
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940


            //app.Use(async (ctx, next) =>
            //{
            //    try
            //    {
            //        await next();

            //    }
            //    catch (Exception ex)
            //    {
            //        ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //        await ctx.Response.WriteAsync("Oops: " + ex.Message);
            //    }
            //});
            app.UseErrorPage();

            //app.Use((ctx, next) => { throw new DivideByZeroException(); });

            //app.Use((ctx, next) => ctx.Response.WriteAsync("<h1>Hello world.</h1>"));

            //app.UseWelcomePage();


            app.UseServices(svc =>
            {
                svc.AddSingleton<IBooksRepository, BooksRepository>()
                    .AddMvc()
                    .Configure<MvcOptions>(options =>
                    {
                        var jsonOutputFormatter =
                            (JsonOutputFormatter)options.OutputFormatters.First(f => f.Instance is JsonOutputFormatter).Instance;
                        jsonOutputFormatter.SerializerSettings.ContractResolver =
                            new CamelCasePropertyNamesContractResolver();

                        var jpegMediaTypeOutputFormatter =
                            new JpegMediaTypeOutputFormatter(Path.Combine(_hostingEnvironment.WebRoot, @"..\Images"));
                        options.OutputFormatters.Add(jpegMediaTypeOutputFormatter);
                    });
            });

            app.UseMvc();
        }
    }
}