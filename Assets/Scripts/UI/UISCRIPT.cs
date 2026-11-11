using Environment.Tasks;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Utils;
using static EmployeesData;
using static Utils.Helpers.SortingUtils;

public class UISCRIPT : MonoBehaviour {
    [SerializeField] GameObject EyeSharp = null;
    [SerializeField] GameObject searchResultScreen = null;
    List<GameObject> apps = new List<GameObject>();

    [SerializeField] ReadFileTask employeesFile;
    [SerializeField] TextMeshProUGUI employeeNameField;
    [SerializeField] TextMeshProUGUI employeeIDField;
    [SerializeField] TextMeshProUGUI employeeClearenceField;
    [SerializeField] TextMeshProUGUI employeeLastEntranceField;
    [SerializeField] TextMeshProUGUI employeeLastExitField;
    [SerializeField] TextMeshProUGUI employeeSearchMatchText;

    [Header("Tasks")]
    [SerializeField]
    private List<Task> startTasks = null;
    private SearchingTask searchTask = null;

    [SerializeField]
    private List<Task> shutDownTasks = null;
    Helpers.GenericQueue<Task> genericQueue = null;

    [Header("References")]

    private bool isDescending = true;

    public enum ComputerState
    {
      AppOpen = 1,
      Desktop = 2,
    }

    public enum AppID {
        EyeSharp = 0
    }

    private ComputerState state;
    private AppID currentApp;

    private SortingCriteria sortingCriteria;

    private void Start() {
        apps.Add(EyeSharp);
    }

    public void Search(GameObject field) {

        searchResultScreen.SetActive(true);

        Employee foundEmployee = new Employee();

        string inputFieldText = field.GetComponent<TMPro.TMP_InputField>().text;

        switch(field.name) {
            case "Field_Name":
                foundEmployee = SearchingUtils.BinarySearch<string>(employeesFile.employees, inputFieldText, SearchingUtils.SearchingCriteria.Name);
            break;

            case "Field_ID":
                foundEmployee = SearchingUtils.BinarySearch<int>(employeesFile.employees, int.Parse(inputFieldText), SearchingUtils.SearchingCriteria.ID);
                break;

            case "Field_LastEntrance":
                foundEmployee = SearchingUtils.BinarySearch<DateTime>(employeesFile.employees, DateTime.Parse(inputFieldText), SearchingUtils.SearchingCriteria.lastEntrance);
                break;

            case "Field_LastExit":
                foundEmployee = SearchingUtils.BinarySearch<DateTime>(employeesFile.employees, DateTime.Parse(inputFieldText), SearchingUtils.SearchingCriteria.lastExit);
                break;

            default:
                employeeSearchMatchText.text = "Invalid Search";
            break;
        }

        employeeSearchMatchText.text = $"{foundEmployee.name}\nID: {foundEmployee.employeeId}\nHas clearance: {(foundEmployee.hasEngineRoomClearance ? "Yes" : "No")}" +
            $"\nLast entrance to engine room: {foundEmployee.lastEntranceInEngineRoom}\nLast exit from engine room: {foundEmployee.lastExitFromEngineRoom}";
    }

    public void Update() {
        switch(state) {
            case ComputerState.AppOpen:

                switch(currentApp) {
                    case AppID.EyeSharp:
                        EyeSharp.SetActive(true);
                        break;
                    default:
                        break;
                }

                break;
            case ComputerState.Desktop:
                for(int i = 0; i < apps.Count; i++) {
                    apps[i].SetActive(false);
                }
                break;
            default:
                break;
        }
    }

    private void OnEnable() {

    }

    private void Sort() {
        isDescending = !isDescending;

        Helpers.SortingUtils.MergeSort(employeesFile.employees, sortingCriteria, 0, employeesFile.employees.Length-1, isDescending);

        for(int i = 0; i <  employeesFile.employees.Length; i++) { //Clear the Fields
            employeeNameField.text = string.Empty;
            employeeIDField.text = string.Empty;
            employeeClearenceField.text = string.Empty;
            employeeLastEntranceField.text = string.Empty;
            employeeLastExitField.text = string.Empty;
        }

        foreach(Employee e in employeesFile.employees) { //Inserted the sorted values
            employeeNameField.text += e.name + "\n";
            employeeIDField.text += e.employeeId + "\n";
            employeeClearenceField.text += e.hasEngineRoomClearance + "\n";
            employeeLastEntranceField.text += e.lastEntranceInEngineRoom + "\n";
            employeeLastExitField.text += e.lastExitFromEngineRoom + "\n";
        }

    }

    public void SwitchState(ComputerState aState) {
        state = aState;
        EyeSharp.SetActive(state == ComputerState.AppOpen);
    }
    public void SwitchState(int index) {
        state = (ComputerState)index;
        EyeSharp.SetActive(state == ComputerState.AppOpen);
    }

    public void SwitchCriteria(int index) {
        sortingCriteria = (SortingCriteria)index;
        Sort();
    }

    public void SwitchApp(int index) {
        currentApp = (AppID)index;
    }

}
