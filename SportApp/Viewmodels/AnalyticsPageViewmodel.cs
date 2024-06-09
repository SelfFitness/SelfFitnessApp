using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microcharts;
using Plugin.Maui.Calendar.Models;
using SkiaSharp;
using SportApp.Abstractions;
using System.Globalization;

namespace SportApp.Viewmodels
{
    public partial class AnalyticsPageViewmodel : ObservableObject
    {
        const double arrowSize = 12;

        const double firstRange = 15;

        const double secondRange = 16;

        const double thirdRange = 18.5;

        const double fourthRange = 25;

        const double fifthRange = 30;

        const double sixthRange = 35;

        const double seventhRange = 40;

        const int cellCount = 6;

        [ObservableProperty]
        private EventCollection _events;

        [ObservableProperty]
        private CultureInfo _culture;

        [ObservableProperty]
        private Chart _chart;

        [ObservableProperty]
        private Thickness _arrowMargin;

        [ObservableProperty]
        private int _progressWidth;

        [ObservableProperty]
        private double _bmiCoeff;

        private double _weigth;

        public double Weigth
        {
            get => _weigth;
            set
            {
                _weigth = Math.Round(value, 1);
                OnPropertyChanged(nameof(Weigth));
            }
        }

        private double _heigth;

        public double Heigth
        {
            get => _heigth;
            set
            {
                _heigth = Math.Round(value, 1);
                OnPropertyChanged(nameof(Heigth));
            }
        }

        private readonly IClientApi _clientApi;

        public AnalyticsPageViewmodel(IClientApi clientApi)
        {
            Events = new EventCollection();
            _clientApi = clientApi;
            Culture = CultureInfo.CurrentCulture;
            ProgressWidth = 280;
            Task.Run(UpdateStats);
        }

        public async Task UpdateStats()
        {
            await UpdateTrainHistory();
            await UpdateWeigthHistory();
            await UpdateUserStats();
        }

        public async Task UpdateTrainHistory()
        {
            var trainHistory = await _clientApi.GetTrainHistory();
            if (trainHistory != null && trainHistory.Any())
            {;
                var events = new EventCollection();
                foreach (var train in trainHistory)
                {
                    try
                    {
                        events.Add(train.Date.ToLocalTime(), new List<object> { new object() });
                    }
                    catch { }
                }
                Events = events;
            }
        }

        public async Task UpdateWeigthHistory()
        {
            var weigthHistory = await _clientApi.GetWeigthHistory();
            if (weigthHistory != null && weigthHistory.Any())
            {
                var chart = new LineChart()
                {
                    BackgroundColor = SKColor.Parse("#161833"),
                    ValueLabelOrientation = Orientation.Horizontal,
                    ValueLabelTextSize = 25,
                    LabelTextSize = 30,
                    LabelOrientation = Orientation.Horizontal,
                    IsAnimated = true,
                    ValueLabelOption = ValueLabelOption.TopOfElement,
                };
                var chartEntries = new List<ChartEntry>();

                foreach (var weigth in weigthHistory)
                {
                    chartEntries.Add(new ChartEntry(Convert.ToSingle(weigth.Weigth))
                    {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = weigth.Weigth.ToString(),
                        Label = weigth.Weigth.ToString(),
                        ValueLabelColor = SKColor.Parse("#fff"),
                    });
                }
                try
                {
                    var predictWeigth = await _clientApi.GetPredictWeigth();
                    if (predictWeigth != null)
                    {
                        chartEntries.Add(new ChartEntry(Convert.ToSingle(predictWeigth.Weigth))
                        {
                            Color = SKColor.Parse("#00FF3C"),
                            ValueLabel = predictWeigth.Weigth.ToString(),
                            Label = predictWeigth.Weigth.ToString(),
                            ValueLabelColor = SKColor.Parse("#00FF3C"),
                        });
                    }
                } catch { }
                chart.Entries = chartEntries;
                Chart = chart;
            }
        }

