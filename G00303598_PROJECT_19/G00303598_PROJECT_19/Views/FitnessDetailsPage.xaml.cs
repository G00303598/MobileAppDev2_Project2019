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

            // Set title on page
            this.Title = _fitnessInfo.DateToStore.ToString();
        }
    }
}