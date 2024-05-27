using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}