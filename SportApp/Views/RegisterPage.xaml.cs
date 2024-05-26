using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}