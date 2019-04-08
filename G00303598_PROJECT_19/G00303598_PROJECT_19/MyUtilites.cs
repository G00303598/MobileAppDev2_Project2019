using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    class MyUtilites
    {
        // Global Contant Strings
        public const String FITNESS_OUTPUT_SAVE_FILE = "localFitnessInfo.json";

        // Find difference between two values
        public double FindDifferenceBetween(double compareTo, double compareWith)
        {
            double difference;

            difference = compareTo - compareWith;

            return difference;
        }
    }
}
