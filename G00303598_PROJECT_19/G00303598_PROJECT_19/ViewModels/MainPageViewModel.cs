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
        private ObservableCollection<FitnessInfoViewModel> fitnessInfoList;
        public ObservableCollection<FitnessInfoViewModel> FitnessInfoList
        {
            get { return fitnessInfoList; }
            set { SetValue(ref fitnessInfoList, value); }
        }

        private FitnessInfoViewModel selectedFitnessInfo;
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
        public ICommand ClearUserInputCommand { get; private set; }
        public ICommand CreateNewEntryCommand { get; private set; }
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
            CreateNewEntryCommand = new Command<FitnessInfoViewModel>(AddToList);
            SaveListCommand = new Command(SaveList);
            DeleteFromListCommand = new Command<FitnessInfoViewModel>(DeleteOneEntry);
            ClearUserInputCommand = new Command(ClearUserInput);
        }

        // Methods
        public void ReadList()
        {
            fitnessInfoList = FitnessInfoViewModel.ReadLocalFitnessData(); // Read list of fitness info
        }

        public void SaveList()
        {
            FitnessInfoViewModel fi = new FitnessInfoViewModel();
            // Writing obervable collection to file
            FitnessInfoViewModel.SaveLocaFitnessData(fitnessInfoList);
        }

        public void AddToList(FitnessInfoViewModel item)
        {
            // add an entry to the list
            FitnessInfoViewModel fivm = new FitnessInfoViewModel();
            fivm.DateToStore = DateTime.Now;
            fitnessInfoList.Add(fivm);
        }

        public void ClearUserInput()
        {
            FitnessInfoViewModel fivm = new FitnessInfoViewModel();
            fivm.DateToStore = DateTime.Now.ToLocalTime();   
        }

        public void DeleteOneEntry(FitnessInfoViewModel item)
        {
            fitnessInfoList.Remove(item);
            // SelectedFitnessInfo = null;
        }
        #endregion
    }
}
