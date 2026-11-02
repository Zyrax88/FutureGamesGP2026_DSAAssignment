using System;
using UnityEngine;
using Utils;
using static Environment.Computer;


namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Sorting Task", menuName = "Sorting task")]   
    public class SortTask : Task {

        [SerializeField] private ReadFileTask readFileTask;

        public override void Execute(GameObject gameObject = null) {

            Employee[] employees = readFileTask.employees;


            DateTime[] lastExitsIntoEngineRoom = new DateTime[employees.Length];

            foreach(Employee employee in employees) {
                Debug.Log($"Employee name: {employee.name} \nEmployee ID: {employee.employeeId} \nHas Engine Room Clerance {(employee.hasEngineRoomClearance ? "Yes" : "No")} \n" +
                    $"Last entered the engine room: {employee.lastEntranceInEngineRoom} \nLast exit from engine room: {employee.lastExitFromEngineRoom}");
            }



            Debug.Log("What would you like to sort?");

            Debug.Log("Sorting employees by their last exit to the engine room");

            Helpers.SortingUtils.MergeSort(employees, Helpers.SortingUtils.SortingCriteria.employeeLastEntrance);

            for(int i = 0; i < employees.Length; i++)
            {
                Debug.Log(employees[i].name + " " + employees[i].lastEntranceInEngineRoom);
            }
        }

    }
}
