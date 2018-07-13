using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismExample.ViewModels;
using PrismExample.Views;
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

            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(); // Connecting Views and ViewModels, by using this no need to provide BindingContext in xaml.cs
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        }
    }
}
