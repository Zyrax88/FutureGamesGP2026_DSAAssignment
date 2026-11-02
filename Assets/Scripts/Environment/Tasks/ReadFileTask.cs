using System;
using UnityEngine;
using Utils;
using static Environment.Computer;


namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "ReadFile Task", menuName = "ReadFile task")]   
    public class ReadFileTask : Task {

        public Employee[] employees;

        [SerializeField] TextAsset jsonFile;

        public override void Execute(GameObject gameObject = null) {
            Debug.Log("Reading " + jsonFile.name);
            employees = JsonReader.returnJsonObject<EmployeesArray>(jsonFile).employees;
        }

    }
}
