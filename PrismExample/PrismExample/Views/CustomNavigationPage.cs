using Prism.Events;
using PrismExample.Events;
using Xamarin.Forms;

namespace PrismExample.Views
{
    public class CustomNavigationPage : NavigationPage
    {
        IEventAggregator _eventAggregator;
        public CustomNavigationPage(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Subscribe(UpdateColor);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Unsubscribe(UpdateColor);
        }

        void UpdateColor(bool isShowingTheLoging)
        {
            if (isShowingTheLoging)
            {
                this.BarBackgroundColor = Color.CadetBlue;
            }
            else
            {
                this.BarBackgroundColor = Color.Black;
            }
        }
    }
}