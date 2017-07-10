using People.Assets;
using System;
using Xamarin.Forms;

namespace People
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = string.Empty;
            await PersonRepository.Instance.AddNewPersonAsync(newPerson.Text);
            statusMessage.Text = PersonRepository.Instance.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = string.Empty;
            var people = await PersonRepository.Instance.GetAllPeopleAsync();
            peopleList.ItemsSource = people;
        }

    }
}
