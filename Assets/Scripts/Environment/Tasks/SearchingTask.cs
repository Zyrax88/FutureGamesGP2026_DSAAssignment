using System;
using UnityEngine;
using Utils;
using static Environment.Computer;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;


namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Searching Task", menuName = "Searching task")]   
    public class SearchingTask : Task {

        [SerializeField] private ReadFileTask readFileTask;

        public override void Execute(GameObject gameObject = null) {
            Debug.Log(Utils.SearchingUtils.BinarySearch(readFileTask.employees, new DateTime(2234, 08, 05, 07, 40, 47)).name);
            int[] array = new int[5] { 0, 1, 2, 2, 3 };
            Debug.Log(Utils.SearchingUtils.LinearSearch<int>(array, 3));
        }

    }
}
