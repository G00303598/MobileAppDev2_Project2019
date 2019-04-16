using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using Utils;

namespace G00303598_PROJECT_19
{
    public class FitnessInfoViewModel : BaseViewModel
    {
        #region Accessors + Mutators + Member variables
        private DateTime _dateToStore;
        public DateTime DateToStore
        {
            get { return _dateToStore; }
            set { SetValue(ref _dateToStore, value); }
        }
        private double _currentWeight;
        public double CurrentWeight
        {
            get { return _currentWeight; }
            set { SetValue(ref _currentWeight, value); }
        }

        private double _previousWeight;
        public double PreviousWeight
        {
            get { return _previousWeight; }
            set { SetValue(ref _previousWeight, value); }
        }

        private double _weightDiff;
        public double WeightDiff
        {
            get { return _weightDiff; }
            set { SetValue(ref _weightDiff, value); }
        }

        private double _goalWeight;
        public double GoalWeight
        {
            get { return _goalWeight; }
            set { SetValue(ref _goalWeight, value); }
        }

        private double _caloriesIn;
        public double CaloriesIn
        {
            get { return _caloriesIn; }
            set { SetValue(ref _caloriesIn, value); }
        }

        private double _caloriesInGoal;
        public double CaloriesInGoal
        {
            get { return _caloriesInGoal; }
            set { SetValue(ref _caloriesInGoal, value); }
        }

        private double _waterDrank;
        public double WaterDrank
        {
            get { return _waterDrank; }
            set { SetValue(ref _waterDrank, value); }
        }

        private double _distanceRan;
        public double DistanceRan
        {
            get { return _distanceRan; }
            set { SetValue(ref _distanceRan, value); }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetValue(ref _comment, value); }
        }
        #endregion
  
        #region File IO
        public static ObservableCollection<FitnessInfoViewModel> ReadLocalFitnessData()
        {
            ObservableCollection<FitnessInfoViewModel> list = new ObservableCollection<FitnessInfoViewModel>();

            string fileData; // Using to hold data .. redundant comment

            // Try and read local data first --> "localFitnessInfo.txt"
            // If first run --> read defualt: "myFitnessInfo.txt"

            try
            {
                // Read local data
                // Path to local folder
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // Sandbox folder -- LocalApplicationData

                // Create file name
                string fileName = Path.Combine(path, MyUtilites.FITNESS_OUTPUT_SAVE_FILE);

                // Stream reader based on fileName since in local folder
                using (var reader = new StreamReader(fileName))
                {
                    // Reads everything out from file
                    fileData = reader.ReadToEnd();  // Breakpoint here to find file location
                }
            }
            catch (Exception) //fallback is to read the default file
            {
                // Read defualt data
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;

                // Need stream of data to read from
                Stream stream = assembly.GetManifestResourceStream("G00303598_PROJECT_19.Data.myFitnessInfo.txt");

                using (var reader = new StreamReader(stream))
                {
                    fileData = reader.ReadToEnd(); // Reads everything out from file
                }
            }

            /* Using this code for formatting the date to be
             * reasd properly by the JsonConverter 
             */
            var format = "dd/MM/yyyy"; // datetime format
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            //deserialise line here
            list = JsonConvert.DeserializeObject<ObservableCollection<FitnessInfoViewModel>>(fileData, dateTimeConverter);

            return list;
        }

        public static void SaveLocaFitnessData(ObservableCollection<FitnessInfoViewModel> list)
        {
            // Path name
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // File name
            // Break point here to find file location
            string fileName = Path.Combine(path, MyUtilites.FITNESS_OUTPUT_SAVE_FILE);

            // Stream writer --> False: Always overwrite file
            using (var writer = new StreamWriter(fileName, false))
            {
                // Serialise text
                string stringifiedText = JsonConvert.SerializeObject(list);

                // Write to file
                writer.WriteLine(stringifiedText);

                writer.Close();
            }
        }
        #endregion

        // Fixing this to work for difference, left off here with current tabs open
        // write specific methods, rather than generic
        /*
        public static double FindWeightDifferenceBetween()
        {
            MyUtilites utils = new MyUtilites();

            // double difference = utils.FindDifferenceBetween(, compareWith);

            return difference;
        }
        */

    }
}
