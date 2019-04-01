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
        #region Accessors + Mutators + Member 
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
        // 8 Param Constructor
        public FitnessInfo(double currentWeight, double previousWeight, double goalWeight, double caloriesIn, double caloriesInGoal, double waterDrank, double distanceRan, string comment)
        {
            CurrentWeight = currentWeight;
            PreviousWeight = previousWeight;
            GoalWeight = goalWeight;
            CaloriesIn = caloriesIn;
            CaloriesInGoal = caloriesInGoal;
            WaterDrank = waterDrank;
            DistanceRan = distanceRan;
            Comment = comment;
        }
        // 8 Param Contructor
        #endregion
    }
}
