using Prism.Mvvm;
using Prism.Navigation;
using PrismExample.Models;
using PrismExample.Services;
using System.Collections.ObjectModel;

namespace PrismExample.ViewModels
{
    public class PostsPageViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;
        private readonly PostsService _postsService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> Posts
        {
            get { return _posts; }
            set { SetProperty(ref _posts, value); }
        }

        private bool _isBusy; // Loader
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public PostsPageViewModel(INavigationService navigationService, PostsService postsService)
        {
            _navigationService = navigationService;
            _postsService = postsService;

            GetPosts();
            IsBusy = true;
        }

        private async void GetPosts()
        {
            var posts = await _postsService.GetPostsAsync(); // Retrieving list of data from API
            Posts = posts; // Assigning it to a binding property for binding data to the list in xaml
            IsBusy = false; // Once the data is retrieved stop the loader
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var element = parameters["MyParam"]; // Receiving the parameters

            if (element != null)
            {
                Title = element.ToString();
            }
        }
    }
}
