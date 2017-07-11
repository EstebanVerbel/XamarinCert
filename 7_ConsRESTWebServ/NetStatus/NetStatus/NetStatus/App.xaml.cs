using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NetStatus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = CrossConnectivity.Current.IsConnected ? (Page) new NetworkViewPage() : new NoNetworkPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            Type currentPage = MainPage.GetType();

            if (e.IsConnected && currentPage != typeof(NetworkViewPage))
                MainPage = new NetworkViewPage();
            else if (!e.IsConnected && currentPage != typeof(NoNetworkPage))
                MainPage = new NoNetworkPage();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
