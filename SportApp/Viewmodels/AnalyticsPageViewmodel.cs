using Android.Mtp;
using CommunityToolkit.Mvvm.ComponentModel;
using Microcharts;
using Plugin.Maui.Calendar.Models;
using SkiaSharp;
using SportApp.Models;
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

        public EventCollection Events { get; set; }

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

        public AnalyticsPageViewmodel()
        {
            Events = new EventCollection
            {
                [DateTime.Now.AddDays(-3)] = new List<ExercisePart>
                {
                    new ExercisePart(),
                },
            };
            Culture = CultureInfo.CurrentCulture;
            Chart = new LineChart()
            {
                Entries =
                [
                    new ChartEntry(80) {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = "80",
                        Label = "80",
                        ValueLabelColor = SKColor.Parse("#fff"),
                    },
                    new ChartEntry(90) {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = "90",
                        Label = "90",
                        ValueLabelColor = SKColor.Parse("#fff"),
                    },
                    new ChartEntry(100) {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = "100",
                        Label = "100",
                        ValueLabelColor = SKColor.Parse("#fff"),
                    },
                    new ChartEntry(110) {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = "110",
                        Label = "110",
                        ValueLabelColor = SKColor.Parse("#fff"),
                    },
                    new ChartEntry(80) {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = "80",
                        Label = "80",
                        ValueLabelColor = SKColor.Parse("#fff"),
                    },
                    new ChartEntry(70) {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = "70",
                        Label = "70",
                        ValueLabelColor = SKColor.Parse("#fff"),
                    },
                    new ChartEntry(110) {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = "110",
                        Label = "110",
                        ValueLabelColor = SKColor.Parse("#fff"),
                    },
                    new ChartEntry(80) {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = "80",
                        Label = "80",
                        ValueLabelColor = SKColor.Parse("#fff"),
                    },
                    new ChartEntry(70) {
                        Color = SKColor.Parse("#8000FF"),
                        ValueLabel = "70",
                        Label = "70",
                        ValueLabelColor = SKColor.Parse("#fff"),
                    },
                ],
                BackgroundColor = SKColor.Parse("#161833"),
                ValueLabelOrientation = Orientation.Horizontal,
                ValueLabelTextSize = 25,
                LabelTextSize = 30,
                LabelOrientation = Orientation.Horizontal,
                IsAnimated = true,
                ValueLabelOption = ValueLabelOption.TopOfElement,
            };
            ProgressWidth = 280;
            SetBmi(16);
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
    }
}
