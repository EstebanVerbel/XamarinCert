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
            string connectionType = CrossConnectivity.Current.ConnectionTypes.First().ToString();

            // set the label's text
            ConnectionDetails.Text = connectionType;
        }
        
    }
}
