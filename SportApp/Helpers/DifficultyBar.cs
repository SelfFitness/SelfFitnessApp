using CommunityToolkit.Maui.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Helpers
{
    public partial class DifficultyBar : ContentView
    {
        public static readonly BindableProperty MinProperty = BindableProperty.Create(
            nameof(Min), typeof(int), typeof(HorizontalStackLayout), 0, propertyChanged: OnPropertiesChanged);

        public int Min
        {
            get => (int)GetValue(MinProperty);
            set => SetValue(MinProperty, value);
        }

        public static readonly BindableProperty MaxProperty = BindableProperty.Create(
            nameof(Max), typeof(int), typeof(DifficultyBar), 0, propertyChanged: OnPropertiesChanged);

        public int Max
        {
            get => (int)GetValue(MaxProperty);
            set => SetValue(MaxProperty, value);
        }

        public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create(
           nameof(StrokeWidth), typeof(int), typeof(DifficultyBar), 0, propertyChanged: OnPropertiesChanged);

        public int StrokeWidth
        {
            get => (int)GetValue(StrokeWidthProperty);
            set => SetValue(StrokeWidthProperty, value);
        }

        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(
           nameof(FillColor), typeof(Color), typeof(DifficultyBar), propertyChanged: OnPropertiesChanged);

        public Color FillColor
        {
            get => (Color)GetValue(FillColorProperty);
            set => SetValue(FillColorProperty, value);
        }

        public static readonly BindableProperty UnFillColorProperty = BindableProperty.Create(
            nameof(UnFillColor), typeof(Color), typeof(DifficultyBar), propertyChanged: OnPropertiesChanged);

        public Color UnFillColor
        {
            get => (Color)GetValue(UnFillColorProperty);
            set => SetValue(UnFillColorProperty, value);
        }

        public static readonly BindableProperty StrokeImageProperty = BindableProperty.Create(
            nameof(StrokeImage), typeof(ImageSource), typeof(DifficultyBar), propertyChanged: OnPropertiesChanged);

        public ImageSource StrokeImage
        {
            get => (ImageSource)GetValue(StrokeImageProperty);
            set => SetValue(StrokeImageProperty, value);
        }

        public DifficultyBar()
        {
        }

        private static void OnPropertiesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var difficultyBar = bindable as DifficultyBar;
            var horizontalStackLayout = new HorizontalStackLayout();

            for (int i = 0; i < difficultyBar.Max; i++)
            {
                var filledImg = new Image()
                {
                    Source = difficultyBar.StrokeImage,
                    WidthRequest = difficultyBar.StrokeWidth,
                };
                filledImg.Behaviors.Add(new IconTintColorBehavior()
                {
                    TintColor = i < difficultyBar.Min ? difficultyBar.FillColor : difficultyBar.UnFillColor
                });
                horizontalStackLayout.Add(filledImg);
            }
            difficultyBar.Content = horizontalStackLayout;
        }

    }
}
