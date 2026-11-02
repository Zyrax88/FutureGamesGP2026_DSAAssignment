using UnityEngine;

public class UISCRIPT : MonoBehaviour
{

    [SerializeField] GameObject AppUI;

    public enum ComputerState
    {
      AppOpen = 1,
      Desktop = 2,
    }

    private ComputerState state;

    public void Update() {
        switch(state) {
            case ComputerState.AppOpen:


                break;
            case ComputerState.Desktop:



                break;
            default:
                break;
        }
    }

    public void SwitchState(ComputerState aState) {
        state = aState;
        AppUI.SetActive(state == ComputerState.AppOpen);
    }
    public void SwitchState(int index) {
        state = (ComputerState)index;
        AppUI.SetActive(state == ComputerState.AppOpen);
    }
}
