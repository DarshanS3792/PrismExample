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

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private bool _isVoiceRecognised;
        public bool IsVoiceRecognised
        {
            get { return _isVoiceRecognised; }
            set { SetProperty(ref _isVoiceRecognised, value); }
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

        public async void GoToVoiceRecognisedPage()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                var text = Text.ToUpper();

                if (text.Contains("POST"))
                {
                    GotoPostsPage();
                }
                else if (text.Contains("BATTERY"))
                {
                    await _navigationService.NavigateAsync("BatteryStatusPage");
                }
                else if (text.Contains("TAB"))
                {
                    await _navigationService.NavigateAsync("CustomTabbedPage");
                }
                else if (text.Contains("RENDERER"))
                {
                    await _navigationService.NavigateAsync("CustomRendererExamplePage");
                }
                else if (text.Contains("LOGOUT"))
                {
                    await _navigationService.NavigateAsync("LoginPage");
                }
                else if (!text.Contains("POST") && !text.Contains("BATTERY") && !text.Contains("TAB") && !text.Contains("RENDERER") && !text.Contains("LOGOUT"))
                {
                    await _pageDialogService.DisplayAlertAsync("Sorry!", "I can't navigate there", "Ok");
                }
            }
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
