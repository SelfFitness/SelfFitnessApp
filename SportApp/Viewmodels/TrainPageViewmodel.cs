using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportApp.Abstractions;
using SportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Viewmodels
{
    public partial class TrainPageViewmodel : ObservableObject
    {
        const int TIMER_UPDATE = 100;

        [ObservableProperty]
        private Plan _plan;

        private int _currentExersiceIndex;

        public int CurrentExerciseIndex
        {
            get => _currentExersiceIndex;
            set
            {
                _currentExersiceIndex = value;
                OnPropertyChanged(nameof(CurrentExercise));
            }
        }

        public ExercisePart CurrentExercise
        {
            get
            {
                return _plan?.ExerciseParts[CurrentExerciseIndex];
            }
        }

        [ObservableProperty]
        private string _countText;

        private TimeSpan _remain;

        private Timer _timer;

        private readonly AnalyticsPageViewmodel _analyticsViewmodel;

        private readonly IClientApi _clientApi;

        public TrainPageViewmodel(AnalyticsPageViewmodel analyticsPageVm, IClientApi clientApi)
        {
            _analyticsViewmodel = analyticsPageVm;
            _clientApi = clientApi;
        }

        [RelayCommand]
        private async Task GoBack()
        {
            _timer?.Dispose();
            await Shell.Current.Navigation.PopToRootAsync();
        }

        public void StartTimer()
        {
            if (CurrentExercise.Count != null)
            {
                CountText = "x" + CurrentExercise.Count.ToString();
                return;
            }
            _remain = CurrentExercise.Duration.Value;
            _timer = new Timer(UpdateTime, null, 0, TIMER_UPDATE);
        }

        private void UpdateTime(object? state)
        {
            var substractTime = TimeSpan.FromMilliseconds(TIMER_UPDATE);
            if (_remain < substractTime)
            {
                _timer.Dispose();
            }
            _remain = _remain.Subtract(substractTime);
            CountText = _remain.ToString("mm\\:ss");
        }

        [RelayCommand]
        private async Task Next()
        {
            _timer?.Dispose();
            if (CurrentExerciseIndex == Plan.ExerciseParts.Count() - 1)
            {
                if (Plan.Id != null)
                    await _clientApi.SaveTrain(Plan.Id.GetValueOrDefault());
                await _analyticsViewmodel.UpdateTrainHistory();
                await Shell.Current.Navigation.PopToRootAsync();
                return;
            }
            CurrentExerciseIndex += 1;
            StartTimer();
        }
    }
}
