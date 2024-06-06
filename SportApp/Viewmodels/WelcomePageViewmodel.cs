#if ANDROID
using AndroidX.Navigation;
#endif
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportApp.Abstractions;
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

        private readonly Page _registerPage;

        public WelcomePageViewmodel(LoginPage loginPage, RegisterPage registerPage, IClientApi clientApi) 
        {
            _loginPage = loginPage;
            _registerPage = registerPage;
            if (clientApi.IsAuthentificated)
            {
                GoToMainPage();
            }
        }

        private async Task GoToMainPage()
        {
            await Shell.Current.GoToAsync("//tabs");
        }

        [RelayCommand]
        public async Task GoToLoginPage()
        {
            await Shell.Current.Navigation.PushAsync(_loginPage);
        }

        [RelayCommand]
        public async Task GoToRegisterPage()
        {
            await Shell.Current.Navigation.PushAsync(_registerPage);
        }
    }
}
