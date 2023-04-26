using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplicationPuzzle : MonoBehaviour
{
    public Animator carrot;
    public Animator reverseCarrot;
    int[] slotsA = new int[5];
    public int numCorrect = 0;
    public TMP_Text leftOperandText;
    public TMP_Text operationText;
    public TMP_Text rightOperandText;
    public TMP_Text equalOperationText;
    public TMP_Text solutionText;


    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationPuzzle)
        {
            if (GameManager.Instance.getPreviousState() == GameManager.GameStates.MainMenu)
            {
                reverseCarrot.Play("reverseCarrots");
            }
        }
        setAnswers();
        setText();
    }




    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAnswers()
    {
        if (GameManager.Instance.GetLevel() == 1)
        {
            slotsA[0] = Random.Range(1, 6);
            slotsA[2] = Random.Range(1, 6);
            slotsA[4] = slotsA[0] * slotsA[2];
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            slotsA[0] = Random.Range(1, 11);
            slotsA[2] = Random.Range(1, 11);
            slotsA[4] = slotsA[0] * slotsA[2];
        }
        else if (GameManager.Instance.GetLevel() == 3)
        {
            slotsA[0] = Random.Range(1, 20);
            slotsA[2] = Random.Range(1, 20);
            slotsA[4] = slotsA[0] * slotsA[2];
        }
    }

    public void setText()
    {
        leftOperandText.text = slotsA[0].ToString();
        rightOperandText.text = slotsA[2].ToString();
        solutionText.text = slotsA[4].ToString();
    }


}
