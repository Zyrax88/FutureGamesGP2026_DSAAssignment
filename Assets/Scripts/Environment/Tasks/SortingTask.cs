using System;
using UnityEngine;
using Utils;
using static EmployeesData;


namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Sorting Task", menuName = "Sorting task")]   
    public class SortTask : Task {

        [SerializeField] private ReadFileTask readFileTask;

        public override void Execute(GameObject gameObject = null) {

            //foreach(Employee employee in readFileTask.employees) {
            //    Debug.Log($"Employee name: {employee.name} \nEmployee ID: {employee.employeeId} \nHas Engine Room Clerance {(employee.hasEngineRoomClearance ? "Yes" : "No")} \n" +
            //        $"Last entered the engine room: {employee.lastEntranceInEngineRoom} \nLast exit from engine room: {employee.lastExitFromEngineRoom}");
            //}



            Debug.Log("What would you like to sort?");

            Debug.Log("Sorting employees by their last entrance to the engine room");

            Helpers.SortingUtils.MergeSort(readFileTask.employees, Helpers.SortingUtils.SortingCriteria.employeeLastEntrance);

            //for(int i = 0; i < readFileTask.employees.Length; i++)
            //{
            //    Debug.Log(readFileTask.employees[i].name + " " + readFileTask.employees[i].lastEntranceInEngineRoom);
            //}
        }

    }
}
