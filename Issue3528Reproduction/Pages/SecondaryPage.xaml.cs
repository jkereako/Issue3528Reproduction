using System;
using Xamarin.Forms;

namespace Issue3528Reproduction.Pages
{
    public partial class SecondaryPage : ContentPage
    {
        public SecondaryPage()
        {
            InitializeComponent();
        }

        ~SecondaryPage()
        {
            Console.WriteLine("SecondaryPage disposed.");
        }
    }
}
