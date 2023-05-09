using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MultiplicationQuiz : MonoBehaviour
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
    public GameObject nextButton;
    public GameObject backGroundImage;
    public Canvas canv1;
    public Canvas canv2;

    float dis1;
    float dis2;
    float dis3;

    List<string> response = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationQuiz)
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
        if (choice1 != null) { inRightSpot(choice1); }
        if (choice2 != null) { inRightSpot(choice2); }
        if (choice3 != null) { inRightSpot(choice3); }

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
        expression.GetComponentInChildren<Slots>().answerText = "?";
        //Allow buttons to be moved to slots
        leftOperand.GetComponentInChildren<Slots>().slotAccepting = false;
        operation.GetComponentInChildren<Slots>().slotAccepting = false;
        rightOperand.GetComponentInChildren<Slots>().slotAccepting = false;
        equalOperation.GetComponentInChildren<Slots>().slotAccepting = false;
        expression.GetComponentInChildren<Slots>().slotAccepting = true;
        //Set the starting color
        leftOperand.GetComponentInChildren<Slots>().SetTextColor("#FAFAFA");
        operation.GetComponentInChildren<Slots>().SetTextColor("#FAFAFA");
        rightOperand.GetComponentInChildren<Slots>().SetTextColor("#FAFAFA");
        equalOperation.GetComponentInChildren<Slots>().SetTextColor("#FAFAFA");
        expression.GetComponentInChildren<Slots>().SetTextColor("#FAFAFA");
        //Set the back image
        leftOperand.GetComponentInChildren<Image>().enabled = false;
        operation.GetComponentInChildren<Image>().enabled = false;
        rightOperand.GetComponentInChildren<Image>().enabled = false;
        equalOperation.GetComponentInChildren<Image>().enabled = false;
        expression.GetComponentInChildren<Image>().enabled = true;
    }

    private void addResponse()
    {
        if (GameManager.Instance.GetLevel() == 1)
        {
            response.Add(Random.Range(0, 6).ToString());
            response.Add(Random.Range(0, 6).ToString());
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            response.Add(Random.Range(0, 11).ToString());
            response.Add(Random.Range(0, 11).ToString());
        }
        else
        {
            response.Add(Random.Range(0, 21).ToString());
            response.Add(Random.Range(0, 21).ToString());
        }
        response.Add(expression.GetComponentInChildren<Slots>().answerNumber.ToString());
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
        //Allow buttons to be clickable
        choice1.GetComponentInChildren<DragButton>().clickable = true;
        choice2.GetComponentInChildren<DragButton>().clickable = true;
        choice3.GetComponentInChildren<DragButton>().clickable = true;
        response.Clear();
    }

    void inRightSpot(GameObject choice)
    {
        if (choice.GetComponent<DragButton>().beingGrabbed == true)
        {
            dis1 = Vector2.Distance(expression.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

            CheckSlot(dis1, choice);
        }
        else
        {
            if (choice.GetComponent<DragButton>().correct == true)
            {
                choice.GetComponent<DragButton>().correct = false;
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
                expression.GetComponent<DragButton>().CorrectSpot();
                numCorrect++;
                //if (choice.GetComponent<DragButton>().slotSetNumber == 1)
                //{
                //    leftOperand.GetComponent<Slots>().CorrectSlot();
                //    numCorrect++;
                //}
                //else if (choice.GetComponent<DragButton>().slotSetNumber == 2)
                //{
                //    operation.GetComponent<Slots>().CorrectSlot();
                //    numCorrect++;
                //}
                //else if (choice.GetComponent<DragButton>().slotSetNumber == 3)
                //{
                //    rightOperand.GetComponent<Slots>().CorrectSlot();
                //    numCorrect++;
                //}
                //choice.GetComponent<DragButton>().slotSetNumber = 0;
            }
        }
    }


    void CheckSlot(float dis1, GameObject choice)
    {
        if (dis1 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == expression.GetComponent<Slots>().answerText)
            {
                if (expression.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = expression.GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
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
    }
}
