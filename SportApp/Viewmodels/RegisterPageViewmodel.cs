using CommunityToolkit.Maui.Views;
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
    public partial class RegisterPageViewmodel : ObservableObject
    {
        private readonly Page _mainPage;

        private bool _isChecked;

        private string _email;

        private string _password;

        [ObservableProperty]
        private string _errorMessage;

        public RegisterPageViewmodel(MainPage mainPage) 
        {
            _mainPage = mainPage;
        }

        [RelayCommand]
        private async Task Register(Page currentPage)
        {
            var cts = new CancellationTokenSource();
            var loadingPopup = new LoadingPopup();
            var checkCredentialsTask = Register(cts);
            var animationTask = currentPage.ShowPopupAsync(loadingPopup, cts.Token).ContinueWith(async obj =>
            {
                await loadingPopup.CloseAsync();
            });
            await Task.WhenAll(checkCredentialsTask, animationTask);
        }

        private async Task Register(CancellationTokenSource cts)
        {
            await Task.Delay(1500);
            if (!_isChecked)
            {
                _isChecked = true;
                ErrorMessage = "Неверно введены данные о почте";
                await cts.CancelAsync();
                return;
            }
            await Shell.Current.Navigation.PushAsync(_mainPage);
            await cts.CancelAsync();
        }
    }
}
