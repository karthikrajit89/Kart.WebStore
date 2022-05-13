using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Kart.WebStore.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((context, builder) => {

    //var region = Environment.GetEnvironmentVariable("REGION");


builder.AddJsonFile("appsettings.dev.json",optional:false, reloadOnChange: true);
    builder.AddSystemsManager("/kart/webstoreparams",TimeSpan.FromHours(1) );
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var assembly = Assembly.GetExecutingAssembly();
var applicationName = assembly.GetName().Name;
var applicationVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
builder.Services.ConfigureSwaggerGen("Kart Web Store Api", applicationName, applicationVersion);
//buid

Environment.SetEnvironmentVariable("AppEnvironment", builder.Configuration["AppEnvironment"]);
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddCommon(builder.Configuration);
builder.Services.AddKartWebStoreServices();
builder.Services.AddSingleton(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
 
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowOrigin");

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});

app.ConfigureSwagger(applicationName);
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();