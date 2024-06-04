using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SportApp.Models;
using SportApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Viewmodels
{
    public partial class PlansPageViewmodel : ObservableObject
    {
        public ObservableCollection<PlanGroup> PlanGroups { get; set; }

        [ObservableProperty]
        private Plan _selectedPlan;

        private readonly PlanViewViewmodel _planViewViewmodel;

        private readonly Page _planViewPage;

        private readonly Page _createPlanPage;

        public PlansPageViewmodel(PlanViewPage planView, 
            PlanViewViewmodel planViewViewmodel,
            CreatePlanPage createPlanPage)
        {
            _planViewViewmodel = planViewViewmodel;
            _planViewPage = planView;
            _createPlanPage = createPlanPage;
            PlanGroups =
            [
                new PlanGroup() 
                {
                    Name = "Новичок",
                    Plans =
                    [
                        new Plan()
                        {
                            Title = "Новичок - 1",
                            Description = "Этот план разработан специально для тех, кто только начинает заниматься фитнесом. Он поможет вам укрепить основные группы мышц, улучшить выносливость и гибкость",
                            Exercises =
                                [
                                    new ExercisePart()
                                    {
                                        Count = 12,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Приседания",
                                            Description = "Встаньте прямо, ноги на ширине плеч, руки вытянуты перед собой или согнуты в локтях. Медленно опуститесь вниз, сгибая колени, пока бедра не станут параллельны полу или немного ниже. \r\nКолени должны быть направлены туда же, куда направлены и носки. Затем медленно вернитесь в исходное положение, выпрямляя ноги.\r\nОсновная нагрузка идет на мышцы передней и задней поверхности бедра, ягодичные и мышцы кора.",
                                            Url = "https://i.imgur.com/mMGEWxc.mp4"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Count = 10,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Отжимания от пола",
                                            Description = "Кисти чуть шире плеч. Опуститесь вниз сгибая локти, при этом тело держите прямо. Затем вернитесь в исходное положение, выпрямляя руки.\r\nОсновная нагрузка идет на грудные мышцы, плечи, трицепсы, спину и ноги.",
                                            Url = "https://i.imgur.com/2W403Dp.mp4"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Duration = TimeSpan.FromSeconds(30),
                                        Exercise = new Exercise()
                                        {
                                            Title = "Планка",
                                            Description = "Встаньте в положение отжиманий от пола, но вместо этого опустите локти на пол, чтобы ваше тело было поддерживаемо на предплечьях и носках ног. Держите спину прямо, не давая телу провиснуть или поднять бедра.\r\nОсновная нагрузка идет на мышцы живота, спины и плеч.",
                                            Url = "https://i.imgur.com/Esp188d.mp4"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Count = 9,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Пресс",
                                            Description = "Лягте на спину, согните колени и прижмите стопы к полу. Приподнимайте корпус, задержитесь в верхнем положении, затем медленно опуститесь обратно на пол.\r\nОсновная нагрузка идет на прямую и косые мышцы живота.",
                                            Url = "https://i.imgur.com/187QHlw.mp4"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Count = 9,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Скручивания с поворотом",
                                            Description = "Лягте на спину, колени согнуты, стопы на полу, руки за головой. Поднимите плечи и верхнюю часть спины от пола так, чтобы коснуться правым локтем левого колена, а затем наоборот. \r\nОсновная нагрузка идет на прямую и косые мышцы живота.",
                                            Url = "https://i.imgur.com/80PHJd0.mp4"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Count = 15,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Подъемы на носки",
                                            Description = "Встаньте прямо, поднимите пятки, вставая на носки, затем медленно опуститесь обратно. Руки можно опереть о поверхность.\r\nОсновная нагрузка идет на икроножные мышцы.",
                                            Url = "https://i.imgur.com/5QcEMkQ.mp4"
                                        },
                                    }
                                ],
                            Difficulty = 1,
                            MaxDifficulty = 3,
                        },
                        new Plan()
                        {
                            Title = "Новичок - 2",
                            Description = "Данный план поможет вам прокачать мышцы руки и пальцев для хорошего тонуса и служения в армии",
                            Exercises = [],
                            Difficulty = 2,
                            MaxDifficulty = 3,
                        },
                        new Plan()
                        {
                            Title = "Новичок - 3",
                            Description = "Данный план поможет вам прокачать мышцы руки и пальцев для хорошего тонуса и служения в армии",
                            Exercises = [],
                            Difficulty = 3,
                            MaxDifficulty = 3,
                        }
                    ]
                },
                new PlanGroup()
                {
                    Name = "Продвинутый",
                    Plans =
                    [
                        new Plan()
                        {
                            Title = "Продвинутый - 1",
                            Description = "Данный план поможет вам прокачать мышцы руки и пальцев для хорошего тонуса и служения в армии",
                            Exercises = [],
                            Difficulty = 1,
                            MaxDifficulty = 3,
                        },
                        new Plan()
                        {
                            Title = "Продвинутый - 2",
                            Description = "Данный план поможет вам прокачать мышцы руки и пальцев для хорошего тонуса и служения в армии",
                            Exercises = [],
                            Difficulty = 2,
                            MaxDifficulty = 3,
                        },
                        new Plan()
                        {
                            Title = "Продвинутый - 3",
                            Description = "Данный план поможет вам прокачать мышцы руки и пальцев для хорошего тонуса и служения в армии",
                            Exercises = [],
                            Difficulty = 3,
                            MaxDifficulty = 3,
                        }
                    ]
                }
            ];
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
