using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
                try
                {
                    _currentExersiceIndex = value;
                    OnPropertyChanged(nameof(CurrentExercise));
                } 
                catch
                {

                }
            }
        }

        public ExercisePart CurrentExercise
        {
            get
            {
                try
                {
                    return _plan?.Exercises[CurrentExerciseIndex];
                }
                catch
                {
                    return null;
                }
            }
        }

        [ObservableProperty]
        private string _countText;

        private TimeSpan _remain;

        private Timer _timer;

        public TrainPageViewmodel() 
        {
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }

        public async Task StartTimer()
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
            if (CurrentExerciseIndex == Plan.Exercises.Count() - 1)
            {
                await Shell.Current.Navigation.PopToRootAsync();
            }
            CurrentExerciseIndex += 1;
            await StartTimer();
        }
    }
}
