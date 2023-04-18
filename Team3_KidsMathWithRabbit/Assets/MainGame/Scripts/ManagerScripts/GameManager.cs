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
    public int playerHealth = 10;

    [SerializeField]
    private StateSO stateSO;
    public float transitionTime = 10.0f;
    private GameStates prevState;

    public enum GameStates
    {
        MainMenu,
        MultiplicationPuzzle,
        MultiplicationFun,
        MultiplicationQuiz,
        MultiplicationPractice,
        Transition
    }

    public UnityEvent onMainMenuTransition;
    public UnityEvent onMultiplicationPuzzleTransition;
    public UnityEvent onMultiplicationFunTransition;
    public UnityEvent onMultiplicationQuizTransition;
    public UnityEvent onMultiplicationPracticeTransition;
    public UnityEvent onTransition;



    private void Awake(){
        //Check to see if there is another existance of this object
        if(Instance != null && Instance != this){
            Destroy(this);
            return;
        }
        Instance = this;
        AudioManager = GetComponentInChildren<AudioManager>();
        UIManager = GetComponentInChildren<UIManager>();



        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            stateSO.CurrentState = GameStates.MainMenu;
        }


        if(stateSO == null)
        {
            stateSO.CurrentState = GameStates.MainMenu;
        }
        prevState = stateSO.CurrentState;

        //DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        Debug.Log(stateSO.CurrentState);
    }

    private void Update()
    {
        if(prevState != stateSO.CurrentState)
        {
            if(stateSO.CurrentState == GameStates.MainMenu)
            {
                MainMenuTransition();
            }
            else if (stateSO.CurrentState == GameStates.MultiplicationPuzzle)
            {
                MultiplicationPuzzleTransition();
            }
            else if (stateSO.CurrentState == GameStates.MultiplicationFun)
            {
                MultiplicationFunTransition();
            }
            else if (stateSO.CurrentState == GameStates.MultiplicationQuiz)
            {
                MultiplicationQuizTransition();
            }
            else if (stateSO.CurrentState == GameStates.MultiplicationPractice)
            {
                MultiplicationPracticeTransition();
            }
            else if (stateSO.CurrentState == GameStates.Transition)
            {
                MultiplicationPracticeTransition();
            }
            prevState = stateSO.CurrentState;
        }
    }

    void MainMenuTransition()
    {
        onMainMenuTransition.Invoke();
    }

    void MultiplicationPuzzleTransition()
    {
        onMultiplicationPuzzleTransition.Invoke();
    }

    void MultiplicationFunTransition()
    {
        onMultiplicationFunTransition.Invoke();
    }

    void MultiplicationQuizTransition()
    {
        onMultiplicationQuizTransition.Invoke();
    }

    void MultiplicationPracticeTransition()
    {
        onMultiplicationPracticeTransition.Invoke();
    }



    public void changeState(string state)
    {
        if(state == "MainMenu")
        {
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MainMenu;
        }
        else if(state == "MultiplicationPuzzle"){
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MultiplicationPuzzle;
        }
        else if(state == "MultiplicationFun"){
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MultiplicationFun;
        }
        else if(state == "MultiplicationQuiz"){
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MultiplicationQuiz;
        }
        else if(state == "MultiplicationPractice"){
            stateSO.CurrentState = GameStates.Transition;
            stateSO.NextState = GameStates.MultiplicationPractice;
        }
    }

    public GameStates getState()
    {
        return stateSO.CurrentState;
    }


}
