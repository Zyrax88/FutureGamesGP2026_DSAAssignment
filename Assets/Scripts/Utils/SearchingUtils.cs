using Environment;
using System;
using UnityEngine;
using static Environment.Computer;

namespace Utils {
    public class SearchingUtils {
        public static Employee BinarySearch(Employee[] inArray, DateTime value) {
            int low = 0;
            int high = inArray.Length - 1;

            while(low <= high) {
                int median = low + (high - low) / 2;
                DateTime parsedTime = DateTime.ParseExact(inArray[median].lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                if(parsedTime.Equals(value)) {
                    return inArray[median];
                }

                if(parsedTime.CompareTo(value) < 0) {
                    low = median + 1;
                }
                else {
                    high = median - 1;
                }

            }
            Employee tempEmp = new Employee();
            tempEmp.name = "No employees found";
            return tempEmp;
        }

        public static int LinearSearch<T>(T[] inArray, T value)
        {
            for(int i = 0; i < inArray.Length; i++) {
                if(inArray[i].Equals(value)) {
                    return i;
                }
            }
            return -1;
        }
    }
}
