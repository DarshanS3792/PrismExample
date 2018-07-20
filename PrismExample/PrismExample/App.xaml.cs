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

            NavigationService.NavigateAsync("LoginPage");
            // NavigationService.NavigateAsync("CustomNavigationPage/LoginPage"); // Un-comment this to see the change in bar colour which makes use of CustomNavigationPage using Event Aggregator
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) // Need to register all the pages that are created
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>(); // Connecting Views and ViewModels, by using this no need to provide BindingContext in xaml.cs
            containerRegistry.RegisterForNavigation<PostsPage, PostsPageViewModel>();

            containerRegistry.RegisterForNavigation<CustomMasterDetailPage, CustomMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>(); // Registering NavigationPage since we need to navigate across pages in MasterDetailPage
            containerRegistry.RegisterForNavigation<CustomNavigationPage>(); // Use CustomNavigationPage in case if you want to change nav bar color etc.

            containerRegistry.RegisterForNavigation<BatteryStatusPage, BatteryStatusPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomTabbedPage>();
            containerRegistry.RegisterForNavigation<CustomRendererExamplePage>();
        }
    }
}
