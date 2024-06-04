using CommunityToolkit.Maui;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using SportApp.Platforms.Android;
using SportApp.Viewmodels;
using SportApp.Views;


namespace SportApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp() 
            => MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .UseMicrocharts()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews()
                .RegisterFonts()
                .RegisterHandlers()
                .Build();

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            // More services registered here.

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {

            mauiAppBuilder.Services.AddSingleton<MainPageViewmodel>();
            mauiAppBuilder.Services.AddSingleton<LoginPageViewmodel>();
            mauiAppBuilder.Services.AddSingleton<WelcomePageViewmodel>();
            mauiAppBuilder.Services.AddSingleton<RegisterPageViewmodel>();
            mauiAppBuilder.Services.AddSingleton<PlansPageViewmodel>();
            mauiAppBuilder.Services.AddSingleton<AnalyticsPageViewmodel>();
            mauiAppBuilder.Services.AddSingleton<SettingsPageViewmodel>();
            mauiAppBuilder.Services.AddSingleton<PlanViewViewmodel>();
            mauiAppBuilder.Services.AddSingleton<TrainPageViewmodel>();
            mauiAppBuilder.Services.AddSingleton<CreatePlanViewmodel>();
            // More view-models registered here.

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainPage>();
            mauiAppBuilder.Services.AddSingleton<LoginPage>();
            mauiAppBuilder.Services.AddSingleton<RegisterPage>();
            mauiAppBuilder.Services.AddSingleton<WelcomePage>();
            mauiAppBuilder.Services.AddSingleton<LoadingPopup>();
            mauiAppBuilder.Services.AddSingleton<RegisterPage>();
            mauiAppBuilder.Services.AddSingleton<SettingsPage>();
            mauiAppBuilder.Services.AddSingleton<PlansPage>();
            mauiAppBuilder.Services.AddSingleton<AnalyticsPage>();
            mauiAppBuilder.Services.AddSingleton<PlanViewPage>();
            mauiAppBuilder.Services.AddSingleton<TrainPage>();
            mauiAppBuilder.Services.AddSingleton<CreatePlanPage>();
            // More views registered here.

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterFonts(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                fonts.AddFont("Montserrat-ExtraBold.ttf", "MontserratExtraBold");
                fonts.AddFont("Montserrat-Medium.ttf", "MontserratMedium");
                fonts.AddFont("HelveticaRoundedLTStd-Bd.ttf", "HelveticaRounded");
            });
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterHandlers(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.ConfigureMauiHandlers(handlers =>
             {
                 handlers.AddHandler(typeof(Entry), typeof(MyEntryHandler));
             });
            return mauiAppBuilder;
        }
    }
}
