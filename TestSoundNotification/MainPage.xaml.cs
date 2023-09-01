using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;

namespace TestSoundNotification
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
        }

        // Actions when a notification action button is tapped
        private async void Current_NotificationActionTapped(NotificationActionEventArgs e)
        {
            switch (e.ActionId)
            {
                case 1337:
                    await DisplayAlert(e.Request.Title, $"DO STUFF", "OK");
                    break;
            }
        }


        private void OnCounterClicked(object sender, EventArgs e)
        {
            // Create the request itself
            var request = new NotificationRequest
            {
                NotificationId = 1337133,
                Title = $"TITLE",
                Subtitle = "", // Appear on the right side of the title (optionnal)
                Description = "DESC",
                CategoryType = NotificationCategoryType.Status,
                Sound = DeviceInfo.Platform == DevicePlatform.Android ? "legit_01" : "legit_01.mp3",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }

        private void CounterBtn2_Clicked(object sender, EventArgs e)
        {
            // Create the request itself
            var request = new NotificationRequest
            {
                NotificationId = 1337133,
                Title = $"TITLE",
                Subtitle = "", // Appear on the right side of the title (optionnal)
                Description = "DESC",
                CategoryType = NotificationCategoryType.Status,
                Sound = DeviceInfo.Platform == DevicePlatform.Android ? "legit_02" : "legit_02.mp3",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
    }
}