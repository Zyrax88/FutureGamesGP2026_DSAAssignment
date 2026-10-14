using Environment.Tasks;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private Task loginTask = null; // Put your stack/queue here :)

        public void OnInteract() {
            Debug.Log("Executing task");
            loginTask.Execute();
        }
    }
}
