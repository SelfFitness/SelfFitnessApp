using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class PlansPage : ContentPage
{
	public PlansPage(PlansPageViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}