using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportApp.Models;
using SportApp.Views;

namespace SportApp.Viewmodels
{
    public partial class PlanViewViewmodel : ObservableObject
    {
        [ObservableProperty]
        private Plan _plan;

        private readonly Page _trainPage;

        private readonly TrainPageViewmodel _trainPageViewmodel;

        public PlanViewViewmodel(TrainPage trainPage, TrainPageViewmodel trainPageViewmodel)
        {
            _trainPage = trainPage;
            _trainPageViewmodel = trainPageViewmodel;
        }

        [RelayCommand]
        private async Task StartTrain()
        {
            _trainPageViewmodel.Plan = Plan;
            _trainPageViewmodel.CurrentExerciseIndex = 0;
            await Shell.Current.Navigation.PushAsync(_trainPage);
            await _trainPageViewmodel.StartTimer();
        }
    }
}
