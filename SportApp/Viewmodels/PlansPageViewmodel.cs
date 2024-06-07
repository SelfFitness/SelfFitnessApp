using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportApp.Abstractions;
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
    public partial class PlansPageViewmodel : ObservableObject
    {
        const string customPlansKey = "customPlans";

        [ObservableProperty]
        private ObservableCollection<PlanGroup> _planGroups;

        [ObservableProperty]
        private Plan _selectedPlan;

        private readonly PlanViewViewmodel _planViewViewmodel;

        private readonly Page _planViewPage;

        private readonly Page _createPlanPage;

        private readonly IClientApi _clientApi;

        public PlansPageViewmodel(PlanViewPage planView, 
            PlanViewViewmodel planViewViewmodel,
            CreatePlanPage createPlanPage,
            IClientApi clientApi)
        {
            _planViewViewmodel = planViewViewmodel;
            _planViewPage = planView;
            _createPlanPage = createPlanPage;
            _clientApi = clientApi;
            Task.Run(UpdatePlans);
        }

        public async Task UpdatePlans()
        {
            var planGroups = await _clientApi.GetPlans();
            PlanGroups = new ObservableCollection<PlanGroup>(planGroups);
            if (Preferences.ContainsKey(customPlansKey))
            {
                var rawCustomPlans = Preferences.Get(customPlansKey, null);
                var customPlans = JsonSerializer.Deserialize<PlanGroup>(rawCustomPlans);
                PlanGroups.Add(customPlans);
            }
        }

        [RelayCommand]
        private async Task ShowPlan()
        {
            _planViewViewmodel.Plan = SelectedPlan;
            await Shell.Current.Navigation.PushAsync(_planViewPage);
            SelectedPlan = null;
        }

        [RelayCommand]
        private async Task CreatePlan()
        {
            await Shell.Current.Navigation.PushAsync(_createPlanPage);
        }
    }
}
