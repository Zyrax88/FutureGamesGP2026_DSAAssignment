using UnityEngine;
using Utils;
using static Environment.Computer;


namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "ReadFile Task", menuName = "ReadFile task")]   
    public class ReadFileTask : Task {

        [SerializeField] private JsonReader _reader;

        public override void Execute() {
            Employee[] employees = _reader.returnJsonObject<EmployeesArray>().employees;

            foreach(Employee employee in employees) {
                Debug.Log($"Employee name: {employee.name} \nEmployee ID: {employee.employeeId} \nHas Engine Room Clerance {(employee.hasEngineRoomClearance ? "Yes" : "No")} \n" +
                    $"Last entered the engine room: {employee.lastEntranceInEngineRoom} \nLast exit from engine room: {employee.lastExitFromEngineRoom}");
            }
        }
    }
}
