using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class PlanViewPage : ContentPage
{
	public PlanViewPage(PlanViewViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}