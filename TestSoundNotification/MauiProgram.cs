using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;

namespace TestSoundNotification
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalNotification(config =>
                {
                    config.AddCategory(new NotificationCategory(NotificationCategoryType.Status)
                    {
                        ActionList = new HashSet<NotificationAction>(new List<NotificationAction>()
                                    {
                                        new NotificationAction(1337)
                                        {
                                            Title = "MUTE",
                                            Android = { LaunchAppWhenTapped = true }
                                        }
                                        /*
                                            ,
                                            new NotificationAction(666)
                                            {
                                                Title = "CLOSE",
                                                Android = { LaunchAppWhenTapped = false }
                                            }
                                        */
                                    })
                    })
                    .AddAndroid(android =>
                    {
                        // Must uninstall / reinstall the app for changes to be taken into account :

                        // Handling like this always plays the first one (here : legit_01)
                        android.AddChannel(new NotificationChannelRequest { Sound = "legit_01" });
                        android.AddChannel(new NotificationChannelRequest { Sound = "legit_02" });

                        // Handling like this always plays the first one (here : legit_02)
                        //android.AddChannel(new NotificationChannelRequest { Sound = "legit_02" });
                        //android.AddChannel(new NotificationChannelRequest { Sound = "legit_01" });

                        /* Using Id / Name / Description / Sound does not work : default Android Sound is playing
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_01", Name="legit_01", Description="legit_01", Sound = "legit_01" });
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_02", Name="legit_02", Description="legit_02", Sound = "legit_02" });
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_03", Name="legit_03", Description="legit_03", Sound = "legit_03" });
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_04", Name="legit_04", Description="legit_04", Sound = "legit_04" });
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_05", Name="legit_05", Description="legit_05", Sound = "legit_05" });
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_06", Name="legit_06", Description="legit_06", Sound = "legit_06" });
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_07", Name="legit_07", Description="legit_07", Sound = "legit_07" });
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_08", Name="legit_08", Description="legit_08", Sound = "legit_08" });
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_09", Name="legit_09", Description="legit_09", Sound = "legit_09" });
                        android.AddChannel(new NotificationChannelRequest { Id=$"legit_10", Name="legit_10", Description="legit_10", Sound = "legit_10" });
                        */

                    });
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}