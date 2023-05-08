using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MultiplicationPuzzle : MonoBehaviour
{
    public Animator reverseCarrot;
    int[] slotsA = new int[5];
    int numCorrect = 0;
    public GameObject leftOperand;
    public GameObject operation;
    public GameObject rightOperand;
    public GameObject equalOperation;
    public GameObject expression;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;
    public GameObject choice5;
    public GameObject nextButton;
    public GameObject backGroundImage;
    public Canvas canv1;
    public Canvas canv2;

    float dis1;
    float dis2;
    float dis3;
    float dis4;
    float dis5;

    List<string> response = new List<string>();

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
        nextButton.SetActive(false);
        setText();  
        setChoices();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(choice1!= null) { inRightSpot(choice1); }
        if(choice2!= null) { inRightSpot(choice2); }
        if(choice3!= null) { inRightSpot(choice3); }
        if(choice4!= null) { inRightSpot(choice4); }
        if(choice5!= null) { inRightSpot(choice5); }
        AllCorrect();
    }

    public void setAnswers()
    {
        leftOperand.GetComponentInChildren<Slots>().ChooseNumber();
        rightOperand.GetComponentInChildren<Slots>().ChooseNumber();
        expression.GetComponentInChildren<Slots>().answerNumber = leftOperand.GetComponentInChildren<Slots>().answerNumber * rightOperand.GetComponentInChildren<Slots>().answerNumber;
    }

    public void setText()
    {
        //Randomize the values
        setAnswers();
        //Set the text to match the values
        leftOperand.GetComponentInChildren<Slots>().SetText();
        operation.GetComponentInChildren<Slots>().answerText = "X";
        rightOperand.GetComponentInChildren<Slots>().SetText();
        equalOperation.GetComponentInChildren<Slots>().answerText = "=";
        expression.GetComponentInChildren<Slots>().SetText();
        //Allow buttons to be moved to slots
        leftOperand.GetComponentInChildren<Slots>().slotAccepting = true;
        operation.GetComponentInChildren<Slots>().slotAccepting = true;
        rightOperand.GetComponentInChildren<Slots>().slotAccepting = true;
        equalOperation.GetComponentInChildren<Slots>().slotAccepting = true;
        expression.GetComponentInChildren<Slots>().slotAccepting = true;
        //Set the starting color
        leftOperand.GetComponentInChildren<Slots>().SetTextColor("#016937");
        operation.GetComponentInChildren<Slots>().SetTextColor("#016937");
        rightOperand.GetComponentInChildren<Slots>().SetTextColor("#016937");
        equalOperation.GetComponentInChildren<Slots>().SetTextColor("#016937");
        expression.GetComponentInChildren<Slots>().SetTextColor("#016937");
        //Set the back image
        leftOperand.GetComponentInChildren<Image>().enabled = true;
        operation.GetComponentInChildren<Image>().enabled = true;
        rightOperand.GetComponentInChildren<Image>().enabled = true;
        equalOperation.GetComponentInChildren<Image>().enabled = true;
        expression.GetComponentInChildren<Image>().enabled = true;
    }

    private void addResponse()
    {
        response.Add(leftOperand.GetComponentInChildren<Slots>().answerText);
        response.Add(operation.GetComponentInChildren<Slots>().answerText);
        response.Add(rightOperand.GetComponentInChildren<Slots>().answerText);
        response.Add(equalOperation.GetComponentInChildren<Slots>().answerText);
        response.Add(expression.GetComponentInChildren<Slots>().answerText);
    }

    public static void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void setChoices()
    {
        addResponse();
        Shuffle(response);
        //set text of choices
        choice1.GetComponentInChildren<DragButton>().choiceText = response[0];
        choice2.GetComponentInChildren<DragButton>().choiceText = response[1];
        choice3.GetComponentInChildren<DragButton>().choiceText = response[2];
        choice4.GetComponentInChildren<DragButton>().choiceText = response[3];
        choice5.GetComponentInChildren<DragButton>().choiceText = response[4];
        //Allow buttons to be clickable
        choice1.GetComponentInChildren<DragButton>().clickable = true;
        choice2.GetComponentInChildren<DragButton>().clickable = true;
        choice3.GetComponentInChildren<DragButton>().clickable = true;
        choice4.GetComponentInChildren<DragButton>().clickable = true;
        choice5.GetComponentInChildren<DragButton>().clickable = true;
        response.Clear();
    }

    void inRightSpot(GameObject choice)
    {
        if (choice.GetComponent<DragButton>().beingGrabbed == true)
        {
            dis1 = Vector2.Distance(leftOperand.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            dis2 = Vector2.Distance(operation.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            dis3 = Vector2.Distance(rightOperand.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            dis4 = Vector2.Distance(equalOperation.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            dis5 = Vector2.Distance(expression.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

            CheckSlot(dis1, dis2, dis3, dis4, dis5, choice);
        }
        else
        {
            if(choice.GetComponent<DragButton>().correct == true)
            {
                choice.GetComponent<DragButton>().correct = false;
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
                if(choice.GetComponent<DragButton>().slotSetNumber == 1)
                {
                    leftOperand.GetComponent<Slots>().CorrectSlot();
                    numCorrect++;
                }
                else if (choice.GetComponent<DragButton>().slotSetNumber == 2)
                {
                    operation.GetComponent<Slots>().CorrectSlot();
                    numCorrect++;
                }
                else if (choice.GetComponent<DragButton>().slotSetNumber == 3)
                {
                    rightOperand.GetComponent<Slots>().CorrectSlot();
                    numCorrect++;
                }
                else if (choice.GetComponent<DragButton>().slotSetNumber == 4)
                {
                    equalOperation.GetComponent<Slots>().CorrectSlot();
                    numCorrect++;
                }
                else if (choice.GetComponent<DragButton>().slotSetNumber == 5)
                {
                    expression.GetComponent<Slots>().CorrectSlot();
                    numCorrect++;
                }
                choice.GetComponent<DragButton>().slotSetNumber = 0;
            }
        }
    }


    void CheckSlot(float dis1, float dis2, float dis3, float dis4, float dis5, GameObject choice)
    {
        if(dis1 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == leftOperand.GetComponent<Slots>().answerText)
            {
                if (leftOperand.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = leftOperand.GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 1;
                    
                }
            }
            else
            {
                if (leftOperand.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }                  
            }
        }
        else if (dis2 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == operation.GetComponent<Slots>().answerText)
            {
                if (operation.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = operation.GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 2;
                }
            }
            else
            {
                if (operation.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }
            }
        }
        else if (dis3 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == rightOperand.GetComponent<Slots>().answerText)
            {
                if (rightOperand.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = rightOperand.GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 3;
                }
            }
            else
            {
                if (rightOperand.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }
            }
        }
        else if (dis4 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == equalOperation.GetComponent<Slots>().answerText)
            {
                if (equalOperation.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = equalOperation.GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 4;
                }
            }
            else
            {
                if (equalOperation.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }
            }
        }
        else if (dis5 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == expression.GetComponent<Slots>().answerText)
            {
                if (expression.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = expression.GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 5;
                }
            }
            else
            {
                if (expression.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }
            }
        }
        else
        {
            choice.GetComponent<DragButton>().isInCorrectSpot = false;
            choice.GetComponent<DragButton>().atWrongNumber = false;
            choice.GetComponent<DragButton>().slotNumber = 0;
        }
    }

    void AllCorrect()
    {
        if (numCorrect == 5)
        {
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }
    }

    public void imagesOff()
    {
        backGroundImage.GetComponent<SpriteRenderer>().enabled = false;
        canv1.GetComponent<Canvas>().enabled = false;
        canv2.GetComponent<Canvas>().enabled = false;
    }

    public void imagesOn()
    {
        backGroundImage.GetComponent<SpriteRenderer>().enabled = true;
        canv1.GetComponent<Canvas>().enabled = true;
        canv2.GetComponent<Canvas>().enabled = true;
        choice1.GetComponent<DragButton>().PlayAnim("Choice1Intro");
        choice2.GetComponent<DragButton>().PlayAnim("Choice2Intro");
        choice3.GetComponent<DragButton>().PlayAnim("Choice3Intro");
        choice4.GetComponent<DragButton>().PlayAnim("Choice4Intro");
        choice5.GetComponent<DragButton>().PlayAnim("Choice5Intro");
    }


    public void ResetScene()
    {
        nextButton.SetActive(false); 
        setText();
        setChoices();
        setButton();
        numCorrect = 0;
    }

    void setButton()
    {
        choice1.GetComponent<DragButton>().ResetChoices();
        choice2.GetComponent<DragButton>().ResetChoices();
        choice3.GetComponent<DragButton>().ResetChoices();
        choice4.GetComponent<DragButton>().ResetChoices();
        choice5.GetComponent<DragButton>().ResetChoices();
    }
}
