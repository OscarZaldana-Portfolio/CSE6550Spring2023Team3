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
        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.Intro)
        {

            OnPlayAnimation("BugsyIntroScene");
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MainMenu)
        {
            InvokeRepeating("playMainMenuAnim", 0.0f, 10.0f);
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationPuzzle)
        {
            InvokeRepeating("playMultiplicationPuzzleAnim", 0.0f, 10.0f);
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationFun)
        {
            InvokeRepeating("playMultiplicationFunAnim", 0.0f, 10.0f);
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationQuiz)
        {
            InvokeRepeating("playMultiplicationQuizAnim", 0.0f, 10.0f);
        }

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationPractice)
        {
            InvokeRepeating("playMultiplicationPracticeAnim", 0.0f, 10.0f);
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

    public void playMainMenuAnim()
    {
        OnPlayAnimation("MainMenuScene");
    }

    public void playMultiplicationPuzzleAnim()
    {
        OnPlayAnimation("MultiplicationPuzzleScene");
    }

    public void playMultiplicationFunAnim()
    {
        OnPlayAnimation("MultiplicationFunScene");
    }

    public void playMultiplicationQuizAnim()
    {
        OnPlayAnimation("MultiplicationQuizScene");
    }

    public void playMultiplicationPracticeAnim()
    {
        OnPlayAnimation("MultiplicationPracticeScene");
    }
}
