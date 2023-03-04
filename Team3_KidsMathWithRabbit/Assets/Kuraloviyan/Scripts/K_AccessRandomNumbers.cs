using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class K_AccessRandomNumbers : MonoBehaviour
{
    public TMP_Text rightOperandText;
    public TMP_Text leftOperandText;
    public TMP_Text solutionText;
    public TMP_Text topChoiceText;
    public TMP_Text middleChoiceText;
    public TMP_Text lowerChoiceText;
    public TMP_Text upperChoiceText;

    int level = 1;
    int leftOperand = 0;
    int rightOperand = 0;
    [SerializeField]
    int answer;
    int choice;
    int topChoiceNumber = 0;
    int middleChoiceNumber = 0;
    int lowerChoiceNumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        leftOperand = Random.Range(1, 6);
        rightOperand = Random.Range(1, 6);
        answer = leftOperand * rightOperand;
        choice = Random.Range(1,4);
        
        if (level == 1)
        {
            if (choice == 1)
            {
                topChoiceNumber = answer;
                middleChoiceNumber = Random.Range(1, 26);
                lowerChoiceNumber = Random.Range(1, 26);
                while (middleChoiceNumber == topChoiceNumber || middleChoiceNumber == lowerChoiceNumber)
                {
                    middleChoiceNumber = Random.Range(1, 26);
                }
                while (lowerChoiceNumber == topChoiceNumber || lowerChoiceNumber == middleChoiceNumber)
                {
                    lowerChoiceNumber = Random.Range(1, 26);
                }
            }
            else if (choice == 2)
            {
                middleChoiceNumber = answer;
                topChoiceNumber = Random.Range(1, 26);
                lowerChoiceNumber = Random.Range(1, 26);
                while (topChoiceNumber == middleChoiceNumber || topChoiceNumber == lowerChoiceNumber)
                {
                    topChoiceNumber = Random.Range(1, 26);
                }
                while (lowerChoiceNumber == topChoiceNumber || lowerChoiceNumber == middleChoiceNumber)
                {
                    lowerChoiceNumber = Random.Range(1, 26);
                }
            }
            else if (choice == 3)
            {
                lowerChoiceNumber = answer;
                topChoiceNumber = Random.Range(1, 26);
                middleChoiceNumber = Random.Range(1, 26);
                while (topChoiceNumber == middleChoiceNumber || topChoiceNumber == lowerChoiceNumber)
                {
                    topChoiceNumber = Random.Range(1, 26);
                }
                while (middleChoiceNumber == topChoiceNumber || middleChoiceNumber == lowerChoiceNumber)
                {
                    middleChoiceNumber = Random.Range(1, 26);
                }
            }
        } 

        //display correct Text
        leftOperandText.text = leftOperand.ToString();
        rightOperandText.text = rightOperand.ToString();
        topChoiceText.text = topChoiceNumber.ToString();
        middleChoiceText.text = middleChoiceNumber.ToString();
        lowerChoiceText.text = lowerChoiceNumber.ToString();
        solutionText.text = answer.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//Notes
//int.Parse() is used to take a string and convert it to an int
//.ToString() is used to take an int and make it a string