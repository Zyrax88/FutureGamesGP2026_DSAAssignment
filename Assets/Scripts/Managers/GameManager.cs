using UnityEngine;

public class GameManager : StateMachine
{
    public static GameManager instance;

    private void Awake() {
        instance = this;
        currentState = states[0]; // Playing States
    }

    void Update()
    {
        UpdateStateMachine();
    }
}
