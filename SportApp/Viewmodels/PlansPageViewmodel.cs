using CommunityToolkit.Mvvm.ComponentModel;
using SportApp.Models;
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

        public PlansPageViewmodel()
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
        }
    }
}
