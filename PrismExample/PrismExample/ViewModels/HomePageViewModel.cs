using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;

namespace PrismExample.ViewModels
{
    public class HomePageViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService; // Used to navigate from one page to another
        IPageDialogService _pageDialogService; // Used to display alert dialogs

        private string _username;
        public string UserName
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand DisplayAlertCommand { get; set; } // Used for button clicks
        public ICommand GotoPostsPageCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            Title = "This is an example demonstrating Prism framework in Xamarin.Forms";

            DisplayAlertCommand = new DelegateCommand(DisplayAlert); // Assigning a function to command

            GotoPostsPageCommand = new DelegateCommand(GotoPostsPage); 
        }

        async void DisplayAlert()
        {
            await _pageDialogService.DisplayAlertAsync("Display alert using Prism", "Hello!", "Ok");
        }

        async void GotoPostsPage()
        {
            var parameter = new NavigationParameters();
            parameter.Add("MyParam", "Example to call an API service to get list of data"); // Another way of passing parameters

            await _navigationService.NavigateAsync("PostsPage", parameter);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("UserName"))
            {
                UserName = parameters.GetValue<string>("UserName");
            }
        }
    }
}
