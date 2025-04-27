using Microsoft.Extensions.DependencyInjection;
using OrangeParanoia.Services;
using OrangeParanoia.Services.Interfaces;

var services = new ServiceCollection()
    .AddSingleton<IArrayService, ArrayService>()
    .AddSingleton<IAnswerService, AnswerService>()
    .AddSingleton<ICardService, CardService>()
    .AddSingleton<IDateService, DateService>()
    .AddSingleton<INumberService, NumberService>()
    .AddSingleton<IProgressionService, ProgressionService>()
    .AddSingleton<IUtilityService, UtilityService>();

var provider = services.BuildServiceProvider();

var answerSvc = provider.GetRequiredService<IAnswerService>();

Console.WriteLine("Magic 8-Ball: " + answerSvc.GetMagic8BallAnswer());
