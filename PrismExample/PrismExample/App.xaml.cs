using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismExample.ViewModels;
using PrismExample.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismExample
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            // NavigationService.NavigateAsync("HomePage");
            NavigationService.NavigateAsync("/CustomMasterDetailPage/NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) // Need to register all the pages that are created
        {
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>(); // Connecting Views and ViewModels, by using this no need to provide BindingContext in xaml.cs
            containerRegistry.RegisterForNavigation<PostsPage, PostsPageViewModel>();

            containerRegistry.RegisterForNavigation<CustomMasterDetailPage, CustomMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>(); // Registering NavigationPage since we need to navigate across pages in MasterDetailPage

            containerRegistry.RegisterForNavigation<BatteryStatusPage, BatteryStatusPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomTabbedPage>();
        }
    }
}
