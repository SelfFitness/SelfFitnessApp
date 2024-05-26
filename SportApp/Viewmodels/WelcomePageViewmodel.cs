#if ANDROID
using AndroidX.Navigation;
#endif
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Viewmodels
{
    public partial class WelcomePageViewmodel : ObservableObject
    {
        private readonly Page _loginPage;

        public WelcomePageViewmodel(LoginPage loginPage) 
        {
            _loginPage = loginPage;
        }

        [RelayCommand]
        public async Task GoToLoginPage()
        {
            await Shell.Current.Navigation.PushAsync(_loginPage);
        }
    }
}
