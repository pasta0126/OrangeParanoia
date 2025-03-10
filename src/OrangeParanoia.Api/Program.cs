using OrangeParanoia.Api.Endpoints;
using OrangeParanoia.Services.Interfaces;
using OrangeParanoia.Services;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "v1";

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Orange Paranoia API",
        Version = version,
        Description = "Orange Paranoia is a versatile API for generating random values and data models.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "pasta0126",
            Email = "pasta0126@gmail.com"
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "The Unlicense",
            Url = new Uri("https://unlicense.org/")
        }
    });
});

// Services
builder.Services.AddScoped<INumberService, NumberService>();
builder.Services.AddScoped<IDateService, DateService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();
builder.Services.AddScoped<IProgressionService, ProgressionService>();
builder.Services.AddScoped<IArrayService, ArrayService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DocumentTitle = "Orange Paranoia";
    options.RoutePrefix = string.Empty;
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Orange Paranoia API v1");
});
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors();

// Endpoints
app.MapNumberEndpoints();
app.MapDateEndpoints();
app.MapUtilityEndpoints();
app.MapProgressionEndpoints();
app.MapArrayEndpoints();

app.Run();
