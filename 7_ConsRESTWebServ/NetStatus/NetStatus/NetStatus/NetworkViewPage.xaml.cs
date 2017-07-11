using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NetStatus
{
    public partial class NetworkViewPage : ContentPage
    {
        public NetworkViewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SetConnectionTypeLabelText();

            CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // remove handler on dissapearing to avoid memory leaks since the event is static
            if (CrossConnectivity.Current != null)
                CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
        }

        private void SetConnectionTypeLabelText()
        {
            string connectionType = CrossConnectivity.Current.ConnectionTypes.First().ToString();

            // set the label's text
            ConnectionDetails.Text = connectionType;
        }


        private void UpdateNetworkInfo(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {

            if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
                SetConnectionTypeLabelText();

        }
    }
}
