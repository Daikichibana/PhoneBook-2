using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppPhone.Views;
using AppPhone.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppPhone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainViewModel.GetInstance().Login = new LoginViewModel();
            this.MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
