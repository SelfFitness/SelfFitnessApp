using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewmodel pageViewmodel)
	{
		InitializeComponent();
		BindingContext = pageViewmodel;
	}
}