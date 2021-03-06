﻿using System;
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

        protected override void OnParentSet()
        {
            base.OnParentSet();

            // Parent is null if the back button is pressed
            if (Parent == null)
            {
                CleanUp();
            }

            Console.WriteLine(Navigation.NavigationStack.Count.ToString());
        }

        // Respond to the Android hardware back button
        protected override bool OnBackButtonPressed()
        {
            CleanUp();

            return base.OnBackButtonPressed();
        }

        private void CleanUp()
        {
            // This code is necessary for Android only. For some reason, memory
            // management on Android is not handled by Xamarin.
            BindingContext = null;
            GC.Collect();
        }
    }
}
