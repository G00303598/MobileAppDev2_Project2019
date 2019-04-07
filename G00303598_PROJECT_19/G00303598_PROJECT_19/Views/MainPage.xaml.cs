using G00303598_PROJECT_19.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace G00303598_PROJECT_19
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Connection to MainPageViewModel class
            this.BindingContext = new MainPageViewModel(new PageService()); // Dependency injection
        }

        private void DeleteContext_Clicked(object sender, EventArgs e)
        {
            FitnessInfoViewModel fitnessEntry = (sender as MenuItem).CommandParameter as FitnessInfoViewModel;
            (BindingContext as MainPageViewModel).DeleteFromListCommand.Execute(fitnessEntry);
        }

        public async void ListViewOneEntrySelected(object sender, SelectedItemChangedEventArgs e)
        {
            await (BindingContext as MainPageViewModel).SelectOneItemAsync(e.SelectedItem as FitnessInfoViewModel);
        }

        private void BtnResetFields_Clicked(object sender, EventArgs e)
        {
            entDate.Text = "";
            entCurrentWeight.Text = "";
            entPreviousWeight.Text = "";
            entGoalWeight.Text = "";
            entCaloriesIn.Text = "";
            entCaloriesInGoal.Text = "";
            entWaterDrank.Text = "";
            entDistanceRan.Text = "";
            entComment.Text = "";
        }

        private void BtnSaveFile_Clicked(object sender, EventArgs e)
        {
            FitnessInfoViewModel fitnessEntry = (sender as MenuItem).CommandParameter as FitnessInfoViewModel;
            (BindingContext as MainPageViewModel).SaveListCommand.Execute(fitnessEntry);
        }

        private async void BtnTakePhoto_Clicked(object sender, EventArgs e)
        {
            // Camera functionality
            // https://github.com/jamesmontemagno/MediaPlugin

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

        }
    }
}
