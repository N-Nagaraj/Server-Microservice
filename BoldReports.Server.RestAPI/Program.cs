using Microsoft.AspNetCore.Mvc;

using BoldReports.Server.Base.Models;
using BoldReports.Server.DIResolvers;
using BoldReports.Server.DIResolvers.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddControllers(o =>
{
    o.UseGeneralRoutePrefix(new RouteAttribute($"{builder.Configuration["AppSettings:TenantIdentifierPrefix"]}/" + "{tenantName}"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMultitenantServices();
builder.Services.AddServiceProjects();

var app = builder.Build();

app.UsePathBase("/api");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
