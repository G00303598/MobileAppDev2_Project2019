﻿using G00303598_PROJECT_19.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using G00303598_PROJECT_19.Views;

namespace G00303598_PROJECT_19
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // this.Title = "My Health Tracker";
            NavigationPage.SetHasNavigationBar(this, false); // Removes title bar

            // Connection to MainPageViewModel class
            this.BindingContext = new MainPageViewModel(new PageService()); // Dependency injection

        }

        private void DeleteContext_Clicked(object sender, EventArgs e)
        {
            FitnessInfoViewModel fitnessEntry = (sender as MenuItem).CommandParameter as FitnessInfoViewModel;
            (BindingContext as MainPageViewModel).DeleteFromListCommand.Execute(fitnessEntry);
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

        private void BtnSaveFile_Clicked(object sender, EventArgs e)
        {
            FitnessInfoViewModel fitnessEntry = (sender as MenuItem).CommandParameter as FitnessInfoViewModel;
            (BindingContext as MainPageViewModel).SaveListCommand.Execute(fitnessEntry);
        }

        private void ToCameraPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CameraPage());
        }       
    }
}
