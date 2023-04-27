using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MultiplicationPuzzle : MonoBehaviour
{
    public Animator carrot;
    public Animator reverseCarrot;
    int[] slotsA = new int[5];
    public int numCorrect = 0;
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

    List<GameObject> response = new List<GameObject>();

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
        addResponse();
        Shuffle(response);
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
        leftOperand.GetComponentInChildren<TMP_Text>().text = slotsA[0].ToString();
        operation.GetComponentInChildren<TMP_Text>().text = "X";
        rightOperand.GetComponentInChildren<TMP_Text>().text = slotsA[2].ToString();
        equalOperation.GetComponentInChildren<TMP_Text>().text = "=";
        expression.GetComponentInChildren<TMP_Text>().text = slotsA[4].ToString();
    }

    private void addResponse()
    {
        response.Add(leftOperand);
        response.Add(operation);
        response.Add(rightOperand);
        response.Add(equalOperation);
        response.Add(expression);
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
        choice1.GetComponentInChildren<TMP_Text>().text = response[0].GetComponentInChildren<TMP_Text>().text;
        choice2.GetComponentInChildren<TMP_Text>().text = response[1].GetComponentInChildren<TMP_Text>().text;
        choice3.GetComponentInChildren<TMP_Text>().text = response[2].GetComponentInChildren<TMP_Text>().text;
        choice4.GetComponentInChildren<TMP_Text>().text = response[3].GetComponentInChildren<TMP_Text>().text;
        choice5.GetComponentInChildren<TMP_Text>().text = response[4].GetComponentInChildren<TMP_Text>().text;
    }

    void inRightSpot(GameObject choice)
    {
        float dis1 = Vector2.Distance(leftOperand.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
        float dis2 = Vector2.Distance(operation.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
        float dis3 = Vector2.Distance(rightOperand.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
        float dis4 = Vector2.Distance(equalOperation.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
        float dis5 = Vector2.Distance(expression.GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

        if(dis1 < 1)
        {
            if(choice.GetComponentInChildren<TMP_Text>().text == leftOperand.GetComponentInChildren<TMP_Text>().text) {
                choice.GetComponent<DragButton>().answerPosition = leftOperand.GetComponent<Transform>().transform.position;
                choice.GetComponent<DragButton>().isInCorrectSpot = true;
                whenCorrect(choice, leftOperand);
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
            }
        }
        else if(dis2 < 1)
        {
            if (choice.GetComponentInChildren<TMP_Text>().text == operation.GetComponentInChildren<TMP_Text>().text)
            {
                choice.GetComponent<DragButton>().answerPosition = operation.GetComponent<Transform>().transform.position;
                choice.GetComponent<DragButton>().isInCorrectSpot = true;
                whenCorrect(choice, operation);
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
            }
        }
        else if (dis3 < 1)
        {
            if (choice.GetComponentInChildren<TMP_Text>().text == rightOperand.GetComponentInChildren<TMP_Text>().text)
            {
                choice.GetComponent<DragButton>().answerPosition = rightOperand.GetComponent<Transform>().transform.position;
                choice.GetComponent<DragButton>().isInCorrectSpot = true;
                whenCorrect(choice, rightOperand);
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
            }

        }
        else if (dis4 < 1)
        {
            if (choice.GetComponentInChildren<TMP_Text>().text == equalOperation.GetComponentInChildren<TMP_Text>().text)
            {
                choice.GetComponent<DragButton>().answerPosition = equalOperation.GetComponent<Transform>().transform.position;
                choice.GetComponent<DragButton>().isInCorrectSpot = true;
                whenCorrect(choice, equalOperation);
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
            }
        }
        else if (dis5 < 1)
        {
            if (choice.GetComponentInChildren<TMP_Text>().text == expression.GetComponentInChildren<TMP_Text>().text)
            {
                choice.GetComponent<DragButton>().answerPosition = expression.GetComponent<Transform>().transform.position;
                choice.GetComponent<DragButton>().isInCorrectSpot = true;
                whenCorrect(choice, expression);
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
            }
        }
        else
        {
            choice.GetComponent<DragButton>().isInCorrectSpot = false;
        }
    }

    void whenCorrect(GameObject choice, GameObject slot)
    {
        if(choice.GetComponent<DragButton>().correct == true)
        {
            slot.GetComponent<Slots>().emptySlot();
            choice.SetActive(false);
            choice.GetComponent<DragButton>().correct = false;
            numCorrect++;
        }
    }

}
