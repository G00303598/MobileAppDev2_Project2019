using G00303598_PROJECT_19;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using Utils;

namespace G00303598_PROJECT_19
{
    public class FitnessInfo : BaseViewModel
    {
        #region Properties 
        public DateTime DateToStore { get; set; }
        public double CurrentWeight { get; set; }
        public double PreviousWeight { get; set; }
        public double GoalWeight { get; set; }
        public double CaloriesIn { get; set; }
        public double CaloriesInGoal { get; set; }
        public double WaterDrank { get; set; }
        public double DistanceRan { get; set; }
        public string Comment { get; set; }
        #endregion

        #region Contructors
        // Default contructor
        public FitnessInfo()
        {

        }

        public FitnessInfo(DateTime dateToStore, double currentWeight, double previousWeight, double goalWeight, double caloriesIn, double caloriesInGoal, double waterDrank, double distanceRan, string comment)
        {
            DateToStore = dateToStore;
            CurrentWeight = currentWeight;
            PreviousWeight = previousWeight;
            GoalWeight = goalWeight;
            CaloriesIn = caloriesIn;
            CaloriesInGoal = caloriesInGoal;
            WaterDrank = waterDrank;
            DistanceRan = distanceRan;
            Comment = comment;
        }
        #endregion
    }
}
