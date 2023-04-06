using System.Collections;
using System.Collections.Generic;
//  using Unity.VisualScripting;
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
    //public GameStates gameStates { get; set; }
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
            stateSO.States = GameStates.MainMenu;
        }


        if(stateSO == null)
        {
            stateSO.States = GameStates.MainMenu;
        }
        prevState = stateSO.States;

        //DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        Debug.Log(stateSO.States);
    }

    private void Update()
    {
        if(prevState != stateSO.States)
        {
            if(stateSO.States == GameStates.MainMenu)
            {
                MainMenuTransition();
            }
            else if (stateSO.States == GameStates.MultiplicationPuzzle)
            {
                MultiplicationPuzzleTransition();
            }
            else if (stateSO.States == GameStates.MultiplicationFun)
            {
                MultiplicationFunTransition();
            }
            else if (stateSO.States == GameStates.MultiplicationQuiz)
            {
                MultiplicationQuizTransition();
            }
            else if (stateSO.States == GameStates.MultiplicationPractice)
            {
                MultiplicationPracticeTransition();
            }
            prevState = stateSO.States;
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
            stateSO.States = GameStates.MainMenu;
        }
        else if(state == "MultiplicationPuzzle"){
            stateSO.States = GameStates.MultiplicationPuzzle;
        }
        else if(state == "MultiplicationFun"){
            stateSO.States = GameStates.MultiplicationFun;
        }
        else if(state == "MultiplicationQuiz"){
            stateSO.States = GameStates.MultiplicationQuiz;
        }
        else if(state == "MultiplicationPractice"){
            stateSO.States = GameStates.MultiplicationPractice;
        }
    }

    public GameStates getState()
    {
        return stateSO.States;
    }


}
