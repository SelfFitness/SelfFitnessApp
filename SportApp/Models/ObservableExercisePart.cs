using CommunityToolkit.Mvvm.ComponentModel;
using SportApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Models
{
    public partial class ObservableExercisePart : ObservableObject
    {
        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        public Exercise _exercise;

        [ObservableProperty]
        private TimeSpan? _duration;

        [ObservableProperty]
        private int? _count;

        [ObservableProperty]
        private ExerciseType _exerciseType;
    }
}
