using System;
using System.Threading;
using System.Windows.Input;
using Issue3528Reproduction.Flows;
using Xamarin.Forms;

namespace Issue3528Reproduction.ViewModels
{
    public class MainPageViewModel : INavigationFlowMember
    {
        //-- Events
        public event EventHandler ShouldAdvance;
        public event EventHandler ShouldPopToRoot;

        //-- Commands
        public ICommand NextCommand { get; }
        public ICommand PopToRootCommand { get; }

        public MainPageViewModel()
        {
            PopToRootCommand = new Command(PopToRoot);
            NextCommand = new Command(Advance);
        }

        ~MainPageViewModel()
        {
            Console.WriteLine("MainPageViewModel disposed.");
        }

        private void PopToRoot()
        {
            ShouldPopToRoot?.Invoke(this, EventArgs.Empty);
        }

        private void Advance()
        {
            ShouldAdvance?.Invoke(this, EventArgs.Empty);
        }
    }
}
