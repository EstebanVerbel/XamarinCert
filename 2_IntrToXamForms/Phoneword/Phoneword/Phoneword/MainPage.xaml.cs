using System;
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

        string translatedNumber;

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

            // subscribe click event handlers
            translateButton.Clicked += OnTranslate;
            callButton.Clicked += OnCall;
        }
        
        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredPhoneNumber = phoneNumberText.Text;

            translatedNumber = PhonewordTranslator.ToNumber(enteredPhoneNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                // good
                callButton.IsEnabled = true;
                callButton.Text = $"Call {translatedNumber}";
            }
            else
            {
                // could not do translation
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }    
        }

        private async void OnCall(object sender, EventArgs e)
        {
            bool isDialNumber = await DisplayAlert("Dial a Number", $"Would you like to call {translatedNumber}", "Yes", "No");

            if (isDialNumber)
            {
                var dialer = DependencyService.Get<IDialer>();

                if (dialer != null)
                    await dialer.DialAsync(translatedNumber);
                else
                    await DisplayAlert("Error", "Unable to find a registered implementation of IDialer", "OK");
            }
        }

    }
}
