using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public IState currentState;
    public MainMenuState mainMenuState = new MainMenuState();

    private void Start()
    {
        ChangeState(mainMenuState);
    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        currentState.OnEnter(this);
    }
}
public interface IState
{
    public void OnEnter(StateManager controller);
    public void UpdateState(StateManager controller);
    public void OnExit(StateManager controller);
}