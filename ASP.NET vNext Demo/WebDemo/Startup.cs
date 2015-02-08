using System;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Serialization;
using WebDemo.Models;

namespace WebDemo
{
    public class Startup
    {
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

            //app.Use((ctx, next) =>
            //{
            //    throw new DivideByZeroException();
            //});

            //app.Use((ctx, next) => ctx.Response.WriteAsync("<h1>Hello world.</h1>"));

            //app.UseWelcomePage();


            app.UseServices(svc =>
            {

                svc.AddSingleton<IBooksRepository>(_ => new BooksRepository());

                svc.AddMvc();
                svc.Configure<MvcOptions>(options =>
                {
                    var jsonOutputFormatter =
                        options.OutputFormatters.First(f => f.Instance is JsonOutputFormatter).Instance as
                            JsonOutputFormatter;
                    jsonOutputFormatter.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                });
            });

            app.UseMvc();
        }
    }
}