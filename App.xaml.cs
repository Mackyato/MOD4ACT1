using Microsoft.Maui.Controls;
using Module0Exercise0.View;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Maui.ApplicationModel;
using System.Diagnostics;

namespace Module0Exercise0
{
    public partial class App : Application
    {
        private const string TestUrl = "https://www.google.com";

        private readonly IServiceProvider _serviceProvider;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage()); // Initialize MainPage as NavigationPage
            _serviceProvider = serviceProvider;

            MainPage = new AppShell();
            //MainPage = new NavigationPage(new AddEmployee());
        }

        protected override async void OnStart()
        {
            var current = Connectivity.NetworkAccess;
            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                MainPage = _serviceProvider.GetRequiredService<LoginPage>();
                Debug.WriteLine("Application Started (Online)");
            }
            else
            {
                MainPage = _serviceProvider.GetRequiredService<OfflinePage>();
                Debug.WriteLine("Application Started (Offline)");
            }
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
