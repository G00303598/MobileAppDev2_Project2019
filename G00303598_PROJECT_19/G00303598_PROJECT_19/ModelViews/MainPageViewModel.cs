using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

/* Note to self about view models:
 * View Models
 * Contains all the methdos and properties
 * to manipulate the data connected to the fitness list file
 * and the fitness class
*/

namespace G00303598_PROJECT_19
{
    class MainPageViewModel : BaseViewModel
    {
        #region Properties
        // Using an ObervableCollection as a way of holding data
        private ObservableCollection<FitnessInfo> myFitnessInfo;
        public ObservableCollection<FitnessInfo> MyFitnessInfo { get { return myFitnessInfo; }
            set { SetValue(ref myFitnessInfo, value); }
        }

        // Unsure why using Fav? -- Remove later? 
        private FitnessInfo favEntry;
        public FitnessInfo FavEntry { get { return favEntry; }
            set { SetValue(ref favEntry, value); }
        }

        // TODO: Data bind to slOneElement binding context
        private FitnessInfo selectedEntry;
        public FitnessInfo SelectedEntry { get { return selectedEntry; }
            set { SetValue(ref selectedEntry, value); }
        }

        #endregion

        #region Contructors
        public MainPageViewModel()
        {
            ReadList();
            // Command Actions
            SaveListCommand = new Command(SaveList);
            DeleteFromListCommand = new Command<FitnessInfo>(DeleteOneEntry);
        }
        #endregion

        #region Methods
        public void ReadList()
        {
            MyFitnessInfo = FitnessInfo.ReadLocalFitnessData(); // Reads list of fitness info
        }

        public void SaveList()
        {
            // Write observable collection to file
            FitnessInfo.SaveLocaFitnessData(MyFitnessInfo);
        }

        public void DeleteOneEntry(FitnessInfo fi)
        {
            MyFitnessInfo.Remove(fi);
            // Need to clear list out
            SelectedEntry = null;
        }
        #endregion

        #region Command Interfaces
        // ICommand interface with two methods -- Will update for more? 
        // canExecute, Execute
        public ICommand SaveListCommand { get; set; }
        public ICommand DeleteFromListCommand { get; set; }
        #endregion
    }
}
