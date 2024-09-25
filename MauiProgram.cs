using Microsoft.Extensions.Logging;
using Module0Exercise0.Services;
using Module0Exercise0.View;

namespace Module0Exercise0
{
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

#if DEBUG
            //SERVICES
            builder.Services.AddSingleton<IMyService, MyService>();
            //CONTENT PAGE
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<OfflinePage>();

            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
