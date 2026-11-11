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

            Debug.Log("Binary Searching last entrance");

            int low = Array.IndexOf(readFileTask.employees, Utils.SearchingUtils.BinarySearch2(readFileTask.employees, new DateTime(2234, 08,09,22,00,00), SearchingUtils.SearchingCriteria.lastEntrance)[0]);

            int high = Array.IndexOf(readFileTask.employees, Utils.SearchingUtils.BinarySearch2(readFileTask.employees, new DateTime(2234,08,09,23,00,00), SearchingUtils.SearchingCriteria.lastEntrance)[0]);

            List<EmployeesData.Employee> suspects = new List<EmployeesData.Employee>();

            for(int i = low; i <= high; i++) {
                suspects.Add(readFileTask.employees[i]);
            }

            Helpers.SortingUtils.MergeSort(readFileTask.employees, Helpers.SortingUtils.SortingCriteria.employeeLastExit);

            int low2 = Array.IndexOf(readFileTask.employees, Utils.SearchingUtils.BinarySearch2(readFileTask.employees, new DateTime(2234, 08, 09, 22, 00, 00), SearchingUtils.SearchingCriteria.lastExit)[0]);

            int high2 = Array.IndexOf(readFileTask.employees, Utils.SearchingUtils.BinarySearch2(readFileTask.employees, new DateTime(2234, 08, 09, 23, 00, 00), SearchingUtils.SearchingCriteria.lastExit)[0]);

            for(int i = low2; i <= high2; i++) {
                suspects.Add(readFileTask.employees[i]);
            }

            foreach(EmployeesData.Employee e in suspects) {
                Debug.Log($"{e.name} ID:{e.employeeId} Entrance Time {e.lastEntranceInEngineRoom} Last Exit {e.lastExitFromEngineRoom}");
            }

            stopwatch.Stop();

            Debug.Log("Searching took " + stopwatch.Elapsed.TotalMilliseconds * 1000000 + " ns");

            stopwatch.Reset();

            Debug.Log("Search Results");



        }
    }
}
