using G00303598_PROJECT_19.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


// USE THIS PAGE FOR GRAPHS? 
namespace G00303598_PROJECT_19.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FitnessDetailsPage : ContentPage
    {
        FitnessInfoViewModel _fitnessInfo;
        public FitnessDetailsPage(FitnessInfoViewModel fi)
        {
            InitializeComponent();
            _fitnessInfo = fi;

            this.BindingContext = new MainPageViewModel(new PageService());

            // Set title on page
            this.Title = _fitnessInfo.DateToStore.ToString();

            // Set data for page
            this.entCurrentWeight.Text = _fitnessInfo.CurrentWeight.ToString();
            this.entPreviousWeight.Text = _fitnessInfo.PreviousWeight.ToString();
            this.entGoalWeight.Text = _fitnessInfo.GoalWeight.ToString();
            this.entCaloriesIn.Text = _fitnessInfo.CaloriesIn.ToString();
            this.entCaloriesInGoal.Text = _fitnessInfo.CaloriesInGoal.ToString();
            this.entWaterDrank.Text = _fitnessInfo.WaterDrank.ToString();
            this.entDistanceRan.Text = _fitnessInfo.DistanceRan.ToString();
            this.entComment.Text = _fitnessInfo.Comment.ToString();
        }
    }
}