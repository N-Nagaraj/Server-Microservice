using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace BoldReports.Server.DIResolvers.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        //public static IApplicationBuilder UseApiApplicationBuilder(this IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        //{
        //    if (webHostEnvironment.IsDevelopment())
        //    {
        //        app.UseSwagger();
        //        app.UseSwaggerUI();
        //    }
        //    app.UsePathBase("reporting");
        //    app.Use(async (context, next) =>
        //    {
        //        var segments = context.Request.Path.Value.Split('/', StringSplitOptions.RemoveEmptyEntries);

        //        await next();
        //    });

        //    app.UseRouting();
        //    app.UseHttpsRedirection();
        //    app.UseAuthorization();
        //    app.Run();

        //    return app;
        //}
    }
}
