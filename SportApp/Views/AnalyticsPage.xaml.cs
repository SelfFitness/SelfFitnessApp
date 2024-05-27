using SportApp.Viewmodels;

namespace SportApp.Views;

public partial class AnalyticsPage : ContentPage
{
	public AnalyticsPage(AnalyticsPageViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}