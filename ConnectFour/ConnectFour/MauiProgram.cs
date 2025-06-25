using Microsoft.Extensions.Logging;
using ConnectFour.Shared.Services;
using ConnectFour.Services;

namespace ConnectFour;

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
            });

        // Add device-specific services used by the ConnectFour.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddSingleton<GameState>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
