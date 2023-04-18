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
            stateSO.PrevState = GameStates.MainMenu;
            stateSO.CurrentState = GameStates.MainMenu;
            stateSO.NextState = GameStates.MainMenu;
        }

        if(stateSO == null)
        {
            stateSO.PrevState = GameStates.MainMenu;
            stateSO.CurrentState = GameStates.MainMenu;
            stateSO.NextState = GameStates.MainMenu;
        }

        //DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(stateSO.CurrentState == GameStates.Transition)
        {
            StartCoroutine(Transition());
        }



        //if(stateSO.CurrentState != stateSO.NextState)
        //{
        //    if(stateSO.CurrentState == GameStates.MainMenu)
        //    {
        //        MainMenuTransition();
        //    }
        //    else if (stateSO.CurrentState == GameStates.MultiplicationPuzzle)
        //    {
        //        MultiplicationPuzzleTransition();
        //    }
        //    else if (stateSO.CurrentState == GameStates.MultiplicationFun)
        //    {
        //        MultiplicationFunTransition();
        //    }
        //    else if (stateSO.CurrentState == GameStates.MultiplicationQuiz)
        //    {
        //        MultiplicationQuizTransition();
        //    }
        //    else if (stateSO.CurrentState == GameStates.MultiplicationPractice)
        //    {
        //        MultiplicationPracticeTransition();
        //    }
        //}
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

    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(transitionTime);
        stateSO.CurrentState = stateSO.NextState;
        SceneManager.LoadScene(next);
    }

    public void changeState(string state)
    {
        if(state == "MainMenu"){
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


}
