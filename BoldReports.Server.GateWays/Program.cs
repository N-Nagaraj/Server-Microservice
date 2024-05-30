using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot
builder.Services.AddOcelot(builder.Configuration);
builder.Configuration.AddJsonFile("ocelot.json",optional: false, reloadOnChange: true);

var app = builder.Build();
app.MapGet("/", () => "Ocelot API Gateway is running!");
app.UseOcelot().Wait();
app.RunAsync().Wait();
