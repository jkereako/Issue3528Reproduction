using System;
using Xamarin.Forms;

namespace Issue3528Reproduction
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        ~MainPage()
        {
            Console.WriteLine("MainPage disposed.");
        }
    }
}
