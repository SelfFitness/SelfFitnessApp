using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class CreatePlanPage : ContentPage
{
	public CreatePlanPage(CreatePlanViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}