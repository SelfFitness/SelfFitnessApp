using Android.App;
using Android.Content;
using Android.OS;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Viewmodels
{
    public partial class SettingsPageViewmodel : ObservableObject
    {
        public SettingsPageViewmodel() { }

        [RelayCommand]
        private async Task Exit()
        {
            SecureStorage.Default.Remove("token");
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}
