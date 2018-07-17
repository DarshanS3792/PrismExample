using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;

namespace PrismExample.ViewModels
{
    public class CustomMasterDetailPageViewModel
    {
        INavigationService _navigationService;
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public ICommand OnLogOutCommand { get; set; }

        public CustomMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OnNavigateCommand = new DelegateCommand<string>(NavigateAync);
            OnLogOutCommand = new DelegateCommand(BackToLoginPage);
        }

        async void NavigateAync(string page)
        {
            await _navigationService.NavigateAsync(page);
        }

        async void BackToLoginPage()
        {
            await _navigationService.NavigateAsync("LoginPage");
        }
    }
}
