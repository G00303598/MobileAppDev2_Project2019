using G00303598_PROJECT_19.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace G00303598_PROJECT_19
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

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
            entCurrentWeight.Text = "";
            entPreviousWeight.Text = "";
            entGoalWeight.Text = "";
            entCaloriesIn.Text = "";
            entCaloriesInGoal.Text = "";
            entWaterDrank.Text = "";
            entDistanceRan.Text = "";
            entComment.Text = "";
        }
    }
}
