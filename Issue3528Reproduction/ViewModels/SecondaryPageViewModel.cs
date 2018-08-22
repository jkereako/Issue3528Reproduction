using System;
using System.ComponentModel;
using System.Windows.Input;
using Issue3528Reproduction.Flows;
using Xamarin.Forms;

namespace Issue3528Reproduction.ViewModels
{
    public class SecondaryPageViewModel : BaseViewModel, INavigationFlowMember
    {
        //-- Events
        public event EventHandler ShouldAdvance;
        public event EventHandler ShouldPopToRoot;

        //-- Commands
        public ICommand NextCommand { get; }
        public ICommand PopToRootCommand { get; }

        //-- Properties
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        //-- Fields
        private string _title;

        public SecondaryPageViewModel()
        {
            NextCommand = new Command(Advance);
            PopToRootCommand = new Command(PopToRoot);
        }

        ~SecondaryPageViewModel()
        {
            Console.WriteLine($"View model disposed: \"{Title}\".");
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
