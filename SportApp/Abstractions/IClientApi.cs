using SportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Abstractions
{
    public interface IClientApi
    {
        bool IsAuthentificated { get; }

        Task<string> Register(string email, string password);

        Task<string> Login(string email, string password);

        Task<IEnumerable<PlanGroup>> GetPlans();

        Task SetParams(double? weigth, double? heigth);

        Task<IEnumerable<WeigthHistory>> GetWeigthHistory();

        Task<IEnumerable<TrainHistory>> GetTrainHistory();

        Task<UserStats> GetUserStats();

        Task<IEnumerable<ExercisePart>> GetExercises();

        Task SaveTrain(int planId);

        bool Check(string token);
    }
}
