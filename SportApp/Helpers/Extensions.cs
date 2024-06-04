using SportApp.Models;
using SportApp.Models.Enums;

namespace SportApp.Helpers
{
    public static class Extensions
    {
        public static ObservableExercisePart ToObservable(this ExercisePart part)
        {
            return new ObservableExercisePart()
            {
                Id = part.Id,
                Exercise = part.Exercise,
                ExerciseType = part.Count == null ? ExerciseType.Time : ExerciseType.Count
            };
        }
    }
}
