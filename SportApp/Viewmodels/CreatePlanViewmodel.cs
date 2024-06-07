using Android.Content.Res;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportApp.Abstractions;
using SportApp.Helpers;
using SportApp.Models;
using SportApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SportApp.Viewmodels
{
    public partial class CreatePlanViewmodel : ObservableObject
    {
        const string customPlansKey = "customPlans";

        public ObservableCollection<ObservableExercisePart> ExerciseParts { get; set; }

        private readonly IClientApi _clientApi;

        private readonly IServiceProvider _services;

        public CreatePlanViewmodel(IClientApi clientApi, IServiceProvider services)
        {
            _clientApi = clientApi;
            _services = services;
            ExerciseParts = new ObservableCollection<ObservableExercisePart>();
            Task.Run(LoadExercices);
        }

        public async Task LoadExercices()
        {
            var exercices = await _clientApi.GetExercises();
            ExerciseParts.Clear();
            foreach (var exercise in exercices)
            {
                ExerciseParts.Add(exercise.ToObservable());
            }
        }

        [RelayCommand]
        private async Task CreatePlan()
        {
            var title = await Shell.Current.CurrentPage.DisplayPromptAsync("Создание плана", "Введите название плана");
            var description = await Shell.Current.CurrentPage.DisplayPromptAsync("Создание плана", "Введите заметку к плану");
            var exercices = ExerciseParts.Where(x => x.Count != null || x.Duration != null)
                .Select(x => x.ToExercisePart())
                .ToList();
            if (string.IsNullOrEmpty(title) || 
                !exercices.Any())
                return;
            PlanGroup customPlans = null;
            if (Preferences.ContainsKey(customPlansKey))
            {
                var rawCustomPlans = Preferences.Get(customPlansKey, null);
                customPlans = JsonSerializer.Deserialize<PlanGroup>(rawCustomPlans);
            }
            else
            {
                customPlans = new PlanGroup()
                {
                    Name = "Мои планы",
                    Plans = new List<Plan>()
                };
            }
            customPlans.Plans.Add(new Plan()
            {
                Id = null,
                Description = description,
                Difficulty = 0,
                MaxDifficulty = 0,
                Title = title,
                ExerciseParts = exercices,
            });
            var jsonCustomPlans = JsonSerializer.Serialize(customPlans);
            Preferences.Set(customPlansKey, jsonCustomPlans);
            var plansPageVm = _services.GetService<PlansPageViewmodel>();
            await plansPageVm.UpdatePlans();
            await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
