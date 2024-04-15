using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Viewmodels
{
    public partial class MainPageViewmodel : ObservableObject
    {
        public MainPageViewmodel()
        {
        }

        [RelayCommand]
        public async Task LoginPage()
        {
            await Shell.Current.GoToAsync("//login");
        }
    }
}
