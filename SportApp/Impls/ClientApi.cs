using SportApp.Abstractions;
using SportApp.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SportApp.Impls
{
    public class ClientApi : IClientApi, IDisposable
    {
        const string BaseUrl = "https://7794-136-169-149-77.ngrok-free.app/api";

        private string Token { get; set; }

        private HttpClient _client;

        public bool IsAuthentificated => Token != null;

        public ClientApi(string token = null)
        {
            Token = token;
            _client = new HttpClient();
            if (token != null)
            {
                SetToken();
            }
        }

        private async void SetToken()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            await SecureStorage.Default.SetAsync("token", Token);
        }

        public async Task<string> Register(string email, string password)
        {
            var registerVm = new RegisterViewmodel()
            {
                Email = email,
                Password = password
            };
            var result = await _client.PostAsJsonAsync($"{BaseUrl}/userapi/register", registerVm);
            result.EnsureSuccessStatusCode();
            var token = await result.Content.ReadAsStringAsync();
            Token = token;
            SetToken();
            return token;
        }

        public async Task<string> Login(string email, string password)
        {
            var loginVm = new LoginViewmodel()
            {
                Email = email,
                Password = password
            };
            var result = await _client.PostAsJsonAsync($"{BaseUrl}/userapi/login", loginVm);
            result.EnsureSuccessStatusCode();
            var token = await result.Content.ReadAsStringAsync();
            Token = token;
            SetToken();
            return token;
        }

        public async Task<IEnumerable<PlanGroup>> GetPlans()
        {
            var plans = await _client.GetFromJsonAsync<IEnumerable<PlanGroup>>($"{BaseUrl}/plansapi/list");
            return plans;
        }

        public async Task SetParams(double? weigth, double? heigth)
        {
            var paramsVm = new SetUserParamsViewmodel()
            {
                Weight = weigth,
                Heigth = heigth
            };
            await _client.PostAsJsonAsync($"{BaseUrl}/userapi/setparams", paramsVm);
        }

        public async Task<IEnumerable<WeigthHistory>> GetWeigthHistory()
        {
            var weigthHistory = await _client.GetFromJsonAsync<IEnumerable<WeigthHistory>>($"{BaseUrl}/userapi/getweigthhistory");
            return weigthHistory;
        }

        public async Task<IEnumerable<TrainHistory>> GetTrainHistory()
        {
            var trainHistory = await _client.GetFromJsonAsync<IEnumerable<TrainHistory>>($"{BaseUrl}/userapi/gettrainhistory");
            return trainHistory;
        }

        public async Task SaveTrain(int planId)
        {
            await _client.PostAsync($"{BaseUrl}/plansapi/savetrain/{planId}", null);
        }

        public async Task<UserStats> GetUserStats()
        {
            var stats = await _client.GetFromJsonAsync<UserStats>($"{BaseUrl}/userapi/stats");
            return stats;
        }

        public bool Check(string token)
        {
            try
            {
                var result = _client.GetAsync($"{BaseUrl}/userapi/check").GetAwaiter().GetResult();
                result.EnsureSuccessStatusCode();
                return true;
            }
            catch { }
            return false;
        }

        public async Task<IEnumerable<ExercisePart>> GetExercises()
        {
            var exercices = await _client.GetFromJsonAsync<IEnumerable<ExercisePart>>($"{BaseUrl}/plansapi/exercices");
            return exercices;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
