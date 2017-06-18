﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;

        public MainPage()
        {
            InitializeComponent();

            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };

            panel.Children.Add(
                new Label
                {
                    Text = "Enter a Phoneword:",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                });

            panel.Children.Add(
                phoneNumberText = new Entry
                {
                    Text = "1-855-XAMARIN"
                });

            panel.Children.Add(
                translateButton = new Button
                {
                    Text = "Translate"
                });

            panel.Children.Add(
                callButton = new Button
                {
                    Text = "Call",
                    IsEnabled = false
                });

            this.Content = panel;

        }
    }
}
