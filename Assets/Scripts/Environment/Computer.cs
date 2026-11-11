using Environment.Tasks;
using System.Collections.Generic;
using System;
using UnityEngine;
using Utils;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [Header("Tasks")]
        [SerializeField]
        private List<Task> tasksToStart = null;
        [SerializeField]
        private List<Task> shutDownTasks = null;
        Helpers.GenericQueue<Task> genericQueue = null;

        [Header("References")]

        [SerializeField] private GameObject computerScreen;
        [SerializeField] private GameObject computerUI;

        private bool poweredOn = false;

        public void Start() {  
            genericQueue = new Helpers.GenericQueue<Task>(tasksToStart);
        }

        public void OnInteract() {
            if(!poweredOn) {

                foreach(Task t in tasksToStart) {
                    computerUI.SetActive(true);
                    genericQueue.Dequeue().Execute(computerScreen);
                }
                GameManager.instance.SwitchState<ComputerState>();
                poweredOn = true;

                genericQueue = new Helpers.GenericQueue<Task>(shutDownTasks);
            }
            else
            {
                if(genericQueue.GetCount == 1) {
                    foreach(Task task in shutDownTasks) {
                        genericQueue.Dequeue().Execute(computerScreen);
                    }
                    computerUI.SetActive(false);
                    poweredOn = false;
                    GameManager.instance.SwitchState<PlayingState>();
                    genericQueue = new Helpers.GenericQueue<Task>(tasksToStart);
                    return;
                }
                else {
                    foreach(Task task in shutDownTasks) {
                        genericQueue.Dequeue().Execute(computerScreen);
                    }
                    poweredOn = false;
                    genericQueue = new Helpers.GenericQueue<Task>(tasksToStart);
                    return;
                }


            }
        }
    }
}
