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

        public void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = string.Empty;
            PersonRepository.Instance.AddNewPerson(newPerson.Text);
            statusMessage.Text = PersonRepository.Instance.StatusMessage;
        }

        public void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = string.Empty;
            var people = PersonRepository.Instance.GetAllPeople();
            peopleList.ItemsSource = people;
        }

    }
}
