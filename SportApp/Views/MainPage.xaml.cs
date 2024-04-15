using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewmodel();
	}
}