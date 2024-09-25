using Microsoft.Maui.Controls;
using System;
using Module0Exercise0.View;
using Module0Exercise0.Services;

namespace Module0Exercise0.View
{
    public partial class LoginPage : ContentPage
    {
        private readonly IMyService _myService;
        public LoginPage(IMyService myService)
        {
            InitializeComponent();
            _myService = myService;

            var message = _myService.GetMessage();
            MyLabel.Text = message;
        }

         private async void OnLoginButtonClicked(object sender, EventArgs e)
         {
        
             string username = usernameEntry.Text;
             string password = passwordEntry.Text;
        
             
             if (username == "admin" && password == "admin")
             {
                 Application.Current.MainPage = new NavigationPage(new EmployeePage());
             }
         }
    }
}
