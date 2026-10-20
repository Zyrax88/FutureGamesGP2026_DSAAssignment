using Environment.Tasks;
using Utils;
using System;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private Task loginTask = null; // Put your stack/queue here :)

        [SerializeField] private JsonReader jsonReader;

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
