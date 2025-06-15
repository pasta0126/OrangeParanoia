using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OrangeParanoia.Services;
using OrangeParanoia.Services.Interfaces;
using OrangeParanoia.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<INumberService, NumberService>();
builder.Services.AddScoped<IDateService, DateService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();
builder.Services.AddScoped<IProgressionService, ProgressionService>();
builder.Services.AddScoped<IArrayService, ArrayService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IStarWarsService, StarWarsService>();

await builder.Build().RunAsync();
