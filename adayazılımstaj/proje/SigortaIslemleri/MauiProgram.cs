using Microsoft.Extensions.Logging;
using SigortaIslemleri.ViewModel;

namespace SigortaIslemleri;

    public static class MauiProgram
    {
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });

    builder.Services.AddSingleton<MainPage>();
    builder.Services.AddSingleton<MainViewModel>();
    builder.Services.AddSingleton<PolicePage>();
    builder.Services.AddSingleton<PoliceViewModel>();
    builder.Services.AddSingleton<PoliceDetay>();
    builder.Services.AddSingleton<PoliceDetayViewModel>();
    builder.Services.AddSingleton<TeklifPage>();
    builder.Services.AddSingleton<TeklifViewModel>();

        return builder.Build();
}

    }
