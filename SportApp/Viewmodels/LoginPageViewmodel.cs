using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Viewmodels
{
    public partial class LoginPageViewmodel : ObservableObject
    {
        public LoginPageViewmodel()
        {
        }

        [RelayCommand]
        public async Task MainPage()
        {
            await Shell.Current.GoToAsync("//main");
        }
    }
}
