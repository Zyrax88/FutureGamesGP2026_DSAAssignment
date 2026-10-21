using UnityEngine;


namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Login Task", menuName = "Login Task")]   
    public class LoginTask : Task {
        private GameObject computerScreenObj;

        public void Start()
        {
            computerScreenObj = GameObject.FindWithTag("ComputerScreen");
        }

        public override void Execute() {
            computerScreenObj.SetActive(true);
        }
    }
}
