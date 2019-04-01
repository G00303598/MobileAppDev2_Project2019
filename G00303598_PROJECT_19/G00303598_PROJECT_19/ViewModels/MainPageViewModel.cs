using G00303598_PROJECT_19.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
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
        // Private fields
        private ObservableCollection<FitnessInfoViewModel> fitnessInfoList;
        private FitnessInfoViewModel selectedFitnessInfo;

        // Public properties
        public ObservableCollection<FitnessInfoViewModel> FitnessInfoList
        {
            get { return fitnessInfoList; }
            set { SetValue(ref fitnessInfoList, value); }
        }

        public FitnessInfoViewModel SelectedFitnessInfo
        {
            get { return selectedFitnessInfo; }
            set { SetValue(ref selectedFitnessInfo, value); }
        }
        #endregion

        #region Command Interfaces
        //ICommand interface with two methods
        // canExecute, Execute
        public ICommand ReadListCommand { get; private set; }
        public ICommand SaveListCommand { get; private set; }
        public ICommand DeleteFromListCommand { get; private set; }
        // TODO: CLEAR + INSERT
        #endregion

        #region Public Events
        private readonly IPageService _pageService; // used to get a handle on the interface implemented

        // Constructor
        public MainPageViewModel(IPageService pageService) // Dependancy injection
        {
            _pageService = pageService;
            ReadList();
            // Command Actions
            ReadListCommand = new Command(ReadList);
            SaveListCommand = new Command(SaveList);
            DeleteFromListCommand = new Command<FitnessInfoViewModel>(DeleteOneEntry);
        }

        // Methods
        public void ReadList()
        {
            fitnessInfoList = FitnessInfoViewModel.ReadLocalFitnessData(); // Read list of fitness info
        }

        public void SaveList()
        {
            // Writing obervable collection to file
            FitnessInfoViewModel.SaveLocaFitnessData(fitnessInfoList);
        }

        public void DeleteOneEntry(FitnessInfoViewModel item)
        {
            fitnessInfoList.Remove(item);
            // SelectedFitnessInfo = null;
        }

        // using system.threading.tasks
        public async Task SelectOneItemAsync(FitnessInfoViewModel item)
        {
            if (fitnessInfoList == null)
                return;
            await _pageService.PushAsync(new FitnessDetailsPage(item)); // calling interface method
        }
        #endregion
    }
}
