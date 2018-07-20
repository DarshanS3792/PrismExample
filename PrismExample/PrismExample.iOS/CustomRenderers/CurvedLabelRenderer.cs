using PrismExample.CustomRenderers;
using PrismExample.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CurvedLabel), typeof(CurvedLabelRenderer))]
namespace PrismExample.iOS.CustomRenderers
{
    public class CurvedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var _xfViewReference = (CurvedLabel)Element;
                this.Layer.CornerRadius = (float)_xfViewReference.CurvedCornerRadius;
                this.Layer.BackgroundColor = _xfViewReference.CurvedBackgroundColor.ToCGColor();
            }
        }
    }
}