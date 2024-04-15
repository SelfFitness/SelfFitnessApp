using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewmodel();
	}
}