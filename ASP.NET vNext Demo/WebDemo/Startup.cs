using System;
using System.Net;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

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

        }
    }
}