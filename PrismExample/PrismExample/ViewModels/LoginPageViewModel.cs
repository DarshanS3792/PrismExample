﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace PrismExample.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        public DelegateCommand OnLoginCommand { get; set; }
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            OnLoginCommand = new DelegateCommand(async () => await GoHome());
        }

        async Task GoHome()
        {
            if (string.IsNullOrEmpty(UserName))
                await _pageDialogService.DisplayAlertAsync("Error", "UserName is required", "Ok");
            else
                await _navigationService.NavigateAsync(new Uri($"/CustomMasterDetailPage/NavigationPage/HomePage?UserName={UserName}")); // Passing parameters along with navigation
        }
    }
}
