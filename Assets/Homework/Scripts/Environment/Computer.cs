using Environment.Tasks;
using Utils;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {

        private GenericQueue<Task> taskQueue = null;

        [Serializable]
        public struct Employee {
            public string name;
            public int employeeId;
            public bool hasEngineRoomClearance;
            public string lastEntranceInEngineRoom;
            public string lastExitFromEngineRoom;
        }

        [Serializable]
        public struct EmployeesArray
        {
            public Employee[] employees;
        }

        public void OnInteract() {

        }
    }
}
