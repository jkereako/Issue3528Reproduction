using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Issue3528Reproduction.Flows;
using Issue3528Reproduction.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Issue3528Reproduction
{
    public partial class App : Application
    {
        NavigationFlow _navigationFlow;

        public App()
        {
            InitializeComponent();

            var viewModel = new MainPageViewModel();
            var page = new MainPage();

            page.BindingContext = viewModel;

            MainPage = new NavigationPage(page);
            _navigationFlow = new NavigationFlow(MainPage.Navigation, viewModel);
        }
    }
}
