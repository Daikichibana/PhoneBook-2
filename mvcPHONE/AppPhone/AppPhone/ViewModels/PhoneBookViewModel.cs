namespace AppPhone.ViewModels
{
    using AppPhone.Models;
    using AppPhone.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class PhoneBookViewModel:BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Phone> phones;
        private bool isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<Phone> Phones
        {
            get { return this.phones; }
            set { SetValue(ref this.phones, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion

        #region Constructor
        public PhoneBookViewModel()
        {
            this.apiService = new ApiService();
            this.Loadphones();
        }
        #endregion

        #region Methods
        private async void Loadphones()
        {
            this.IsRefreshing = true;
            var connection =  await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                  "Internet Error Connection",  
                  connection.Message,           
                  "Accept"                      
                  );
                return;
            }
            
            var response = await apiService.GetListAsync<Phone>(
                "http://localhost:50553/",  //base
                "/api",                     //prefijo
                "/Phones"                    //controlador
                );

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Phone Service Error",
                    response.Message,
                    "Accept"
                    );
                return;
            }
            MainViewModel main = MainViewModel.GetInstance();
            main.ListPhone = (List<Phone>) response.Result;
            this.phones = new ObservableCollection<Phone>(ToPhoneCollect());
            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(Loadphones);
            }
        }

        private IEnumerable<Phone> ToPhoneCollect()
        {
            ObservableCollection<Phone> collection = new ObservableCollection<Phone>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach (var lista in main.ListPhone)
            {
                Phone phone = new Phone();
                phone.ContactID = lista.ContactID;
                phone.Name = lista.Name;
                phone.Type = lista.Type;
                phone.ContactValue = lista.ContactValue;
                collection.Add(phone);
            }

            return (collection);
        }
        
        #endregion
    }
}