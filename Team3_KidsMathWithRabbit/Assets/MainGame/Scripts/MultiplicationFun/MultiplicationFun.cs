using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class MultiplicationFun : MonoBehaviour
{
    public Animator reverseCarrot;
    int[] slotsA = new int[5];
    int numCorrect = 0;
    public TMP_Text left;
    public TMP_Text right;
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
    public GameObject sideImage;
    public Canvas canv1;
    public Canvas canv2;
    public ParticleSystem confetti;
    float timeRemaining = 10f;
    private bool isTimerRunning = false;
    public GameObject leftSpot;
    public GameObject rightSpot;
    public List<GameObject> leftRend;
    public List<GameObject> rightRend;

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
        GameManager.Instance.AudioManager.PlaySound("SolveThePuzzle", 1.0f);
        isTimerRunning = true;
        //Handle Images
        setOff();
        SetOn();
    }

    // Update is called once per frame
    void Update()
    {
        if (choice1 != null) { inRightSpot(choice1); }
        if (choice2 != null) { inRightSpot(choice2); }
        if (choice3 != null) { inRightSpot(choice3); }

        AllCorrect();
    }

    public void setOff()
    {
        for (int i = 0; i < 5; i++)
        {
            leftRend[i].GetComponent<SpriteRenderer>().enabled = false;
            rightRend[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void SetOn()
    {
        int n = Random.Range(0, 5);
        leftRend[n].GetComponent<SpriteRenderer>().enabled = true;
        rightRend[n].GetComponent<SpriteRenderer>().enabled = true;
        left.text = "X " + leftOperand.GetComponent<Slots>().answerText;
        right.text = "X " + rightOperand.GetComponent<Slots>().answerText;
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
                if (choice.GetComponent<DragButton>().slotSetNumber == 1)
                {
                    expression.GetComponent<Slots>().CorrectSlot();
                    expression.GetComponent<Slots>().SetText();
                    numCorrect++;
                }
                choice.GetComponent<DragButton>().slotSetNumber = 0;
            }
        }
    }


    void CheckSlot(float dis1, GameObject choice)
    {
        if (dis1 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == expression.GetComponent<Slots>().answerNumber.ToString())
            {
                if (expression.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = expression.GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 1;
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
        if (numCorrect == 1)
        {
            choice1.GetComponent<Animator>().Play("Choice1Idle");
            choice2.GetComponent<Animator>().Play("Choice2Idle");
            choice3.GetComponent<Animator>().Play("Choice3Idle");
            choice1.GetComponentInChildren<TMP_Text>().text = "";
            choice2.GetComponentInChildren<TMP_Text>().text = "";
            choice3.GetComponentInChildren<TMP_Text>().text = "";
            choice1.GetComponent<DragButton>().clickable = false;
            choice2.GetComponent<DragButton>().clickable = false;
            choice3.GetComponent<DragButton>().clickable = false;
            nextButton.SetActive(true);
            leftOperand.GetComponent<Animator>().Play("LeftOperandFun");
            operation.GetComponent<Animator>().Play("OperationFun");
            rightOperand.GetComponent<Animator>().Play("RightOperandFun");
            equalOperation.GetComponent<Animator>().Play("EqualOperationFun");
            expression.GetComponent<Animator>().Play("ExpressionFun");
            GameManager.Instance.AudioManager.musicSource.Pause();
            confetti.Play();
            isTimerRunning = false;
        }
        else
        {
            nextButton.SetActive(false);
            if (isTimerRunning)
            {
                if (timeRemaining > 0f)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    // timer has ended, do something
                    ShoutSupport();
                }
            }
        }
    }

    public void imagesOff()
    {
        backGroundImage.GetComponent<SpriteRenderer>().enabled = false;
        sideImage.GetComponent<SpriteRenderer>().enabled = false;
        canv1.GetComponent<Canvas>().enabled = false;
        canv2.GetComponent<Canvas>().enabled = false;
        leftSpot.GetComponent<SpriteRenderer>().enabled = false;
        rightSpot.GetComponent<SpriteRenderer>().enabled = false;
        confetti.Stop();
        setOff();
    }

    public void imagesOn()
    {
        choice1.GetComponent<Image>().enabled = true;
        choice2.GetComponent<Image>().enabled = true;
        choice3.GetComponent<Image>().enabled = true;
        backGroundImage.GetComponent<SpriteRenderer>().enabled = true;
        sideImage.GetComponent<SpriteRenderer>().enabled = true;
        canv1.GetComponent<Canvas>().enabled = true;
        canv2.GetComponent<Canvas>().enabled = true;
        leftSpot.GetComponent<SpriteRenderer>().enabled = true;
        rightSpot.GetComponent<SpriteRenderer>().enabled = true;
        choice1.GetComponent<DragButton>().PlayAnim("Choice1Intro");
        choice2.GetComponent<DragButton>().PlayAnim("Choice2Intro");
        choice3.GetComponent<DragButton>().PlayAnim("Choice3Intro");
        GameManager.Instance.AudioManager.musicSource.UnPause();
        isTimerRunning = true;
        SetOn();
    }

    public void ResetScene()
    {
        nextButton.SetActive(false);
        setText();
        setChoices();
        setButton();
        numCorrect = 0;
        leftOperand.GetComponent<Animator>().Play("LeftOperandIdle");
        operation.GetComponent<Animator>().Play("OperationIdle");
        rightOperand.GetComponent<Animator>().Play("RightOperandIdle");
        equalOperation.GetComponent<Animator>().Play("EqualOperationIdle");
        expression.GetComponent<Animator>().Play("ExpressionIdle");
    }

    void setButton()
    {
        choice1.GetComponent<DragButton>().ResetChoices();
        choice2.GetComponent<DragButton>().ResetChoices();
        choice3.GetComponent<DragButton>().ResetChoices();
    }

    void ShoutSupport()
    {
        GameManager.Instance.AudioManager.PlaySound("SupportShouts", 1.0f);
        timeRemaining = 10.0f;
    }
}