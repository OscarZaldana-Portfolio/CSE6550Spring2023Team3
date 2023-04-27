using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MultiplicationQuiz : MonoBehaviour
{
    public Animator carrot;
    public Animator reverseCarrot;
    int[] slotsA = new int[3];
    int numCorrect = 0;
    public GameObject leftOperand;
    public GameObject rightOperand;
    public GameObject expression;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject nextButton;
    public GameObject backGroundImage;
    public Canvas canv1;
    public Canvas canv2;
    public Animator bugsy;

    List<int> response = new List<int>();

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
        setAnswers();
        setText();
        addResponse();
        Shuffle(response);
        setChoices();
        response.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (choice1 != null) { inRightSpot(choice1); }
        if (choice2 != null) { inRightSpot(choice2); }
        if (choice3 != null) { inRightSpot(choice3); }

        allCorrect();
    }

    public void setAnswers()
    {
        if (GameManager.Instance.GetLevel() == 1)
        {
            slotsA[0] = Random.Range(1, 6);
            slotsA[1] = Random.Range(1, 6);
            slotsA[2] = slotsA[0] * slotsA[1];
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            slotsA[0] = Random.Range(1, 11);
            slotsA[1] = Random.Range(1, 11);
            slotsA[2] = slotsA[0] * slotsA[1];
        }
        else if (GameManager.Instance.GetLevel() == 3)
        {
            slotsA[0] = Random.Range(1, 20);
            slotsA[1] = Random.Range(1, 20);
            slotsA[2] = slotsA[0] * slotsA[1];
        }
    }

    public void setText()
    {
        leftOperand.GetComponentInChildren<TMP_Text>().text = slotsA[0].ToString();
        rightOperand.GetComponentInChildren<TMP_Text>().text = slotsA[1].ToString();
        expression.GetComponentInChildren<TMP_Text>().text = "?";
    }

    public void onLeftOperandClick()
    {
       
            switch (leftOperand.ToString())
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

    private void addResponse()
    {
        response.Add(slotsA[2]);
        if (GameManager.Instance.GetLevel() == 1)
        {
            response.Add(Random.Range(1, 6));
            response.Add(Random.Range(1, 6));
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            response.Add(Random.Range(1, 11));
            response.Add(Random.Range(1, 11));
        }
        else if (GameManager.Instance.GetLevel() == 3)
        {
            response.Add(Random.Range(1, 21));
            response.Add(Random.Range(1, 21));
        }
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
        choice1.GetComponentInChildren<TMP_Text>().text = response[0].ToString();
        choice2.GetComponentInChildren<TMP_Text>().text = response[1].ToString();
        choice3.GetComponentInChildren<TMP_Text>().text = response[2].ToString();
    }

    void inRightSpot(GameObject choice)
    {
        float dis5 = Vector2.Distance(expression.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

        if (dis5 < 1)
        {
            if (int.Parse(choice.GetComponentInChildren<TMP_Text>().text) == slotsA[2])
            {
                if (expression.GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = expression.GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    GameManager.Instance.AudioManager.PlaySound("CorrectAnswer", 1.0f);
                    GameManager.Instance.AudioManager.PlaySound("Yaay", 1.0f);
                }
                whenCorrect(choice, expression);
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
                bugsy.Play("NotCorrect");
            }
        }
        else
        {
            choice.GetComponent<DragButton>().isInCorrectSpot = false;
        }
    }

    void whenCorrect(GameObject choice, GameObject slot)
    {
        if (choice.GetComponent<DragButton>().correct == true)
        {
            expression.GetComponentInChildren<TMP_Text>().text = slotsA[2].ToString();
            slot.GetComponent<Slots>().emptySlot();
            choice.SetActive(false);
            choice.GetComponent<DragButton>().correct = false;
            slot.GetComponent<Slots>().slotAccepting = false;
            GameManager.Instance.AudioManager.PlaySound("CorrectAnswer", 1.0f);
            GameManager.Instance.AudioManager.PlaySound("Yaay", 1.0f);
            bugsy.Play("Correct");
            numCorrect++;
        }
    }

    public void onChoice1()
    {
        Debug.Log("top val " + choice1.GetComponentInChildren<TMP_Text>().text);
        switch (choice1.GetComponentInChildren<TMP_Text>().text)
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
            case "10":
                GameManager.Instance.AudioManager.PlaySound("Ten", 1.0f);
                break;
            case "11":
                GameManager.Instance.AudioManager.PlaySound("Eleven", 1.0f);
                break;
            case "12":
                GameManager.Instance.AudioManager.PlaySound("Twelve", 1.0f);
                break;
            case "13":
                GameManager.Instance.AudioManager.PlaySound("Thirteen", 1.0f);
                break;
            case "14":
                GameManager.Instance.AudioManager.PlaySound("Fourteen", 1.0f);
                break;
            case "15":
                GameManager.Instance.AudioManager.PlaySound("Fifteen", 1.0f);
                break;
            case "16":
                GameManager.Instance.AudioManager.PlaySound("Sixteen", 1.0f);
                break;
            case "17":
                GameManager.Instance.AudioManager.PlaySound("Seventeen", 1.0f);
                break;
            case "18":
                GameManager.Instance.AudioManager.PlaySound("Eighteen", 1.0f);
                break;
            case "19":
                GameManager.Instance.AudioManager.PlaySound("Nineteen", 1.0f);
                break;
            case "20":
                GameManager.Instance.AudioManager.PlaySound("Twenty", 1.0f);
                break;
            case "21":
                GameManager.Instance.AudioManager.PlaySound("TwentyOne", 1.0f);
                break;
            case "22":
                GameManager.Instance.AudioManager.PlaySound("TwentyTwo", 1.0f);
                break;
            case "23":
                GameManager.Instance.AudioManager.PlaySound("TwentyThree", 1.0f);
                break;
            case "24":
                GameManager.Instance.AudioManager.PlaySound("TwentyFour", 1.0f);
                break;
            case "25":
                GameManager.Instance.AudioManager.PlaySound("TwentyFive", 1.0f);
                break;
            case "26":
                GameManager.Instance.AudioManager.PlaySound("TwentySix", 1.0f);
                break;
            case "27":
                GameManager.Instance.AudioManager.PlaySound("TwentySeven", 1.0f);
                break;
            case "28":
                GameManager.Instance.AudioManager.PlaySound("TwentyEight", 1.0f);
                break;
            case "29":
                GameManager.Instance.AudioManager.PlaySound("TwentyNine", 1.0f);
                break;
            case "30":
                GameManager.Instance.AudioManager.PlaySound("Thirty", 1.0f);
                break;
        }
    }

    public void onChoice2()
    {
        Debug.Log("top val " + choice2.GetComponentInChildren<TMP_Text>().text);
        switch (choice2.GetComponentInChildren<TMP_Text>().text)
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
            case "10":
                GameManager.Instance.AudioManager.PlaySound("Ten", 1.0f);
                break;
            case "11":
                GameManager.Instance.AudioManager.PlaySound("Eleven", 1.0f);
                break;
            case "12":
                GameManager.Instance.AudioManager.PlaySound("Twelve", 1.0f);
                break;
            case "13":
                GameManager.Instance.AudioManager.PlaySound("Thirteen", 1.0f);
                break;
            case "14":
                GameManager.Instance.AudioManager.PlaySound("Fourteen", 1.0f);
                break;
            case "15":
                GameManager.Instance.AudioManager.PlaySound("Fifteen", 1.0f);
                break;
            case "16":
                GameManager.Instance.AudioManager.PlaySound("Sixteen", 1.0f);
                break;
            case "17":
                GameManager.Instance.AudioManager.PlaySound("Seventeen", 1.0f);
                break;
            case "18":
                GameManager.Instance.AudioManager.PlaySound("Eighteen", 1.0f);
                break;
            case "19":
                GameManager.Instance.AudioManager.PlaySound("Nineteen", 1.0f);
                break;
            case "20":
                GameManager.Instance.AudioManager.PlaySound("Twenty", 1.0f);
                break;
            case "21":
                GameManager.Instance.AudioManager.PlaySound("TwentyOne", 1.0f);
                break;
            case "22":
                GameManager.Instance.AudioManager.PlaySound("TwentyTwo", 1.0f);
                break;
            case "23":
                GameManager.Instance.AudioManager.PlaySound("TwentyThree", 1.0f);
                break;
            case "24":
                GameManager.Instance.AudioManager.PlaySound("TwentyFour", 1.0f);
                break;
            case "25":
                GameManager.Instance.AudioManager.PlaySound("TwentyFive", 1.0f);
                break;
            case "26":
                GameManager.Instance.AudioManager.PlaySound("TwentySix", 1.0f);
                break;
            case "27":
                GameManager.Instance.AudioManager.PlaySound("TwentySeven", 1.0f);
                break;
            case "28":
                GameManager.Instance.AudioManager.PlaySound("TwentyEight", 1.0f);
                break;
            case "29":
                GameManager.Instance.AudioManager.PlaySound("TwentyNine", 1.0f);
                break;
            case "30":
                GameManager.Instance.AudioManager.PlaySound("Thirty", 1.0f);
                break;
        }
    }

    public void onChoice3()
    {
        Debug.Log("top val " + choice1.GetComponentInChildren<TMP_Text>().text);
        switch (choice3.GetComponentInChildren<TMP_Text>().text)
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
            case "10":
                GameManager.Instance.AudioManager.PlaySound("Ten", 1.0f);
                break;
            case "11":
                GameManager.Instance.AudioManager.PlaySound("Eleven", 1.0f);
                break;
            case "12":
                GameManager.Instance.AudioManager.PlaySound("Twelve", 1.0f);
                break;
            case "13":
                GameManager.Instance.AudioManager.PlaySound("Thirteen", 1.0f);
                break;
            case "14":
                GameManager.Instance.AudioManager.PlaySound("Fourteen", 1.0f);
                break;
            case "15":
                GameManager.Instance.AudioManager.PlaySound("Fifteen", 1.0f);
                break;
            case "16":
                GameManager.Instance.AudioManager.PlaySound("Sixteen", 1.0f);
                break;
            case "17":
                GameManager.Instance.AudioManager.PlaySound("Seventeen", 1.0f);
                break;
            case "18":
                GameManager.Instance.AudioManager.PlaySound("Eighteen", 1.0f);
                break;
            case "19":
                GameManager.Instance.AudioManager.PlaySound("Nineteen", 1.0f);
                break;
            case "20":
                GameManager.Instance.AudioManager.PlaySound("Twenty", 1.0f);
                break;
            case "21":
                GameManager.Instance.AudioManager.PlaySound("TwentyOne", 1.0f);
                break;
            case "22":
                GameManager.Instance.AudioManager.PlaySound("TwentyTwo", 1.0f);
                break;
            case "23":
                GameManager.Instance.AudioManager.PlaySound("TwentyThree", 1.0f);
                break;
            case "24":
                GameManager.Instance.AudioManager.PlaySound("TwentyFour", 1.0f);
                break;
            case "25":
                GameManager.Instance.AudioManager.PlaySound("TwentyFive", 1.0f);
                break;
            case "26":
                GameManager.Instance.AudioManager.PlaySound("TwentySix", 1.0f);
                break;
            case "27":
                GameManager.Instance.AudioManager.PlaySound("TwentySeven", 1.0f);
                break;
            case "28":
                GameManager.Instance.AudioManager.PlaySound("TwentyEight", 1.0f);
                break;
            case "29":
                GameManager.Instance.AudioManager.PlaySound("TwentyNine", 1.0f);
                break;
            case "30":
                GameManager.Instance.AudioManager.PlaySound("Thirty", 1.0f);
                break;
        }
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
        Debug.Log("left opertand" + leftOperand.GetComponentInChildren<TMP_Text>().text);
        switch (leftOperand.GetComponentInChildren<TMP_Text>().text)
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

    public void onRightOperandClick()
    {
        Debug.Log("val of left operand" + rightOperand.GetComponentInChildren<TMP_Text>().text);

        switch (rightOperand.GetComponentInChildren<TMP_Text>().text)
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

    public void onExpressionClick()
    {
        Debug.Log("val of left operand" + expression.GetComponentInChildren<TMP_Text>().text);

        switch (expression.GetComponentInChildren<TMP_Text>().text)
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
    void allCorrect()
    {
        if (numCorrect == 1)
        {
            GameManager.Instance.AudioManager.PlaySound("CorrectAnswer", 1.0f);
            GameManager.Instance.AudioManager.PlaySound("Yaay", 1.0f);
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
    }


    public void ResetScene()
    {
        setButton(choice1);
        setButton(choice2);
        setButton(choice3);

        nextButton.SetActive(false);
        leftOperand.GetComponent<Slots>().fillSlot();
        rightOperand.GetComponent<Slots>().fillSlot();
        expression.GetComponent<Slots>().fillSlot();

        setAnswers();
        setText();
        addResponse();
        Shuffle(response);
        setChoices();
        response.Clear();
        numCorrect = 0;
    }

    void setButton(GameObject choice)
    {
        choice.SetActive(true);
        choice.GetComponent<DragButton>().dontMoveBack = false;
        choice.GetComponent<DragButton>().isInCorrectSpot = false;
        choice.GetComponent<DragButton>().correct = false;

    }
}
