#if ANDROID
using Android.App;
#endif
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private bool _isInvlalidCredentials;

        private bool _isChecked;

        private readonly Page _mainPage;

        public LoginPageViewmodel(MainPage mainPage)
        {
            _isChecked = false;
            _mainPage = mainPage;
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
            await Task.Delay(1500);
            if (!_isChecked)
            {
                _isChecked = true;
                IsInvlalidCredentials = true;
                await cts.CancelAsync();
                return;
            }
            await Shell.Current.Navigation.PushAsync(_mainPage);
            await cts.CancelAsync();
        }
    }
}
