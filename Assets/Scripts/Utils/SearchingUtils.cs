using Environment;
using System.Collections.Generic;
using System;
using static EmployeesData;

namespace Utils {
    public static class SearchingUtils {

        public enum SearchingCriteria {
            Name,
            ID,
            lastEntrance,
            lastExit
        }

        public struct StoredEmployee {
            public Employee employee;
            public TimeSpan differenceTimeSpan;

            public DateTime lastEntered;

            public DateTime lastExit;
        }

        public static Employee BinarySearch<T>(Employee[] inArray, T match, SearchingCriteria inCriteria) {
            int low = 0;
            int high = inArray.Length - 1;

            bool comparison1;
            bool comparison2;

            while(low <= high) {
                int median = low + (high - low) / 2;
                SwitchCheck(out comparison1, out comparison2, inCriteria, inArray, median, match);
               

                if(comparison1) {
                    return inArray[median];
                }

                if(comparison2) {
                    low = median + 1;
                }
                else {
                    high = median - 1;
                }

            }
            Employee tempemp = new Employee();
            tempemp.name = "Unknown Employee";
            return tempemp;
        }

        /// <summary>
        ///  Summary:
        ///     Binarysearches an array of type Employee[] and returns the closest value to the match. DateTime
        /// </summary>
        public static List<Employee> BinarySearch2(Employee[] inArray, DateTime match, SearchingCriteria inCriteria) {
            int index = 0;
            int low = 0;
            int high = inArray.Length - 1;

            bool comparison1;
            bool comparison2;

            StoredEmployee[] StoredEmployees = new StoredEmployee[inArray.Length];

            while(low <= high) {
                int median = low + (high - low) / 2;
                
                SwitchCheck(out comparison1, out comparison2, inCriteria, inArray, median, match);

                if(comparison1) {
                    List<Employee> temp = new List<Employee>();
                    temp.Add(inArray[median]);
                    return temp;
                }

                if(comparison2) {
                    low = median + 1;
                }
                else {
                    high = median - 1;
                }

                if(inCriteria==SearchingCriteria.lastEntrance) {
                    StoredEmployees[index].differenceTimeSpan = DateTime.ParseExact(inArray[median].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) - match;
                    StoredEmployees[index].employee = inArray[median];
                    StoredEmployees[index].lastEntered = DateTime.ParseExact(inArray[median].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    StoredEmployees[index].lastExit = DateTime.ParseExact(inArray[median].lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                else if(inCriteria==SearchingCriteria.lastExit) {
                    StoredEmployees[index].differenceTimeSpan = DateTime.ParseExact(inArray[median].lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) - match;
                    StoredEmployees[index].employee = inArray[median];
                    StoredEmployees[index].lastEntered = DateTime.ParseExact(inArray[median].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    StoredEmployees[index].lastExit = DateTime.ParseExact(inArray[median].lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                index++;

            }

            HashMap hashMap = new HashMap(StoredEmployees);

            return hashMap.GetClosestValues();
        }

        private static void SwitchCheck<T>(out bool comparison1, out bool comparison2, SearchingCriteria inCriteria, Employee[] inArray, int median, T match) {
            switch(inCriteria) {
                case SearchingCriteria.Name:
                    comparison1 = inArray[median].name.Equals(match);
                    comparison2 = inArray[median].name.CompareTo(match) < 0;
                    break;
                case SearchingCriteria.ID:
                    comparison1 = inArray[median].employeeId.Equals(match);
                    comparison2 = inArray[median].employeeId.CompareTo(match) < 0;
                    break;
                case SearchingCriteria.lastEntrance:

                    DateTime entranceTime = DateTime.ParseExact(inArray[median].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    comparison1 = entranceTime.Equals(match);
                    comparison2 = entranceTime.CompareTo(match) < 0;
                    break;

                case SearchingCriteria.lastExit:
                    DateTime exitTime = DateTime.ParseExact(inArray[median].lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    comparison1 = exitTime.Equals(match);
                    comparison2 = exitTime.CompareTo(match) < 0;
                    break;
                default:
                    comparison1 = false;
                    comparison2  = false;
                    break;
            }
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
