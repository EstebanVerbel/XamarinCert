using FlagData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FunFlacts
{
    public partial class AllFlags : ContentPage
    {
        public AllFlags()
        {
            InitializeComponent();

            flags.ItemsSource = DependencyService.Get<FunFlactsViewModel>().Flags;

            flags.ItemTapped += OnItemTapped;
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            DependencyService.Get<FunFlactsViewModel>().CurrentFlag = (Flag)e.Item;
            await this.Navigation.PushAsync(new FlagDetailsPage());
        }


    }
}
