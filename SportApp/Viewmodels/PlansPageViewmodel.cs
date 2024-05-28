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
        private readonly IServiceProvider _serviceProvider;

        public ObservableCollection<PlanGroup> PlanGroups { get; set; }

        private Plan _selectedItem;

        public Plan SelectedPlan 
        {
            get => _selectedItem;
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedPlan));
                    ShowPlan(SelectedPlan);
                }
            }
        }

        public PlansPageViewmodel(IServiceProvider serviceProvider)
        {
            PlanGroups =
            [
                new PlanGroup() 
                {
                    Name = "Новичек",
                    Plans =
                    [
                        new Plan()
                        {
                            Title = "Новичек - 1",
                            Description = "Данный план поможет вам скинуть вес бла бла бла бла бла бла бла бла бла бла бла бла бла бла",
                            Exercises =
                                [
                                    new ExercisePart()
                                    {
                                        Duration = TimeSpan.FromMinutes(1),
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Count = 5,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Duration = TimeSpan.FromMinutes(1),
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Count = 5,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Duration = TimeSpan.FromMinutes(1),
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Count = 5,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Duration = TimeSpan.FromMinutes(1),
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Count = 5,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Duration = TimeSpan.FromMinutes(1),
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                    new ExercisePart()
                                    {
                                        Count = 5,
                                        Exercise = new Exercise()
                                        {
                                            Title = "Анжумания от пола",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    },
                                ],
                            Difficulty = 1,
                            MaxDifficulty = 3,
                        },
                        new Plan()
                        {
                            Title = "Новичек - 2",
                            Description = "Description test",
                            Exercises =
                                [
                                    new ExercisePart()
                                    {
                                        Duration = TimeSpan.FromMinutes(1),
                                        Exercise = new Exercise()
                                        {
                                            Title = "test exercise",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    }
                                ],
                            Difficulty = 2,
                            MaxDifficulty = 3,
                        },
                        new Plan()
                        {
                            Title = "Новичек - 3",
                            Description = "Description test",
                            Exercises =
                                [
                                    new ExercisePart()
                                    {
                                        Duration = TimeSpan.FromMinutes(1),
                                        Exercise = new Exercise()
                                        {
                                            Title = "test exercise",
                                            Description = "this is test description",
                                            Url = "https://i.ytimg.com/vi/AGz3NnWPFd4/maxresdefault.jpg"
                                        },
                                    }
                                ],
                            Difficulty = 3,
                            MaxDifficulty = 3,
                        },
                    ]
                }
            ];
            _serviceProvider = serviceProvider;
        }

        private async void ShowPlan(Plan plan)
        {
            var planView = _serviceProvider.GetService<PlanViewPage>();
            var context = planView.BindingContext as PlanViewViewmodel;
            context.Plan = plan;
            await Shell.Current.Navigation.PushAsync(planView);
        }
    }
}
