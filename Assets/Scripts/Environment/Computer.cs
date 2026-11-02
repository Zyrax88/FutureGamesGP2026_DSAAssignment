using Environment.Tasks;
using System.Collections.Generic;
using System;
using UnityEngine;
using Utils;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [Header("Tasks")]
        [SerializeField]
        private List<Task> tasksToRun = null;
        [SerializeField]
        private List<Task> shutDownTasks = null;
        Helpers.GenericQueue<Task> genericQueue = null;

        [Header("References")]

        [SerializeField] private GameObject computerScreen;
        [SerializeField] private GameObject computerUI;

        private bool poweredOn = false;

        [Serializable]
        public struct Employee {
            public string name;
            public int employeeId;
            public bool hasEngineRoomClearance;
            public string lastEntranceInEngineRoom;
            public string lastExitFromEngineRoom;
        }

        [Serializable]
        public struct EmployeesArray {
            public Employee[] employees;
        }

        public void Start() {  
            genericQueue = new Helpers.GenericQueue<Task>(tasksToRun);
        }

        public void OnInteract() {
            if(!poweredOn) {

                computerUI.SetActive(true);
                genericQueue.Dequeue().Execute(computerScreen);
                if(genericQueue.GetCount == 0)
                {
                    poweredOn = true;
                    genericQueue = new Helpers.GenericQueue<Task>(shutDownTasks);
                }
            }
            else
            {
                foreach(Task task in shutDownTasks) {
                    genericQueue.Dequeue().Execute(computerScreen);
                }
                if(genericQueue.GetCount == 0) {
                    computerUI.SetActive(false);
                    poweredOn = false;
                    genericQueue = new Helpers.GenericQueue<Task>(tasksToRun);
                }
            }
        }
    }
}
