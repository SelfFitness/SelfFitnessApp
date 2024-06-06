#if ANDROID
using Android.App;
#endif
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportApp.Abstractions;
using SportApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Viewmodels
{
    public partial class LoginPageViewmodel : ObservableObject
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private bool _isInvlalidCredentials;

        private readonly IClientApi _clientApi;

        public LoginPageViewmodel(IClientApi clientApi)
        {
            _clientApi = clientApi;
        }

        [RelayCommand]
        private async Task Login(Page currentPage)
        {
            var cts = new CancellationTokenSource();
            var loadingPopup = new LoadingPopup();
            var checkCredentialsTask = CheckCredentials(cts);
            var animationTask = currentPage.ShowPopupAsync(loadingPopup, cts.Token).ContinueWith(async obj =>
            {
                await loadingPopup.CloseAsync();
            });
            await Task.WhenAll(checkCredentialsTask, animationTask);
        }

        private async Task CheckCredentials(CancellationTokenSource cts)
        {
            try
            {
                var token = await _clientApi.Login(Email, Password);
                await Shell.Current.GoToAsync("//tabs");
            }
            catch
            {
                IsInvlalidCredentials = true;
            }
            await cts.CancelAsync();
        }
    }
}
