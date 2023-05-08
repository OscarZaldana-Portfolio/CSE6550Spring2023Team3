using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MultiplicationFun : MonoBehaviour
{
    public Animator carrot;
    public Animator reverseCarrot;
    int[] slotsA = new int[3];
    int numCorrect = 0;
    public TMP_Text left;
    public TMP_Text right;
    public GameObject leftOperand;
    public GameObject rightOperand;
    public GameObject expression;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject nextButton;
    public GameObject backGroundImage;
    public GameObject sideImage;
    public Canvas canv1;
    public Canvas canv2;
    public Animator bugsy;
    public GameObject leftSpot;
    public GameObject rightSpot;
    public List<GameObject> leftRend;
    public List<GameObject> rightRend;
    List<int> response = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationFun)
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
        setOff();
        SetOn();
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
        left.text = "X " + leftOperand.GetComponentInChildren<TMP_Text>().text;
        right.text = "X " + rightOperand.GetComponentInChildren<TMP_Text>().text;
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
                    GameManager.Instance.AudioManager.PlaySound("WrongAnswer", 1.0f);
                }
                whenCorrect(choice, expression);
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
                GameManager.Instance.AudioManager.PlaySound("WrongAnswer", 1.0f);
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
            slot.GetComponent<Slots>().CorrectSlot();
            choice.SetActive(false);
            choice.GetComponent<DragButton>().correct = false;
            slot.GetComponent<Slots>().slotAccepting = false;
            GameManager.Instance.AudioManager.PlaySound("CorrectAnswer", 1.0f);
            GameManager.Instance.AudioManager.PlaySound("Yaay", 1.0f);
            bugsy.Play("Correct");
            numCorrect++;
        }
    }

    public void allCorrect()
    {
        if (numCorrect == 1)
        {
            nextButton.SetActive(true);
            GameManager.Instance.AudioManager.PlaySound("CorrectAnswer", 1.0f);
            GameManager.Instance.AudioManager.PlaySound("Yaay", 1.0f);
        }
        else
        {
            nextButton.SetActive(false);
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
        setOff();
     }

    public void imagesOn()
    {
        backGroundImage.GetComponent<SpriteRenderer>().enabled = true;
        sideImage.GetComponent<SpriteRenderer>().enabled = true;
        canv1.GetComponent<Canvas>().enabled = true;
        canv2.GetComponent<Canvas>().enabled = true;
        leftSpot.GetComponent<SpriteRenderer>().enabled = false;
        rightSpot.GetComponent<SpriteRenderer>().enabled = false;
        SetOn();
    }

    public void onCorrectAns()
    {
        GameManager.Instance.AudioManager.PlaySound("CorrectAnswer", 1.0f);
        GameManager.Instance.AudioManager.PlaySound("Yaay", 1.0f);
    }

    public void ResetScene()
    {
        setButton(choice1);
        setButton(choice2);
        setButton(choice3);

        nextButton.SetActive(false);

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
        choice.GetComponent<DragButton>().beingGrabbed = false;
        choice.GetComponent<DragButton>().isInCorrectSpot = false;
        choice.GetComponent<DragButton>().correct = false;

    }
}
