﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using Utils;

namespace G00303598_PROJECT_19
{
    class FitnessInfoViewModel : BaseViewModel
    {
        #region Accessors + Mutators + Member variables
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
        public static ObservableCollection<FitnessInfo> ReadLocalFitnessData()
        {
            // TODO: Change to type T to make generic
            // TODO: Make txt files + json info 
            // TODO: Implemnt MyUtilities
            ObservableCollection<FitnessInfo> list = new ObservableCollection<FitnessInfo>();

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
                // TODO: Write trace file? 
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;

                // Need stream of data to read from
                // TODO: Make data folder + populate json
                Stream stream = assembly.GetManifestResourceStream("G00303598_PROJECT_19.Data.myFitnessInfo.txt");

                using (var reader = new StreamReader(stream))
                {
                    fileData = reader.ReadToEnd(); // Reads everything out from file
                }
            }
            //deserialise line here
            list = JsonConvert.DeserializeObject<ObservableCollection<FitnessInfo>>(fileData);

            return list;
        }

        public static void SaveLocaFitnessData(ObservableCollection<FitnessInfo> list)
        {
            // Path name
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // File name
            string fileName = Path.Combine(path, MyUtilites.FITNESS_OUTPUT_SAVE_FILE);

            // Stream writer --> False: Always overwrite file
            using (var writer = new StreamWriter(fileName, false))
            {
                // Serialise text
                string stringifiedText = JsonConvert.SerializeObject(list);

                // Write to file
                writer.WriteLine(stringifiedText);
            }
        }
        #endregion
    }
}