using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform leftBarrier;
    public RectTransform rightBarrier;
    public RectTransform bigCloud;
    public RectTransform mediumCloud;
    public RectTransform smallCloud;
    public GameObject bugsy;

    public AnimationList animList;

    private void Awake()
    {
        
    }

    public void OnPlayAnimation(string animationName)
    {
        bugsy.GetComponent<Animator>().Play(animList.GetClipFromName(animationName).name);
    }

    // Start is called before the first frame update
    void Start()
    {
        if ((GameManager.Instance.getNextState() == GameManager.GameStates.MainMenu && GameManager.Instance.getPreviousState() == GameManager.GameStates.Intro) || GameManager.Instance.getCurrentState() == GameManager.GameStates.Intro)
        {
            OnPlayAnimation("BugsyIntroScene");
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MainMenu)
        {
            InvokeRepeating( "MainMenuScene", 0.0f, 10.0f);
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationPuzzle)
        {
            //InvokeRepeating("playMainMenuAnim", 0.0f, 10.0f);
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationFun)
        {
            InvokeRepeating("MultiplicationFun", 0.0f, 10.0f);
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationQuiz)
        {
            //InvokeRepeating("playMainMenuAnim", 0.0f, 10.0f);
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationPractice)
        {
            //InvokeRepeating("playMainMenuAnim", 0.0f, 10.0f);
        }
    }

    public void OnCorrectSolution()
    {
        bugsy.GetComponent<Animator>().Play("Correct");
    }
    public void OnInCorrectSolution()
    {
        bugsy.GetComponent<Animator>().Play("NotCorrect");
    }

    void playMainMenuAnim()
    {
        OnPlayAnimation("MainMenuScene");
    }



}
