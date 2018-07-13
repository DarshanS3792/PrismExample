using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;

namespace PrismExample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        INavigationService _navigationService; // Used to navigate from one page to another
        IPageDialogService _pageDialogService; // Used to display alert dialogs

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand DisplayAlertCommand { get; set; } // Used for button clicks
        public ICommand GotoHomePageCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            Title = "This is an example demonstrating Prism framework in Xamarin.Forms";

            DisplayAlertCommand = new DelegateCommand(DisplayAlert); // Assigning a function to command

            GotoHomePageCommand = new DelegateCommand(GotoHomePage); 
        }

        async void DisplayAlert()
        {
            await _pageDialogService.DisplayAlertAsync("Display alert using Prism", "Hello!", "Ok");
        }

        async void GotoHomePage()
        {
            var parameter = new NavigationParameters();
            parameter.Add("MyParam", "This is Home Page"); // Adding parameters

            await _navigationService.NavigateAsync("HomePage", parameter); // Passing parameters to a page
        }
    }
}