        private async Task UpdateUserStats()
        {
            var stats = await _clientApi.GetUserStats();
            Weigth = stats.Weigth.GetValueOrDefault();
            Heigth = stats.Heigth.GetValueOrDefault();
            SetBmi(stats.Bmi.GetValueOrDefault());
            await Task.Delay(5000).ContinueWith(async obj => {
                if (stats.Weigth == null || 
                    stats.Heigth == null ||
                    stats.Weigth == 0 ||
                    stats.Heigth == 0)
                {
                    await Shell.Current.CurrentPage.DisplaySnackbar("Установите вес и рост во вкладке Аналитика", null, "Закрыть", TimeSpan.FromSeconds(5));
                }
            });
        }

        public void SetBmi(double coeff)
        {
            BmiCoeff = coeff;
            var cellWidth = ProgressWidth / cellCount;
            if (coeff <= firstRange)
            {
                ArrowMargin = new Thickness(-arrowSize, 0, 0, 0);
                return;
            }
            if (coeff <= secondRange)
            {
                var width = secondRange - firstRange;
                var percent = coeff - firstRange;
                var margin = percent * cellWidth / width - arrowSize;
                ArrowMargin = new Thickness(margin, 0, 0, 0);
                return;
            }
            if (coeff <= thirdRange)
            {
                var width = thirdRange - secondRange;
                var percent = coeff - secondRange;
                var margin = cellWidth + percent * cellWidth / width - arrowSize;
                ArrowMargin = new Thickness(margin, 0, 0, 0);
                return;
            }
            if (coeff <= fourthRange)
            {
                var width = fourthRange - thirdRange;
                var percent = coeff - thirdRange;
                var margin = 2 * cellWidth + percent * cellWidth / width - arrowSize;
                ArrowMargin = new Thickness(margin, 0, 0, 0);
                return;
            }
            if (coeff <= fifthRange)
            {
                var width = fifthRange - fourthRange;
                var percent = coeff - fourthRange;
                var margin = 3 * cellWidth + percent * cellWidth / width - arrowSize;
                ArrowMargin = new Thickness(margin, 0, 0, 0);
                return;
            }
            if (coeff <= sixthRange)
            {
                var width = sixthRange - fifthRange;
                var percent = coeff - fifthRange;
                var margin = 4 * cellWidth + percent * cellWidth / width - arrowSize;
                ArrowMargin = new Thickness(margin, 0, 0, 0);
                return;
            }
            if (coeff <= seventhRange)
            {
                var width = seventhRange - sixthRange;
                var percent = coeff - sixthRange;
                var margin = 5 * cellWidth + percent * cellWidth / width - arrowSize;
                ArrowMargin = new Thickness(margin, 0, 0, 0);
                return;
            }
            if (coeff > seventhRange)
            {
                var margin = 6 * cellWidth - arrowSize;
                ArrowMargin = new Thickness(margin, 0, 0, 0);
                return;
            }
        }

        [RelayCommand]
        private async Task UpdateParams()
        {
            await _clientApi.SetParams(Weigth, Heigth);
            await UpdateStats();
        }

        [RelayCommand]
        private async Task EditWeigth()
        {
            var result = await Shell.Current.CurrentPage.DisplayPromptAsync("Редактирование веса", "Введите ваш вес", "ОК", "Отмена", "80", -1, Keyboard.Numeric);
            if (!string.IsNullOrEmpty(result) && double.TryParse(result, out double weigth))
            {
                Weigth = weigth;
            }
        }

        [RelayCommand]
        private async Task EditHeigth()
        {
            var result = await Shell.Current.CurrentPage.DisplayPromptAsync("Редактирование роста", "Введите ваш рост", "ОК", "Отмена", "177", -1, Keyboard.Numeric);
            if (!string.IsNullOrEmpty(result) && double.TryParse(result, out double heigth))
            {
                Heigth = heigth;
            }
        }
    }
}
