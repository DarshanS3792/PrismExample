using Xamarin.Forms;

namespace PrismExample.CustomRenderers
{
    public class CurvedLabel : Label
    {
        public static readonly BindableProperty CurvedCornerRadiusProperty =
              BindableProperty.Create(
                  nameof(CurvedCornerRadius),
                  typeof(double),
                  typeof(CurvedLabel),
                  12.0);

        public double CurvedCornerRadius
        {
            get { return (double)GetValue(CurvedCornerRadiusProperty); }
            set { SetValue(CurvedCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty CurvedBackgroundColorProperty =
            BindableProperty.Create(
                nameof(CurvedCornerRadius),
                typeof(Color),
                typeof(CurvedLabel),
                Color.Default);

        public Color CurvedBackgroundColor
        {
            get { return (Color)GetValue(CurvedBackgroundColorProperty); }
            set { SetValue(CurvedBackgroundColorProperty, value); }
        }
    }
}
