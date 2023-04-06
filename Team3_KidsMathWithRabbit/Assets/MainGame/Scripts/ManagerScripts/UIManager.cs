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
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.Instance.gameStates == GameManager.GameStates.Transition)
        //{

        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //GameManager.Instance.gameStates = GameManager.GameStates.Transition;
        }
    }
}
