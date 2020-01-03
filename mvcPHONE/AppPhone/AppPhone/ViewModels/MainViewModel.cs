using AppPhone.Models;
using System.Collections.Generic;

namespace AppPhone.ViewModels
{
    public class MainViewModel
    {
        
        private static MainViewModel instance;

        #region Properties
        public string Token { get; set; }
        public string TokenType { get; set; }
        public List<Phone> ListPhone { get; set; }
        #endregion


        #region ViewModels
        public LoginViewModel Login { get; set; }

        public PhoneBookViewModel phoneBookViewModel { get; set; }
        
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
        }
        #endregion

        #region Singleton
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return (instance);
        }
        #endregion
    }
}
