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


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
       if((GameManager.Instance.getNextState() == GameManager.GameStates.MainMenu && GameManager.Instance.getPreviousState() == GameManager.GameStates.Intro) || GameManager.Instance.getCurrentState() == GameManager.GameStates.Intro)
        {
            bugsy.GetComponent<Animator>().Play("IntroBugsy");
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
}
