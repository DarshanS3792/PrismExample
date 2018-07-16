using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomTabbedPage : TabbedPage
	{
		public CustomTabbedPage()
		{
			InitializeComponent ();
		}
	}
}