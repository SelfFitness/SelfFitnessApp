using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportApp.Models;

namespace SportApp.Viewmodels
{
    public partial class PlanViewViewmodel : ObservableObject
    {
        [ObservableProperty]
        private Plan _plan;

        public PlanViewViewmodel()
        {
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
