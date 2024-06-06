using CommunityToolkit.Maui.Views;
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
    public partial class RegisterPageViewmodel : ObservableObject
    {
        private readonly Page _mainPage;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _errorMessage;

        private readonly IClientApi _clientApi;

        public RegisterPageViewmodel(MainPage mainPage, IClientApi clientApi) 
        {
            _mainPage = mainPage;
            _clientApi = clientApi;
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
            try
            {
                var token = await _clientApi.Register(Email, Password);
                await Shell.Current.GoToAsync("//tabs");
            }
            catch(Exception ex)
            {
                ErrorMessage = "Не удалось выполнить запрос";
            }
            await cts.CancelAsync();
        }
    }
}
