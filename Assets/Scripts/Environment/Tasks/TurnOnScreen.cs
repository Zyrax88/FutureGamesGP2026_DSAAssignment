using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "TurnOnScreen", menuName = "Turn On or Off Screen Task")]
    public class TurnOnScreenTask : Task {
        public override void Execute(GameObject computerScreen = null) {
            computerScreen.SetActive(!computerScreen.activeInHierarchy);
        }
    }
}
