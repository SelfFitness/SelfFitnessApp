using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewmodel pageViewmodel)
	{
		InitializeComponent();
		BindingContext = pageViewmodel;
	}
}