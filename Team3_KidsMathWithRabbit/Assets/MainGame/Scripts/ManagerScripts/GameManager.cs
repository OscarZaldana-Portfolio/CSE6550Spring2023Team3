using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public UIManager UIManager { get; private set; }

    [SerializeField]
    private StateSO stateSO;
    public float transitionTime = 10.0f;
    string next;

    public enum GameStates{
        Intro,
        MainMenu,
        MultiplicationPuzzle,
        MultiplicationFun,
        MultiplicationQuiz,
        MultiplicationPractice,
        Transition
    }

    private void Awake(){
        //Check to see if there is another existance of this object
        if(Instance != null && Instance != this){
            Destroy(this);
            return;
        }

        Instance = this;
        AudioManager = GetComponentInChildren<AudioManager>();
        UIManager = GetComponentInChildren<UIManager>();

        if (SceneManager.GetActiveScene().name == "IntroLoadScene")
        {
            stateSO.PrevState = GameStates.Intro;
            stateSO.CurrentState = GameStates.Intro;
            stateSO.NextState = GameStates.Intro;
        }
    }

    private void Update()
    {
        if(stateSO.CurrentState == GameStates.Transition)
        {
            StartCoroutine(Transition());
        }
    }

    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(transitionTime);
        stateSO.CurrentState = stateSO.NextState;
        SceneManager.LoadScene(next);
    }

    public void changeState(string state)
    {
        if(state == "MainMenu"){
            stateSO.PrevState = stateSO.CurrentState;
            next = state;
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MainMenu;
        }
        else if(state == "Multiplication Puzzle"){
            next = state;
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MultiplicationPuzzle;
        }
        else if(state == "Multiplication Fun"){
            next = state;
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MultiplicationFun;
        }
        else if(state == "Multiplication Quiz"){
            next = state;
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MultiplicationQuiz;
        }
        else if(state == "Multiplication Practice"){
            next = state;
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MultiplicationPractice;
        }
    }

    public GameStates getCurrentState(){
        return stateSO.CurrentState;
    }
    public GameStates getPreviousState()
    {
        return stateSO.PrevState;
    }
    public GameStates getNextState()
    {
        return stateSO.NextState;
    }


}
