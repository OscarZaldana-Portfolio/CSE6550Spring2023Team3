using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class NumberLogic : MonoBehaviour
{
    public UnityEvent onSet;
    public TMP_Text rightOperandText;
    public TMP_Text leftOperandText;
    public TMP_Text solutionText;
    public TMP_Text topChoiceText;
    public TMP_Text middleChoiceText;
    public TMP_Text lowerChoiceText;
    public GameObject leftQuestionSectionPanel;
    public RectTransform leftQuestionRectTransform;
    public GameObject nextButton;
    public GameObject UIButton;

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
        setNumbers();

    }


    public void setNumbers()
    {
        leftOperand = Random.Range(1, 6);
        rightOperand = Random.Range(1, 6);
        answer = leftOperand * rightOperand;
        choice = Random.Range(1, 4);

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
    
    public void reset()
    {
        onSet.Invoke();
        setNumbers();
        NextButtonOff();
        UIButtonOn();
    }
    public void onMultiplicationButtonClick()
    {
        GameManager.Instance.AudioManager.PlaySound("Multiply", 1.0f);

    }
    public void onEqualButtonClick()
    {
        GameManager.Instance.AudioManager.PlaySound("EqualTo", 1.0f);

    }
    public void onLeftOperandClick()
    {
        Debug.Log("val of left operand" + leftOperandText);
        if (leftOperandText)

        {
            Debug.Log("val of left operand" + leftOperandText.text);
            switch (leftOperandText.text)
            {
                
                case "1":
                    GameManager.Instance.AudioManager.PlaySound("One", 1.0f);
                    break;
                case "2":
                    GameManager.Instance.AudioManager.PlaySound("Two", 1.0f);
                    break;
                case "3":
                    GameManager.Instance.AudioManager.PlaySound("Three", 1.0f);
                    break;
                case "4":
                    GameManager.Instance.AudioManager.PlaySound("Four", 1.0f);
                    break;
                case "5":
                    GameManager.Instance.AudioManager.PlaySound("Five", 1.0f);
                    break;
                case "6":
                    GameManager.Instance.AudioManager.PlaySound("Six", 1.0f);
                    break;
                case "7":
                    GameManager.Instance.AudioManager.PlaySound("Seven", 1.0f);
                    break;
                case "8":
                    GameManager.Instance.AudioManager.PlaySound("Eight", 1.0f);
                    break;
                case "9":
                    GameManager.Instance.AudioManager.PlaySound("Nine", 1.0f);
                    break;
            }
        }
    }

    public void onRightOperandClick()
    {
        Debug.Log("val of left operand" + leftOperandText);
        if (rightOperandText)

        {
            Debug.Log("val of left operand" + leftOperandText.text);
            switch (rightOperandText.text)
            {

                case "1":
                    GameManager.Instance.AudioManager.PlaySound("One", 1.0f);
                    break;
                case "2":
                    GameManager.Instance.AudioManager.PlaySound("Two", 1.0f);
                    break;
                case "3":
                    GameManager.Instance.AudioManager.PlaySound("Three", 1.0f);
                    break;
                case "4":
                    GameManager.Instance.AudioManager.PlaySound("Four", 1.0f);
                    break;
                case "5":
                    GameManager.Instance.AudioManager.PlaySound("Five", 1.0f);
                    break;
                case "6":
                    GameManager.Instance.AudioManager.PlaySound("Six", 1.0f);
                    break;
                case "7":
                    GameManager.Instance.AudioManager.PlaySound("Seven", 1.0f);
                    break;
                case "8":
                    GameManager.Instance.AudioManager.PlaySound("Eight", 1.0f);
                    break;
                case "9":
                    GameManager.Instance.AudioManager.PlaySound("Nine", 1.0f);
                    break;
            }
        }
    }
    public void onClickTop()
    {
        Debug.Log("top val " + topChoiceNumber);
        switch (topChoiceNumber)
        {
            case 1:
                GameManager.Instance.AudioManager.PlaySound("One", 1.0f);
                break;
            case 2:
                GameManager.Instance.AudioManager.PlaySound("Two", 1.0f);
                break;
            case 3:
                GameManager.Instance.AudioManager.PlaySound("Three", 1.0f);
                break;
            case 4:
                GameManager.Instance.AudioManager.PlaySound("Four", 1.0f);
                break;
            case 5:
                GameManager.Instance.AudioManager.PlaySound("Five", 1.0f);
                break;
            case 6:
                GameManager.Instance.AudioManager.PlaySound("Six", 1.0f);
                break;
            case 7:
                GameManager.Instance.AudioManager.PlaySound("Seven", 1.0f);
                break;
            case 8:
                GameManager.Instance.AudioManager.PlaySound("Eight", 1.0f);
                break;
            case 9:
                GameManager.Instance.AudioManager.PlaySound("Nine", 1.0f);
                break;
            case 10:
                GameManager.Instance.AudioManager.PlaySound("Ten", 1.0f);
                break;
            case 11:
                GameManager.Instance.AudioManager.PlaySound("Eleven", 1.0f);
                break;
            case 12:
                GameManager.Instance.AudioManager.PlaySound("Twelve", 1.0f);
                break;
            case 13:
                GameManager.Instance.AudioManager.PlaySound("Thirteen", 1.0f);
                break;
            case 14:
                GameManager.Instance.AudioManager.PlaySound("Fourteen", 1.0f);
                break;
            case 15:
                GameManager.Instance.AudioManager.PlaySound("Fifteen", 1.0f);
                break;
            case 16:
                GameManager.Instance.AudioManager.PlaySound("Sixteen", 1.0f);
                break;
            case 17:
                GameManager.Instance.AudioManager.PlaySound("Seventeen", 1.0f);
                break;
            case 18:
                GameManager.Instance.AudioManager.PlaySound("Eighteen", 1.0f);
                break;
            case 19:
                GameManager.Instance.AudioManager.PlaySound("Nineteen", 1.0f);
                break;
            case 20:
                GameManager.Instance.AudioManager.PlaySound("Twenty", 1.0f);
                break;
            case 21:
                GameManager.Instance.AudioManager.PlaySound("TwentyOne", 1.0f);
                break;
            case 22:
                GameManager.Instance.AudioManager.PlaySound("TwentyTwo", 1.0f);
                break;
            case 23:
                GameManager.Instance.AudioManager.PlaySound("TwentyThree", 1.0f);
                break;
            case 24:
                GameManager.Instance.AudioManager.PlaySound("TwentyFour", 1.0f);
                break;
            case 25:
                GameManager.Instance.AudioManager.PlaySound("TwentyFive", 1.0f);
                break;
            case 26:
                GameManager.Instance.AudioManager.PlaySound("TwentySix", 1.0f);
                break;
            case 27:
                GameManager.Instance.AudioManager.PlaySound("TwentySeven", 1.0f);
                break;
            case 28:
                GameManager.Instance.AudioManager.PlaySound("TwentyEight", 1.0f);
                break;
            case 29:
                GameManager.Instance.AudioManager.PlaySound("TwentyNine", 1.0f);
                break;
            case 30:
                GameManager.Instance.AudioManager.PlaySound("Thirty", 1.0f);
                break;
        }
    }
    public void onClickMiddle() { 
        Debug.Log("top val " + middleChoiceNumber);
        switch (middleChoiceNumber)
        {
         
            case 1:
                GameManager.Instance.AudioManager.PlaySound("One", 1.0f);
                break;
            case 2:
                GameManager.Instance.AudioManager.PlaySound("Two", 1.0f);
                break;
            case 3:
                GameManager.Instance.AudioManager.PlaySound("Three", 1.0f);
                break;
            case 4:
                GameManager.Instance.AudioManager.PlaySound("Four", 1.0f);
                break;
            case 5:
                GameManager.Instance.AudioManager.PlaySound("Five", 1.0f);
                break;
            case 6:
                GameManager.Instance.AudioManager.PlaySound("Six", 1.0f);
                break;
            case 7:
                GameManager.Instance.AudioManager.PlaySound("Seven", 1.0f);
                break;
            case 8:
                GameManager.Instance.AudioManager.PlaySound("Eight", 1.0f);
                break;
            case 9:
                GameManager.Instance.AudioManager.PlaySound("Nine", 1.0f);
                break;
            case 10:
                GameManager.Instance.AudioManager.PlaySound("Ten", 1.0f);
                break;
            case 11:
                GameManager.Instance.AudioManager.PlaySound("Eleven", 1.0f);
                break;
            case 12:
                GameManager.Instance.AudioManager.PlaySound("Twelve", 1.0f);
                break;
            case 13:
                GameManager.Instance.AudioManager.PlaySound("Thirteen", 1.0f);
                break;
            case 14:
                GameManager.Instance.AudioManager.PlaySound("Fourteen", 1.0f);
                break;
            case 15:
                GameManager.Instance.AudioManager.PlaySound("Fifteen", 1.0f);
                break;
            case 16:
                GameManager.Instance.AudioManager.PlaySound("Sixteen", 1.0f);
                break;
            case 17:
                GameManager.Instance.AudioManager.PlaySound("Seventeen", 1.0f);
                break;
            case 18:
                GameManager.Instance.AudioManager.PlaySound("Eighteen", 1.0f);
                break;
            case 19:
                GameManager.Instance.AudioManager.PlaySound("Nineteen", 1.0f);
                break;
            case 20:
                GameManager.Instance.AudioManager.PlaySound("Twenty", 1.0f);
                break;
            case 21:
                GameManager.Instance.AudioManager.PlaySound("TwentyOne", 1.0f);
                break;
            case 22:
                GameManager.Instance.AudioManager.PlaySound("TwentyTwo", 1.0f);
                break;
            case 23:
                GameManager.Instance.AudioManager.PlaySound("TwentyThree", 1.0f);
                break;
            case 24:
                GameManager.Instance.AudioManager.PlaySound("TwentyFour", 1.0f);
                break;
            case 25:
                GameManager.Instance.AudioManager.PlaySound("TwentyFive", 1.0f);
                break;
            case 26:
                GameManager.Instance.AudioManager.PlaySound("TwentySix", 1.0f);
                break;
            case 27:
                GameManager.Instance.AudioManager.PlaySound("TwentySeven", 1.0f);
                break;
            case 28:
                GameManager.Instance.AudioManager.PlaySound("TwentyEight", 1.0f);
                break;
            case 29:
                GameManager.Instance.AudioManager.PlaySound("TwentyNine", 1.0f);
                break;
            case 30:
                GameManager.Instance.AudioManager.PlaySound("Thirty", 1.0f);
                break;
        }
    }
    public void onClickLower()
    {
        Debug.Log("top val " + lowerChoiceNumber);
        switch (lowerChoiceNumber)
        {
            case 1:
                GameManager.Instance.AudioManager.PlaySound("One", 1.0f);
                break;
            case 2:
                GameManager.Instance.AudioManager.PlaySound("Two", 1.0f);
                break;
            case 3:
                GameManager.Instance.AudioManager.PlaySound("Three", 1.0f);
                break;
            case 4:
                GameManager.Instance.AudioManager.PlaySound("Four", 1.0f);
                break;
            case 5:
                GameManager.Instance.AudioManager.PlaySound("Five", 1.0f);
                break;
            case 6:
                GameManager.Instance.AudioManager.PlaySound("Six", 1.0f);
                break;
            case 7:
                GameManager.Instance.AudioManager.PlaySound("Seven", 1.0f);
                break;
            case 8:
                GameManager.Instance.AudioManager.PlaySound("Eight", 1.0f);
                break;
            case 9:
                GameManager.Instance.AudioManager.PlaySound("Nine", 1.0f);
                break;
            case 10:
                GameManager.Instance.AudioManager.PlaySound("Ten", 1.0f);
                break;
            case 11:
                GameManager.Instance.AudioManager.PlaySound("Eleven", 1.0f);
                break;
            case 12:
                GameManager.Instance.AudioManager.PlaySound("Twelve", 1.0f);
                break;
            case 13:
                GameManager.Instance.AudioManager.PlaySound("Thirteen", 1.0f);
                break;
            case 14:
                GameManager.Instance.AudioManager.PlaySound("Fourteen", 1.0f);
                break;
            case 15:
                GameManager.Instance.AudioManager.PlaySound("Fifteen", 1.0f);
                break;
            case 16:
                GameManager.Instance.AudioManager.PlaySound("Sixteen", 1.0f);
                break;
            case 17:
                GameManager.Instance.AudioManager.PlaySound("Seventeen", 1.0f);
                break;
            case 18:
                GameManager.Instance.AudioManager.PlaySound("Eighteen", 1.0f);
                break;
            case 19:
                GameManager.Instance.AudioManager.PlaySound("Nineteen", 1.0f);
                break;
            case 20:
                GameManager.Instance.AudioManager.PlaySound("Twenty", 1.0f);
                break;
            case 21:
                GameManager.Instance.AudioManager.PlaySound("TwentyOne", 1.0f);
                break;
            case 22:
                GameManager.Instance.AudioManager.PlaySound("TwentyTwo", 1.0f);
                break;
            case 23:
                GameManager.Instance.AudioManager.PlaySound("TwentyThree", 1.0f);
                break;
            case 24:
                GameManager.Instance.AudioManager.PlaySound("TwentyFour", 1.0f);
                break;
            case 25:
                GameManager.Instance.AudioManager.PlaySound("TwentyFive", 1.0f);
                break;
            case 26:
                GameManager.Instance.AudioManager.PlaySound("TwentySix", 1.0f);
                break;
            case 27:
                GameManager.Instance.AudioManager.PlaySound("TwentySeven", 1.0f);
                break;
            case 28:
                GameManager.Instance.AudioManager.PlaySound("TwentyEight", 1.0f);
                break;
            case 29:
                GameManager.Instance.AudioManager.PlaySound("TwentyNine", 1.0f);
                break;
            case 30:
                GameManager.Instance.AudioManager.PlaySound("Thirty", 1.0f);
                break;
        }
    
    }
    public void NextButtonON()
    {
        nextButton.SetActive(true);
        GameManager.Instance.AudioManager.PlaySound("CorrectAnswer", 1.0f);
        GameManager.Instance.AudioManager.PlaySound("Yaay", 1.0f);
    }
    public void NextButtonOff()
    {
        nextButton.SetActive(false);
    }

    public void UIButtonOn()
    {
        UIButton.SetActive(true);
    }
    public void UIButtonOff()
    {
        UIButton.SetActive(false);
        GameManager.Instance.AudioManager.PlaySound("NextButton", 1.0f);
       /* if (!GameManager.Instance.AudioManager.soundFXSource.isPlaying)
        {
            GameManager.Instance.AudioManager.musicSource.Pause();
        }*/
    }
}

//Notes
//int.Parse() is used to take a string and convert it to an int
//.ToString() is used to take an int and make it a string
