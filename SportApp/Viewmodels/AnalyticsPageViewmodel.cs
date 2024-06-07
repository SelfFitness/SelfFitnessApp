using Android.Mtp;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microcharts;
using SkiaSharp;
using SportApp.Abstractions;
using SportApp.Models;
using System.Collections.Specialized;
using System.Globalization;
using XCalendar.Core.Extensions;
using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;
using XCalendar.Maui.Models;

namespace SportApp.Viewmodels
{
    public class ColoredEventsDay : ColoredEventsDay<ColoredEvent>
    {
    }
    public class ColoredEventsDay<TEvent> : CalendarDay<TEvent> where TEvent : IEvent
    {
    }

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
        private Calendar<CalendarDay<IEvent>, IEvent> _eventCalendar;

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
            EventCalendar = new Calendar<CalendarDay<IEvent>, IEvent>();
            _clientApi = clientApi;
            Culture = CultureInfo.CurrentCulture;
            ProgressWidth = 280;
            Task.Run(UpdateStats);
        }

        [RelayCommand]
        private void NavigateCalendar(int amount)
        {
            if (EventCalendar.NavigatedDate.TryAddMonths(amount, out DateTime targetDate))
            {
                EventCalendar.Navigate(targetDate - EventCalendar.NavigatedDate);
            }
            else
            {
                EventCalendar.Navigate(amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue);
            }
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
            {
                var events = new List<IEvent>();
                foreach (var train in trainHistory)
                {
                    events.Add(new Event()
                    {
                        StartDate = train.Date.ToLocalTime().AddDays(-1),
                        EndDate = train.Date.ToLocalTime(),
                    });
                }
                EventCalendar.Events.ReplaceRange(events);
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
                var margin = 5 * cellWidth - arrowSize;
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
    }
}
