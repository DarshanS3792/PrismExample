﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomMasterDetailPage : MasterDetailPage
    {
		public CustomMasterDetailPage()
		{
			InitializeComponent ();
		}
    }
}