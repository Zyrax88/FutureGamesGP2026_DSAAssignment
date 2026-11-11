using System;
using UnityEngine;

public class EmployeesData {

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

}

