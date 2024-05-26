using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage(WelcomePageViewmodel pageViewmodel)
	{
		InitializeComponent();
		BindingContext = pageViewmodel;
	}
}