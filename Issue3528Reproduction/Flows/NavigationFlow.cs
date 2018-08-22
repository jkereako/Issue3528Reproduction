using System;
using Xamarin.Forms;
using Issue3528Reproduction.Pages;
using Issue3528Reproduction.ViewModels;
using System.Diagnostics;
using System.Threading;

namespace Issue3528Reproduction.Flows
{
    public class NavigationFlow
    {
        private INavigation _navigation;
        private int _counter;

        public NavigationFlow(INavigation navigation, INavigationFlowMember member)
        {
            _navigation = navigation;
            member.ShouldAdvance += PushPage;
            member.ShouldPopToRoot += PopToRoot;
        }

        public async void PushPage(object sender, EventArgs eventArgs)
        {
            Debug.Assert(
                !Thread.CurrentThread.IsBackground, "Attempting to update UI on a background thread."
            );

            var page = new SecondaryPage();
            var viewModel = new SecondaryPageViewModel();

            viewModel.Title = $"View No. {(++_counter).ToString()}";
            viewModel.ShouldAdvance += PushPage;
            viewModel.ShouldPopToRoot += PopToRoot;
            page.BindingContext = viewModel;

            await _navigation.PushAsync(page);
        }

        public async void PopToRoot(object sender, EventArgs eventArgs)
        {
            Debug.Assert(
                !Thread.CurrentThread.IsBackground, "Attempting to update UI on a background thread."
            );

            await _navigation.PopToRootAsync(true);

            _counter = 0;
        }
    }
}
