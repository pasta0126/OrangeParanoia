using OrangeParanoia.Api.Endpoints;
using OrangeParanoia.Services.Interfaces;
using OrangeParanoia.Services;


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
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<INumberService, NumberService>();
builder.Services.AddScoped<IDateService, DateService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

// Endpoints
app.MapNumberEndpoints();
app.MapDateEndpoints();
app.MapUtilityEndpoints();

app.Run();
