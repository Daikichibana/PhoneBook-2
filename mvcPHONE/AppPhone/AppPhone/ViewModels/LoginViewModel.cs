using AppPhone.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppPhone.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);
        public LoginViewModel()
        {
            this.Email = "chibanadaiki99@gmail.com";
            this.Password = "1234";
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Tienes que escribir un Email.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Tienes que escribir un Password.",
                    "Aceptar");
                return;
            }

            if(!this.Email.Equals("chibanadaiki99@gmail.com") || !this.Password.Equals("1234"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Password o Usuario mal.",
                    "Aceptar");
                return;
            }

            MainViewModel.GetInstance().phoneBookViewModel = new PhoneBookViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PhoneBookPage());
        }
    }
}
