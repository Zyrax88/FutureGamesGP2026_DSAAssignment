using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;


namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Searching Task", menuName = "Searching task")]   
    public class SearchingTask : Task {

        [SerializeField] private ReadFileTask readFileTask;

        public override void Execute(GameObject gameObject = null) {

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            Utils.SearchingUtils.BinarySearch(readFileTask.employees, new DateTime(2234, 08, 09, 22, 13, 17), SearchingUtils.SearchingCriteria.lastEntrance);
            stopwatch.Stop();

            Debug.Log("1 binary search took: " + stopwatch.Elapsed.TotalMilliseconds * 1000000 + "ns");
            stopwatch.Reset();

            double[] binarysearchTimes = new double[1000];

            for(int i = 0;  i < binarysearchTimes.Length; i++) {
                stopwatch.Start();
                Utils.SearchingUtils.BinarySearch(readFileTask.employees, new DateTime(2234, 08, 09, 22, 13, 17), SearchingUtils.SearchingCriteria.lastEntrance);
                binarysearchTimes[i] = stopwatch.Elapsed.TotalMilliseconds * 1000000;
                stopwatch.Reset();
            }

            double total = 0d;

            foreach(double times in binarysearchTimes) {
                total += times;
            }

            Debug.Log("Average binary search took:" + total/binarysearchTimes.Length + "ns");


            Debug.Log("Binary Searching last entrance");

            int low = Array.IndexOf(readFileTask.employees, Utils.SearchingUtils.BinarySearch(readFileTask.employees, new DateTime(2234, 08, 09, 22, 13, 17), SearchingUtils.SearchingCriteria.lastEntrance));

            int high = Array.IndexOf(readFileTask.employees, Utils.SearchingUtils.BinarySearch(readFileTask.employees, new DateTime(2234, 08, 09, 23, 53, 01), SearchingUtils.SearchingCriteria.lastEntrance));

            List<EmployeesData.Employee> suspects = new List<EmployeesData.Employee>();

            for(int i = low; i <= high; i++) {
                suspects.Add(readFileTask.employees[i]);
            }   

            Helpers.SortingUtils.MergeSort(readFileTask.employees, Helpers.SortingUtils.SortingCriteria.employeeLastExit);

            int low2 = Array.IndexOf(readFileTask.employees, Utils.SearchingUtils.BinarySearch(readFileTask.employees, new DateTime(2234, 08, 09, 19, 15, 48), SearchingUtils.SearchingCriteria.lastExit));

            int high2 = Array.IndexOf(readFileTask.employees, Utils.SearchingUtils.BinarySearch(readFileTask.employees, new DateTime(2234, 08, 09, 22, 14, 54), SearchingUtils.SearchingCriteria.lastExit));

            for(int i = low2; i <= high2; i++) {
                suspects.Add(readFileTask.employees[i]);
            }

            foreach(EmployeesData.Employee e in suspects) {
                Debug.Log($"{e.name} ID:{e.employeeId} Entrance Time {e.lastEntranceInEngineRoom} Last Exit {e.lastExitFromEngineRoom}");
            }




        }
    }
}
