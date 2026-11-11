using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] public List<State> states;

    protected State currentState;

    public void UpdateStateMachine() {
        currentState.UpdateState();
    }

    public State GetCurrentState() {
        return currentState;
    }

    public void SwitchState<aState>()  {
        foreach(State state in states) {
            if(state.GetType() == typeof(aState)) {
                currentState.ExitState();
                currentState = state;
                currentState.EnterState();
            }
        }
    }
    
}
