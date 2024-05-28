using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class TrainPage : ContentPage
{
	public TrainPage(TrainPageViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}