using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostsPage : ContentPage
	{
		public PostsPage()
		{
			InitializeComponent ();
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}