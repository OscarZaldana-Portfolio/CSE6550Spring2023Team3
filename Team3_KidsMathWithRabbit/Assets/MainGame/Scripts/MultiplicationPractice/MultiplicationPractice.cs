using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class MultiplicationPractice : MonoBehaviour
{
    public Animator reverseCarrot;
    int[] slotsA = new int[6];
    int numCorrect = 0;
    public GameObject[] slots1;
    public GameObject[] slots2;
    public GameObject[] slots3;
    public GameObject[] slots4;
    public GameObject[] slots5;
    public GameObject[] slots6;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;
    public GameObject choice5;
    public GameObject choice6;
    public GameObject choice7;
    public GameObject nextButton;
    public GameObject backGroundImage;
    public Canvas canv1;
    public Canvas canv2;
    public ParticleSystem confetti;
    float timeRemaining = 10f;
    private bool isTimerRunning = false;

    float dis1;
    float dis2;
    float dis3;
    float dis4;
    float dis5;
    float dis6;

    List<string> response = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationPractice)
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
    }

    // Update is called once per frame
    void Update()
    {
        MakeChoices();
        //AllCorrect();
    }

    public void setAnswers()
    {
        slots1[0].GetComponent<Slots>().ChooseNumber();
        slots1[2].GetComponent<Slots>().ChooseNumber();
        slots1[4].GetComponent<Slots>().answerNumber = slots1[0].GetComponent<Slots>().answerNumber * slots1[2].GetComponent<Slots>().answerNumber;
        slots2[0].GetComponent<Slots>().ChooseNumber();
        slots2[2].GetComponent<Slots>().ChooseNumber();
        slots2[4].GetComponent<Slots>().answerNumber = slots2[0].GetComponent<Slots>().answerNumber * slots2[2].GetComponent<Slots>().answerNumber;
        slots3[0].GetComponent<Slots>().ChooseNumber();
        slots3[2].GetComponent<Slots>().ChooseNumber();
        slots3[4].GetComponent<Slots>().answerNumber = slots3[0].GetComponent<Slots>().answerNumber * slots3[2].GetComponent<Slots>().answerNumber;
        slots4[0].GetComponent<Slots>().ChooseNumber();
        slots4[2].GetComponent<Slots>().ChooseNumber();
        slots4[4].GetComponent<Slots>().answerNumber = slots4[0].GetComponent<Slots>().answerNumber * slots4[2].GetComponent<Slots>().answerNumber;
        slots5[0].GetComponent<Slots>().ChooseNumber();
        slots5[2].GetComponent<Slots>().ChooseNumber();
        slots5[4].GetComponent<Slots>().answerNumber = slots5[0].GetComponent<Slots>().answerNumber * slots5[2].GetComponent<Slots>().answerNumber;
        slots6[0].GetComponent<Slots>().ChooseNumber();
        slots6[2].GetComponent<Slots>().ChooseNumber();
        slots6[4].GetComponent<Slots>().answerNumber = slots6[0].GetComponent<Slots>().answerNumber * slots6[2].GetComponent<Slots>().answerNumber;
        for (int i = 0; i < 6; i++)
        {
            int num = Random.Range(0, 3);
            if (num == 0)
            {
                slotsA[i] = 0;
            }
            else if (num == 1)
            {
                slotsA[i] = 2;
            }
            else
            {
                slotsA[i] = 4;
            }

        }
    }

    public void setText()
    {
        //Randomize the values
        setAnswers();
        //Set the text to match the values
        if (GameManager.Instance.GetPracticeLevel() == 1)
        {
            SetNumberForLevel1and2();
            SetAcceptingForLevel1();
            SetColorsForLevel1();
        }
        else if (GameManager.Instance.GetPracticeLevel() == 2)
        {
            SetNumberForLevel1and2();
            SetAcceptingForLevel2();
            SetColorsForLevel2();
        }
        else
        {
            SetNumberForLevel3();
            SetAcceptingForLevel3();
            SetColorsForLevel3();
        }
        SetImageForLevel();
    }

    void SetNumberForLevel1and2()
    {
        slots1[0].GetComponent<Slots>().SetText();
        slots1[1].GetComponent<Slots>().answerText = "X";
        slots1[2].GetComponent<Slots>().SetText();
        slots1[3].GetComponent<Slots>().answerText = "=";
        slots1[4].GetComponent<Slots>().answerText = "?";

        slots2[0].GetComponent<Slots>().SetText();
        slots2[1].GetComponent<Slots>().answerText = "X";
        slots2[2].GetComponent<Slots>().SetText();
        slots2[3].GetComponent<Slots>().answerText = "=";
        slots2[4].GetComponent<Slots>().answerText = "?";

        slots3[0].GetComponent<Slots>().SetText();
        slots3[1].GetComponent<Slots>().answerText = "X";
        slots3[2].GetComponent<Slots>().SetText();
        slots3[3].GetComponent<Slots>().answerText = "=";
        slots3[4].GetComponent<Slots>().answerText = "?";

        slots4[0].GetComponent<Slots>().SetText();
        slots4[1].GetComponent<Slots>().answerText = "X";
        slots4[2].GetComponent<Slots>().SetText();
        slots4[3].GetComponent<Slots>().answerText = "=";
        slots4[4].GetComponent<Slots>().answerText = "?";

        slots5[0].GetComponent<Slots>().SetText();
        slots5[1].GetComponent<Slots>().answerText = "X";
        slots5[2].GetComponent<Slots>().SetText();
        slots5[3].GetComponent<Slots>().answerText = "=";
        slots5[4].GetComponent<Slots>().answerText = "?";

        slots6[0].GetComponent<Slots>().SetText();
        slots6[1].GetComponent<Slots>().answerText = "X";
        slots6[2].GetComponent<Slots>().SetText();
        slots6[3].GetComponent<Slots>().answerText = "=";
        slots6[4].GetComponent<Slots>().answerText = "?";
    }
    void SetNumberForLevel3()
    {
        slots1[0].GetComponent<Slots>().answerText = slots1[0].GetComponent<Slots>().answerNumber.ToString();
        slots1[1].GetComponent<Slots>().answerText = "X";
        slots1[2].GetComponent<Slots>().answerText = slots1[2].GetComponent<Slots>().answerNumber.ToString();
        slots1[3].GetComponent<Slots>().answerText = "=";
        slots1[4].GetComponent<Slots>().answerText = slots1[4].GetComponent<Slots>().answerNumber.ToString();

        slots2[0].GetComponent<Slots>().answerText = slots2[0].GetComponent<Slots>().answerNumber.ToString();
        slots2[1].GetComponent<Slots>().answerText = "X";
        slots2[2].GetComponent<Slots>().answerText = slots2[2].GetComponent<Slots>().answerNumber.ToString();
        slots2[3].GetComponent<Slots>().answerText = "=";
        slots2[4].GetComponent<Slots>().answerText = slots2[4].GetComponent<Slots>().answerNumber.ToString();

        slots3[0].GetComponent<Slots>().answerText = slots3[0].GetComponent<Slots>().answerNumber.ToString();
        slots3[1].GetComponent<Slots>().answerText = "X";
        slots3[2].GetComponent<Slots>().answerText = slots3[2].GetComponent<Slots>().answerNumber.ToString();
        slots3[3].GetComponent<Slots>().answerText = "=";
        slots3[4].GetComponent<Slots>().answerText = slots3[4].GetComponent<Slots>().answerNumber.ToString();

        slots4[0].GetComponent<Slots>().answerText = slots4[0].GetComponent<Slots>().answerNumber.ToString();
        slots4[1].GetComponent<Slots>().answerText = "X";
        slots4[2].GetComponent<Slots>().answerText = slots4[2].GetComponent<Slots>().answerNumber.ToString();
        slots4[3].GetComponent<Slots>().answerText = "=";
        slots4[4].GetComponent<Slots>().answerText = slots4[4].GetComponent<Slots>().answerNumber.ToString();

        slots5[0].GetComponent<Slots>().answerText = slots5[0].GetComponent<Slots>().answerNumber.ToString();
        slots5[1].GetComponent<Slots>().answerText = "X";
        slots5[2].GetComponent<Slots>().answerText = slots5[2].GetComponent<Slots>().answerNumber.ToString();
        slots5[3].GetComponent<Slots>().answerText = "=";
        slots5[4].GetComponent<Slots>().answerText = slots5[4].GetComponent<Slots>().answerNumber.ToString();

        slots6[0].GetComponent<Slots>().answerText = slots6[0].GetComponent<Slots>().answerNumber.ToString();
        slots6[1].GetComponent<Slots>().answerText = "X";
        slots6[2].GetComponent<Slots>().answerText = slots6[2].GetComponent<Slots>().answerNumber.ToString();
        slots6[3].GetComponent<Slots>().answerText = "=";
        slots6[4].GetComponent<Slots>().answerText = slots6[4].GetComponent<Slots>().answerNumber.ToString();

        slots1[slotsA[0]].GetComponent<Slots>().answerText = "?";
        slots2[slotsA[1]].GetComponent<Slots>().answerText = "?";
        slots3[slotsA[2]].GetComponent<Slots>().answerText = "?";
        slots4[slotsA[3]].GetComponent<Slots>().answerText = "?";
        slots5[slotsA[4]].GetComponent<Slots>().answerText = "?";
        slots6[slotsA[5]].GetComponent<Slots>().answerText = "?";
    }
    void SetAcceptingForLevel1()
    {
        for (int i = 0; i < 5; i++)
        {
            slots1[i].GetComponent<Slots>().slotAccepting = false;
            slots2[i].GetComponent<Slots>().slotAccepting = false;
            slots3[i].GetComponent<Slots>().slotAccepting = false;
            slots4[i].GetComponent<Slots>().slotAccepting = false;
            slots5[i].GetComponent<Slots>().slotAccepting = false;
            slots6[i].GetComponent<Slots>().slotAccepting = false;
        }
        slots1[4].GetComponent<Slots>().slotAccepting = true;
    }

    void SetAcceptingForLevel2()
    {
        for (int i = 0; i < 5; i++)
        {
            slots1[i].GetComponent<Slots>().slotAccepting = false;
            slots2[i].GetComponent<Slots>().slotAccepting = false;
            slots3[i].GetComponent<Slots>().slotAccepting = false;
            slots4[i].GetComponent<Slots>().slotAccepting = false;
            slots5[i].GetComponent<Slots>().slotAccepting = false;
            slots6[i].GetComponent<Slots>().slotAccepting = false;
        }

        slots1[4].GetComponent<Slots>().slotAccepting = true;
        slots2[4].GetComponent<Slots>().slotAccepting = true;
        slots3[4].GetComponent<Slots>().slotAccepting = true;
        slots4[4].GetComponent<Slots>().slotAccepting = true;
        slots5[4].GetComponent<Slots>().slotAccepting = true;
        slots6[4].GetComponent<Slots>().slotAccepting = true;
    }

    void SetAcceptingForLevel3()
    {
        for (int i = 0; i < 5; i++)
        {
            slots1[i].GetComponent<Slots>().slotAccepting = false;
            slots2[i].GetComponent<Slots>().slotAccepting = false;
            slots3[i].GetComponent<Slots>().slotAccepting = false;
            slots4[i].GetComponent<Slots>().slotAccepting = false;
            slots5[i].GetComponent<Slots>().slotAccepting = false;
            slots6[i].GetComponent<Slots>().slotAccepting = false;
        }
        slots1[slotsA[0]].GetComponent<Slots>().slotAccepting = true;
        slots2[slotsA[1]].GetComponent<Slots>().slotAccepting = true;
        slots3[slotsA[2]].GetComponent<Slots>().slotAccepting = true;
        slots4[slotsA[3]].GetComponent<Slots>().slotAccepting = true;
        slots5[slotsA[4]].GetComponent<Slots>().slotAccepting = true;
        slots6[slotsA[5]].GetComponent<Slots>().slotAccepting = true;
    }
    void SetColorsForLevel1()
    {
        for (int i = 0; i < 5; i++)
        {
            slots1[i].GetComponent<Slots>().SetTextColor("#003B20");
            slots2[i].GetComponent<Slots>().SetTextColor("#003B20");
            slots3[i].GetComponent<Slots>().SetTextColor("#003B20");
            slots4[i].GetComponent<Slots>().SetTextColor("#003B20");
            slots5[i].GetComponent<Slots>().SetTextColor("#003B20");
            slots6[i].GetComponent<Slots>().SetTextColor("#003B20");
        }
        slots1[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots1[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots1[4].GetComponent<Slots>().SetTextColor("#FFFFFF");
    }

    void SetColorsForLevel2()
    {
        for (int i = 0; i < 5; i++)
        {
            slots1[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots2[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots3[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots4[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots5[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots6[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
        }

        slots1[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots2[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots3[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots4[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots5[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots6[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots1[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots2[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots3[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots4[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots5[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots6[2].GetComponent<Slots>().SetTextColor("#FFFF00");
    }

    void SetColorsForLevel3()
    {
        for (int i = 0; i < 5; i++)
        {
            slots1[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots2[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots3[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots4[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots5[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
            slots6[i].GetComponent<Slots>().SetTextColor("#FFFFFF");
        }

        slots1[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots2[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots3[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots4[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots5[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots6[0].GetComponent<Slots>().SetTextColor("#33FF00");
        slots1[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots2[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots3[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots4[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots5[2].GetComponent<Slots>().SetTextColor("#FFFF00");
        slots6[2].GetComponent<Slots>().SetTextColor("#FFFF00");
    }

    void SetImageForLevel(){
        for (int i = 0; i < 5; i++)
        {
            if(slots1[i].GetComponent<Slots>().slotAccepting == true)
            {
                slots1[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                slots1[i].GetComponent<Image>().enabled = false;
            }
            if (slots2[i].GetComponent<Slots>().slotAccepting == true)
            {
                slots2[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                slots2[i].GetComponent<Image>().enabled = false;
            }
            if (slots3[i].GetComponent<Slots>().slotAccepting == true)
            {
                slots3[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                slots3[i].GetComponent<Image>().enabled = false;
            }
            if (slots4[i].GetComponent<Slots>().slotAccepting == true)
            {
                slots4[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                slots4[i].GetComponent<Image>().enabled = false;
            }
            if (slots5[i].GetComponent<Slots>().slotAccepting == true)
            {
                slots5[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                slots5[i].GetComponent<Image>().enabled = false;
            }
            if (slots6[i].GetComponent<Slots>().slotAccepting == true)
            {
                slots6[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                slots6[i].GetComponent<Image>().enabled = false;
            }
        }
    }

    void addResponseForLevel1() {
        response.Add(slots1[4].GetComponent<Slots>().answerNumber.ToString());
        response.Add(slots2[4].GetComponent<Slots>().answerNumber.ToString());
        response.Add(slots3[4].GetComponent<Slots>().answerNumber.ToString());
        response.Add(slots4[4].GetComponent<Slots>().answerNumber.ToString());
        response.Add(slots5[4].GetComponent<Slots>().answerNumber.ToString());
        response.Add(slots6[4].GetComponent<Slots>().answerNumber.ToString());
        if (GameManager.Instance.GetLevel() == 1)
        {
            response.Add(Random.Range(0, 6).ToString());
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            response.Add(Random.Range(0, 11).ToString());
        }
        else
        {
            response.Add(Random.Range(0, 21).ToString());
        }
    }

    private void addResponseForLevel2()
    {
        if (slots1[4].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots1[4].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if(GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots2[4].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots2[4].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots3[4].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots3[4].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots4[4].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots4[4].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots5[4].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots5[4].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots6[4].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots6[4].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (GameManager.Instance.GetLevel() == 1)
        {
            response.Add(Random.Range(0, 6).ToString());
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            response.Add(Random.Range(0, 11).ToString());
        }
        else
        {
            response.Add(Random.Range(0, 21).ToString());
        }
    }

    private void AddResponseForLevel3()
    {
        if (slots1[slotsA[0]].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots1[slotsA[0]].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots2[slotsA[1]].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots2[slotsA[1]].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots3[slotsA[2]].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots3[slotsA[2]].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots4[slotsA[3]].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots4[slotsA[3]].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots5[slotsA[4]].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots5[slotsA[4]].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (slots6[slotsA[5]].GetComponent<Slots>().slotAccepting == true)
        {
            response.Add(slots6[slotsA[5]].GetComponent<Slots>().answerNumber.ToString());
        }
        else
        {
            if (GameManager.Instance.GetLevel() == 1)
            {
                response.Add(Random.Range(0, 6).ToString());
            }
            else if (GameManager.Instance.GetLevel() == 2)
            {
                response.Add(Random.Range(0, 11).ToString());
            }
            else
            {
                response.Add(Random.Range(0, 21).ToString());
            }
        }
        if (GameManager.Instance.GetLevel() == 1)
        {
            response.Add(Random.Range(0, 6).ToString());
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            response.Add(Random.Range(0, 11).ToString());
        }
        else
        {
            response.Add(Random.Range(0, 21).ToString());
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
        if(GameManager.Instance.GetPracticeLevel() == 1)
        {
            addResponseForLevel1();
        }
        else if (GameManager.Instance.GetPracticeLevel() == 2)
        {
            addResponseForLevel2();
        }
        else
        {
            AddResponseForLevel3();
        }
        Shuffle(response);
        //set text of choices
        choice1.GetComponent<DragButton>().choiceText = response[0];
        choice2.GetComponent<DragButton>().choiceText = response[1];
        choice3.GetComponent<DragButton>().choiceText = response[2];
        choice4.GetComponent<DragButton>().choiceText = response[3];
        choice5.GetComponent<DragButton>().choiceText = response[4];
        choice6.GetComponent<DragButton>().choiceText = response[5];
        choice7.GetComponent<DragButton>().choiceText = response[6];
        //Allow buttons to be clickable
        choice1.GetComponentInChildren<DragButton>().clickable = true;
        choice2.GetComponentInChildren<DragButton>().clickable = true;
        choice3.GetComponentInChildren<DragButton>().clickable = true;
        choice4.GetComponentInChildren<DragButton>().clickable = true;
        choice5.GetComponentInChildren<DragButton>().clickable = true;
        choice6.GetComponentInChildren<DragButton>().clickable = true;
        choice7.GetComponentInChildren<DragButton>().clickable = true;
        response.Clear();
    }

    void MakeChoices()
    {
        if(GameManager.Instance.GetPracticeLevel() == 1)
        {
            inRightSpotLevel1(choice1);
            inRightSpotLevel1(choice2);
            inRightSpotLevel1(choice3);
            inRightSpotLevel1(choice4);
            inRightSpotLevel1(choice5);
            inRightSpotLevel1(choice6);
            inRightSpotLevel1(choice7);
        }
        else if (GameManager.Instance.GetPracticeLevel() == 2)
        {

        }
        else
        {

        }
    }



    void inRightSpotLevel1(GameObject choice)
    {
        if (choice.GetComponent<DragButton>().beingGrabbed == true)
        {
            dis1 = Vector2.Distance(slots1[4].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            dis2 = Vector2.Distance(slots2[4].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            dis3 = Vector2.Distance(slots3[4].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            dis4 = Vector2.Distance(slots4[4].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            dis5 = Vector2.Distance(slots5[4].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            dis6 = Vector2.Distance(slots6[4].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

            CheckSlotLevel1(dis1, dis2, dis3, dis4, dis5, dis6, choice);
        }
        else
        {
            if (choice.GetComponent<DragButton>().correct == true)
            {
                choice.GetComponent<DragButton>().correct = false;
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
                if (choice.GetComponent<DragButton>().slotSetNumber == 1)
                {
                    slots1[4].GetComponent<Slots>().CorrectSlot();
                    slots1[4].GetComponent<Slots>().SetText();
                    slots2[4].GetComponent<Slots>().slotAccepting = true;
                    slots2[0].GetComponent<Slots>().SetTextColor("#33FF00");
                    slots2[2].GetComponent<Slots>().SetTextColor("#FFFF00");
                    slots2[4].GetComponent<Slots>().SetTextColor("#FFFFFF");
                    numCorrect++;
                }
                else if (choice.GetComponent<DragButton>().slotSetNumber == 2)
                {
                    slots2[4].GetComponent<Slots>().CorrectSlot();
                    slots2[4].GetComponent<Slots>().SetText();
                    slots3[4].GetComponent<Slots>().slotAccepting = true;
                    slots3[0].GetComponent<Slots>().SetTextColor("#33FF00");
                    slots3[2].GetComponent<Slots>().SetTextColor("#FFFF00");
                    slots3[4].GetComponent<Slots>().SetTextColor("#FFFFFF");
                    numCorrect++;
                }
                else if (choice.GetComponent<DragButton>().slotSetNumber == 3)
                {
                    slots3[4].GetComponent<Slots>().CorrectSlot();
                    slots3[4].GetComponent<Slots>().SetText();
                    slots4[4].GetComponent<Slots>().slotAccepting = true;
                    slots4[0].GetComponent<Slots>().SetTextColor("#33FF00");
                    slots4[2].GetComponent<Slots>().SetTextColor("#FFFF00");
                    slots4[4].GetComponent<Slots>().SetTextColor("#FFFFFF");
                    numCorrect++;
                }
                else if (choice.GetComponent<DragButton>().slotSetNumber == 4)
                {
                    slots4[4].GetComponent<Slots>().CorrectSlot();
                    slots4[4].GetComponent<Slots>().SetText();
                    slots5[4].GetComponent<Slots>().slotAccepting = true;
                    slots5[0].GetComponent<Slots>().SetTextColor("#33FF00");
                    slots5[2].GetComponent<Slots>().SetTextColor("#FFFF00");
                    slots5[4].GetComponent<Slots>().SetTextColor("#FFFFFF");
                    numCorrect++;
                }
                else if (choice.GetComponent<DragButton>().slotSetNumber == 5)
                {
                    slots5[4].GetComponent<Slots>().CorrectSlot();
                    slots5[4].GetComponent<Slots>().SetText();
                    slots6[4].GetComponent<Slots>().slotAccepting = true;
                    slots6[0].GetComponent<Slots>().SetTextColor("#33FF00");
                    slots6[2].GetComponent<Slots>().SetTextColor("#FFFF00");
                    slots6[4].GetComponent<Slots>().SetTextColor("#FFFFFF");
                    numCorrect++;
                }
                else if (choice.GetComponent<DragButton>().slotSetNumber == 6)
                {
                    slots6[4].GetComponent<Slots>().CorrectSlot();
                    slots6[4].GetComponent<Slots>().SetText();
                    numCorrect++;
                }
                choice.GetComponent<DragButton>().slotSetNumber = 0;
            }
        }
    }


    void CheckSlotLevel1(float dis1, float dis2, float dis3, float dis4, float dis5, float dis6, GameObject choice)
    {
        if (dis1 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == slots1[4].GetComponent<Slots>().answerNumber.ToString())
            {
                if (slots1[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = slots1[4].GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 1;
                }
            }
            else
            {
                if (slots1[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }
            }
        }
        else if (dis2 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == slots2[4].GetComponent<Slots>().answerNumber.ToString())
            {
                if (slots2[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = slots2[4].GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 2;
                }
            }
            else
            {
                if (slots2[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }
            }
        }
        else if (dis3 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == slots3[4].GetComponent<Slots>().answerNumber.ToString())
            {
                if (slots3[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = slots3[4].GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 3;
                }
            }
            else
            {
                if (slots3[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }
            }
        }
        else if (dis4 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == slots4[4].GetComponent<Slots>().answerNumber.ToString())
            {
                if (slots4[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = slots4[4].GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 4;
                }
            }
            else
            {
                if (slots4[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }
            }
        }
        else if (dis5 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == slots5[4].GetComponent<Slots>().answerNumber.ToString())
            {
                if (slots5[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = slots5[4].GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 5;
                }
            }
            else
            {
                if (slots5[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().atWrongNumber = true;
                }
            }
        }
        else if (dis6 < 1)
        {
            if (choice.GetComponent<DragButton>().choiceText == slots6[4].GetComponent<Slots>().answerNumber.ToString())
            {
                if (slots6[4].GetComponent<Slots>().slotAccepting == true)
                {
                    choice.GetComponent<DragButton>().answerPosition = slots6[4].GetComponent<Transform>().transform.position;
                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
                    choice.GetComponent<DragButton>().slotNumber = 6;
                }
            }
            else
            {
                if (slots5[4].GetComponent<Slots>().slotAccepting == true)
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

    void AllCorrectLevel1()
    {
        if (numCorrect == 5)
        {
            nextButton.SetActive(true);
            //slots1[].GetComponent<Animator>().Play("LeftOperandSolved");
            //operation.GetComponent<Animator>().Play("OperationSolved");
            //rightOperand.GetComponent<Animator>().Play("RightOperandSolved");
            //equalOperation.GetComponent<Animator>().Play("EqualOperationSolved");
            //expression.GetComponent<Animator>().Play("ExpressionSolved");
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

    //public void imagesOff()
    //{
    //    backGroundImage.GetComponent<SpriteRenderer>().enabled = false;
    //    canv1.GetComponent<Canvas>().enabled = false;
    //    canv2.GetComponent<Canvas>().enabled = false;
    //    confetti.Stop();
    //}

    //public void imagesOn()
    //{
    //    backGroundImage.GetComponent<SpriteRenderer>().enabled = true;
    //    canv1.GetComponent<Canvas>().enabled = true;
    //    canv2.GetComponent<Canvas>().enabled = true;
    //    choice1.GetComponent<DragButton>().PlayAnim("Choice1Intro");
    //    choice2.GetComponent<DragButton>().PlayAnim("Choice2Intro");
    //    choice3.GetComponent<DragButton>().PlayAnim("Choice3Intro");
    //    choice4.GetComponent<DragButton>().PlayAnim("Choice4Intro");
    //    choice5.GetComponent<DragButton>().PlayAnim("Choice5Intro");
    //    GameManager.Instance.AudioManager.musicSource.UnPause();
    //    isTimerRunning = true;
    //}


    //public void ResetScene()
    //{
    //    nextButton.SetActive(false);
    //    setText();
    //    setChoices();
    //    setButton();
    //    numCorrect = 0;
    //    leftOperand.GetComponent<Animator>().Play("LeftOperandIdle");
    //    operation.GetComponent<Animator>().Play("OperationIdle");
    //    rightOperand.GetComponent<Animator>().Play("RightOperandIdle");
    //    equalOperation.GetComponent<Animator>().Play("EqualOperationIdle");
    //    expression.GetComponent<Animator>().Play("ExpressionIdle");
    //}

    //void setButton()
    //{
    //    choice1.GetComponent<DragButton>().ResetChoices();
    //    choice2.GetComponent<DragButton>().ResetChoices();
    //    choice3.GetComponent<DragButton>().ResetChoices();
    //    choice4.GetComponent<DragButton>().ResetChoices();
    //    choice5.GetComponent<DragButton>().ResetChoices();
    //}

    void ShoutSupport()
    {
        GameManager.Instance.AudioManager.PlaySound("SupportShouts", 1.0f);
        timeRemaining = 10.0f;
    }
}












//int[] set1 = new int[3];
//int[] set2 = new int[3];
//int[] set3 = new int[3];
//int[] set4 = new int[3];
//int[] set5 = new int[3];
//int[] set6 = new int[3];

//int[] randomizedSlots = new int[6];

//public GameObject[] slots1;
//public GameObject[] slots2;
//public GameObject[] slots3;
//public GameObject[] slots4;
//public GameObject[] slots5;
//public GameObject[] slots6;
//Color colorC;

//int passingAmount = 0;

//List<int> response = new List<int>();

//public GameObject choice1;
//public GameObject choice2;
//public GameObject choice3;
//public GameObject choice4;
//public GameObject choice5;
//public GameObject choice6;
//public GameObject choice7;

//public float dist;

//// Start is called before the first frame update
//void Start()
//{
//    ColorUtility.TryParseHtmlString("#2B7B55", out colorC);
//    SetAllAnswers();
//    SetText();
//    setChoices();
//}

//// Update is called once per frame
//void Update()
//{
//    if (choice1 != null) { inRightSpot(choice1); }
//    if (choice2 != null) { inRightSpot(choice2); }
//    if (choice3 != null) { inRightSpot(choice3); }
//    if (choice4 != null) { inRightSpot(choice4); }
//    if (choice5 != null) { inRightSpot(choice5); }
//    if (choice6 != null) { inRightSpot(choice6); }
//    if (choice7 != null) { inRightSpot(choice7); }

//}

//private void SetAnswers(int[] sets)
//{
//    if (GameManager.Instance.GetLevel() == 1)
//    {
//        sets[0] = Random.Range(1, 6);
//        sets[1] = Random.Range(1, 6);
//        sets[2] = sets[0] * sets[1];
//    }
//    else if (GameManager.Instance.GetLevel() == 2)
//    {
//        sets[0] = Random.Range(1, 11);
//        sets[2] = Random.Range(1, 11);
//        sets[4] = sets[0] * sets[2];
//    }
//    else if (GameManager.Instance.GetLevel() == 3)
//    {
//        sets[0] = Random.Range(1, 21);
//        sets[2] = Random.Range(1, 21);
//        sets[4] = sets[0] * sets[2];
//    }
//}

//public void SetAllAnswers()
//{
//    SetAnswers(set1);
//    SetAnswers(set2);
//    SetAnswers(set3);
//    SetAnswers(set4);
//    SetAnswers(set5);
//    SetAnswers(set6);

//    randomizedSlots[0] = Random.Range(0, 3);
//    randomizedSlots[1] = Random.Range(0, 3);
//    randomizedSlots[2] = Random.Range(0, 3);
//    randomizedSlots[3] = Random.Range(0, 3);
//    randomizedSlots[4] = Random.Range(0, 3);
//    randomizedSlots[5] = Random.Range(0, 3);
//}

//void SetText()
//{
//    if (GameManager.Instance.GetPracticeLevel() == 1)
//    {
//        SetForLevel(slots1, set1);
//        SetForLevel(slots2, set2);
//        SetForLevel(slots3, set3);
//        SetForLevel(slots4, set4);
//        SetForLevel(slots5, set5);
//        SetForLevel(slots6, set6);
//        slots1[0].GetComponentInChildren<TMP_Text>().color = Color.green;
//        slots1[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
//        slots1[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//        slots1[2].GetComponent<SlotPractice>().canBeSolved = true;
//    }
//    else if (GameManager.Instance.GetPracticeLevel() == 2)
//    {
//        SetForLevel(slots1, set1);
//        SetForLevel(slots2, set2);
//        SetForLevel(slots3, set3);
//        SetForLevel(slots4, set4);
//        SetForLevel(slots5, set5);
//        SetForLevel(slots6, set6);
//        slots1[2].GetComponent<SlotPractice>().canBeSolved = true;
//        slots2[2].GetComponent<SlotPractice>().canBeSolved = true;
//        slots3[2].GetComponent<SlotPractice>().canBeSolved = true;
//        slots4[2].GetComponent<SlotPractice>().canBeSolved = true;
//        slots5[2].GetComponent<SlotPractice>().canBeSolved = true;
//        slots6[2].GetComponent<SlotPractice>().canBeSolved = true;
//    }
//    else
//    {
//        LevelThree(slots1, set1, randomizedSlots[0]);
//        LevelThree(slots2, set2, randomizedSlots[1]);
//        LevelThree(slots3, set3, randomizedSlots[2]);
//        LevelThree(slots4, set4, randomizedSlots[3]);
//        LevelThree(slots5, set5, randomizedSlots[4]);
//        LevelThree(slots6, set6, randomizedSlots[5]);
//        slots1[randomizedSlots[0]].GetComponent<SlotPractice>().canBeSolved = true;
//        slots2[randomizedSlots[1]].GetComponent<SlotPractice>().canBeSolved = true;
//        slots3[randomizedSlots[2]].GetComponent<SlotPractice>().canBeSolved = true;
//        slots4[randomizedSlots[3]].GetComponent<SlotPractice>().canBeSolved = true;
//        slots5[randomizedSlots[4]].GetComponent<SlotPractice>().canBeSolved = true;
//        slots6[randomizedSlots[5]].GetComponent<SlotPractice>().canBeSolved = true;
//    }
//}

//void LevelThree(GameObject[] slots, int[] sets, int randSlot)
//{
//    if (randSlot == 0)
//    {
//        slots[0].GetComponentInChildren<TMP_Text>().text = "?";
//        slots[1].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
//        slots[2].GetComponentInChildren<TMP_Text>().text = sets[2].ToString();
//        slots[0].GetComponentInChildren<Image>().enabled = true;
//    }
//    else if (randSlot == 1)
//    {
//        slots[0].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
//        slots[1].GetComponentInChildren<TMP_Text>().text = "?";
//        slots[2].GetComponentInChildren<TMP_Text>().text = sets[2].ToString();
//        slots[1].GetComponentInChildren<Image>().enabled = true;
//    }
//    else
//    {
//        slots[0].GetComponentInChildren<TMP_Text>().text = sets[0].ToString();
//        slots[1].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
//        slots[2].GetComponentInChildren<TMP_Text>().text = "?";
//        slots[2].GetComponentInChildren<Image>().enabled = true;

//    }
//    slots[0].GetComponentInChildren<TMP_Text>().color = Color.green;
//    slots[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
//    slots[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//}

//void SetForLevel(GameObject[] slots, int[] sets)
//{
//    if (GameManager.Instance.GetPracticeLevel() == 1)
//    {
//        slots[0].GetComponentInChildren<TMP_Text>().text = sets[0].ToString();
//        slots[1].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
//        slots[2].GetComponentInChildren<TMP_Text>().text = "?";
//        slots[2].GetComponent<Image>().enabled = true;
//        slots[0].GetComponentInChildren<TMP_Text>().color = colorC;
//        slots[1].GetComponentInChildren<TMP_Text>().color = colorC;
//        slots[2].GetComponentInChildren<TMP_Text>().color = colorC;
//    }
//    else if (GameManager.Instance.GetPracticeLevel() == 2)
//    {
//        slots[0].GetComponentInChildren<TMP_Text>().text = sets[0].ToString();
//        slots[1].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
//        slots[2].GetComponentInChildren<TMP_Text>().text = "?";
//        slots[2].GetComponent<Image>().enabled = true;
//        slots[0].GetComponentInChildren<TMP_Text>().color = Color.green;
//        slots[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
//        slots[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//    }
//}

//private void addResponse()
//{
//    if (GameManager.Instance.GetPracticeLevel() == 1)
//    {
//        int left = 0;
//        if (slots1[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set1[2]);
//            left++;
//        }
//        if (slots2[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set2[2]);
//            left++;
//        }
//        if (slots3[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set3[2]);
//            left++;
//        }
//        if (slots4[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set4[2]);
//            left++;
//        }
//        if (slots5[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set5[2]);
//            left++;
//        }
//        if (slots6[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set6[2]);
//            left++;
//        }
//        for (int i = left; i < 7; i++)
//        {
//            if (GameManager.Instance.GetLevel() == 1)
//            {
//                response.Add(Random.Range(1, 6));
//            }
//            else if (GameManager.Instance.GetLevel() == 2)
//            {
//                response.Add(Random.Range(1, 11));
//            }
//            else
//            {
//                response.Add(Random.Range(1, 21));
//            }
//        }

//    }
//    else if (GameManager.Instance.GetPracticeLevel() == 2)
//    {
//        int left = 0;
//        if (slots1[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set1[2]);
//            left++;
//        }
//        if (slots2[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set2[2]);
//            left++;
//        }
//        if (slots3[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set3[2]);
//            left++;
//        }
//        if (slots4[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set4[2]);
//            left++;
//        }
//        if (slots5[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set5[2]);
//            left++;
//        }
//        if (slots6[2].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set6[2]);
//            left++;
//        }
//        for (int i = left; i < 7; i++)
//        {
//            if (GameManager.Instance.GetLevel() == 1)
//            {
//                response.Add(Random.Range(1, 6));
//            }
//            else if (GameManager.Instance.GetLevel() == 2)
//            {
//                response.Add(Random.Range(1, 11));
//            }
//            else
//            {
//                response.Add(Random.Range(1, 21));
//            }
//        }
//    }
//    else
//    {
//        int left = 0;
//        if (slots1[randomizedSlots[0]].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set1[randomizedSlots[0]]);
//            left++;
//        }
//        if (slots2[randomizedSlots[1]].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set2[randomizedSlots[1]]);
//            left++;
//        }
//        if (slots3[randomizedSlots[2]].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set3[randomizedSlots[2]]);
//            left++;
//        }
//        if (slots4[randomizedSlots[3]].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set4[randomizedSlots[3]]);
//            left++;
//        }
//        if (slots5[randomizedSlots[4]].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set5[randomizedSlots[4]]);
//            left++;
//        }
//        if (slots6[randomizedSlots[5]].GetComponent<SlotPractice>().solved == false)
//        {
//            response.Add(set6[randomizedSlots[5]]);
//            left++;
//        }
//        for (int i = left; i < 7; i++)
//        {
//            if (GameManager.Instance.GetLevel() == 1)
//            {
//                response.Add(Random.Range(1, 6));
//            }
//            else if (GameManager.Instance.GetLevel() == 2)
//            {
//                response.Add(Random.Range(1, 11));
//            }
//            else
//            {
//                response.Add(Random.Range(1, 21));
//            }
//        }
//    }
//}
//public static void Shuffle<T>(List<T> list)
//{
//    int n = list.Count;
//    while (n > 1)
//    {
//        n--;
//        int k = Random.Range(0, n + 1);
//        T value = list[k];
//        list[k] = list[n];
//        list[n] = value;
//    }
//}

//void setChoices()
//{
//    addResponse();
//    Shuffle(response);
//    if (GameManager.Instance.GetPracticeLevel() == 1)
//    {
//        choice1.GetComponentInChildren<TMP_Text>().text = response[0].ToString();
//        choice2.GetComponentInChildren<TMP_Text>().text = response[1].ToString();
//        choice3.GetComponentInChildren<TMP_Text>().text = response[2].ToString();
//        choice4.GetComponentInChildren<TMP_Text>().text = response[3].ToString();
//        choice5.GetComponentInChildren<TMP_Text>().text = response[4].ToString();
//        choice6.GetComponentInChildren<TMP_Text>().text = response[5].ToString();
//        choice7.GetComponentInChildren<TMP_Text>().text = response[6].ToString();
//    }
//    else if (GameManager.Instance.GetPracticeLevel() == 2)
//    {
//        choice1.GetComponentInChildren<TMP_Text>().text = response[0].ToString();
//        choice2.GetComponentInChildren<TMP_Text>().text = response[1].ToString();
//        choice3.GetComponentInChildren<TMP_Text>().text = response[2].ToString();
//        choice4.GetComponentInChildren<TMP_Text>().text = response[3].ToString();
//        choice5.GetComponentInChildren<TMP_Text>().text = response[4].ToString();
//        choice6.GetComponentInChildren<TMP_Text>().text = response[5].ToString();
//        choice7.GetComponentInChildren<TMP_Text>().text = response[6].ToString();
//    }
//    else
//    {
//        choice1.GetComponentInChildren<TMP_Text>().text = response[0].ToString();
//        choice2.GetComponentInChildren<TMP_Text>().text = response[1].ToString();
//        choice3.GetComponentInChildren<TMP_Text>().text = response[2].ToString();
//        choice4.GetComponentInChildren<TMP_Text>().text = response[3].ToString();
//        choice5.GetComponentInChildren<TMP_Text>().text = response[4].ToString();
//        choice6.GetComponentInChildren<TMP_Text>().text = response[5].ToString();
//        choice7.GetComponentInChildren<TMP_Text>().text = response[6].ToString();
//    }
//}

//void inRightSpot(GameObject choice)
//{
//    if (GameManager.Instance.GetPracticeLevel() == 1)
//    {
//        float dis1 = Vector2.Distance(slots1[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis2 = Vector2.Distance(slots2[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis3 = Vector2.Distance(slots3[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis4 = Vector2.Distance(slots4[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis5 = Vector2.Distance(slots5[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis6 = Vector2.Distance(slots6[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

//        if (dis1 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set1[2].ToString())
//            {
//                if (slots1[2].GetComponent<SlotPractice>().canBeSolved == true && slots1[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots1[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots1[2].GetComponentInChildren<TMP_Text>().text = set1[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots1[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots1[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots2[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
//                        slots2[0].GetComponentInChildren<TMP_Text>().color = Color.green;
//                        slots2[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
//                        slots2[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots1[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis2 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set2[2].ToString())
//            {
//                if (slots2[2].GetComponent<SlotPractice>().canBeSolved == true && slots2[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots2[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots2[2].GetComponentInChildren<TMP_Text>().text = set2[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots2[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots2[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots3[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
//                        slots3[0].GetComponentInChildren<TMP_Text>().color = Color.green;
//                        slots3[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
//                        slots3[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots2[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis3 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set3[2].ToString())
//            {
//                if (slots3[2].GetComponent<SlotPractice>().canBeSolved == true && slots3[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots3[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots3[2].GetComponentInChildren<TMP_Text>().text = set3[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots3[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots3[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots4[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
//                        slots4[0].GetComponentInChildren<TMP_Text>().color = Color.green;
//                        slots4[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
//                        slots4[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots3[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }

//        }
//        else if (dis4 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set4[2].ToString())
//            {
//                if (slots4[2].GetComponent<SlotPractice>().canBeSolved == true && slots4[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots4[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots4[2].GetComponentInChildren<TMP_Text>().text = set4[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots4[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots4[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots5[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
//                        slots5[0].GetComponentInChildren<TMP_Text>().color = Color.green;
//                        slots5[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
//                        slots5[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots4[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis5 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set5[2].ToString())
//            {
//                if (slots5[2].GetComponent<SlotPractice>().canBeSolved == true && slots5[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots5[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots5[2].GetComponentInChildren<TMP_Text>().text = set5[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots5[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots5[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots6[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
//                        slots6[0].GetComponentInChildren<TMP_Text>().color = Color.green;
//                        slots6[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
//                        slots6[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots5[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis6 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set6[2].ToString())
//            {
//                if (slots6[2].GetComponent<SlotPractice>().canBeSolved == true && slots6[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots6[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots6[2].GetComponentInChildren<TMP_Text>().text = set6[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots6[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots6[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots6[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else
//        {
//            choice.GetComponent<DragButton>().isInCorrectSpot = false;
//        }
//    }
//    else if (GameManager.Instance.GetPracticeLevel() == 2)
//    {
//        float dis1 = Vector2.Distance(slots1[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis2 = Vector2.Distance(slots2[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis3 = Vector2.Distance(slots3[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis4 = Vector2.Distance(slots4[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis5 = Vector2.Distance(slots5[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis6 = Vector2.Distance(slots6[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

//        if (dis1 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set1[2].ToString())
//            {
//                if (slots1[2].GetComponent<SlotPractice>().canBeSolved == true && slots1[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots1[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots1[2].GetComponentInChildren<TMP_Text>().text = set1[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots1[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots1[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots1[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis2 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set2[2].ToString())
//            {
//                if (slots2[2].GetComponent<SlotPractice>().canBeSolved == true && slots2[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots2[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots2[2].GetComponentInChildren<TMP_Text>().text = set2[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots2[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots2[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots2[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis3 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set3[2].ToString())
//            {
//                if (slots3[2].GetComponent<SlotPractice>().canBeSolved == true && slots3[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots3[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots3[2].GetComponentInChildren<TMP_Text>().text = set3[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots3[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots3[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots3[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }

//        }
//        else if (dis4 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set4[2].ToString())
//            {
//                if (slots4[2].GetComponent<SlotPractice>().canBeSolved == true && slots4[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots4[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots4[2].GetComponentInChildren<TMP_Text>().text = set4[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots4[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots4[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots4[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis5 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set5[2].ToString())
//            {
//                if (slots5[2].GetComponent<SlotPractice>().canBeSolved == true && slots5[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots5[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots5[2].GetComponentInChildren<TMP_Text>().text = set5[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots5[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots5[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots5[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis6 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set6[2].ToString())
//            {
//                if (slots6[2].GetComponent<SlotPractice>().canBeSolved == true && slots6[2].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots6[2].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots6[2].GetComponentInChildren<TMP_Text>().text = set6[2].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots6[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots6[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots6[2]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else
//        {
//            choice.GetComponent<DragButton>().isInCorrectSpot = false;
//        }
//    }
//    else
//    {
//        float dis1 = Vector2.Distance(slots1[randomizedSlots[0]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis2 = Vector2.Distance(slots2[randomizedSlots[1]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis3 = Vector2.Distance(slots3[randomizedSlots[2]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis4 = Vector2.Distance(slots4[randomizedSlots[3]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis5 = Vector2.Distance(slots5[randomizedSlots[4]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
//        float dis6 = Vector2.Distance(slots6[randomizedSlots[5]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

//        if (dis1 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set1[randomizedSlots[0]].ToString())
//            {
//                if (slots1[randomizedSlots[0]].GetComponent<SlotPractice>().canBeSolved == true && slots1[randomizedSlots[0]].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots1[randomizedSlots[0]].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots1[randomizedSlots[0]].GetComponentInChildren<TMP_Text>().text = set1[randomizedSlots[0]].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots1[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots1[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots1[randomizedSlots[0]]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis2 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set2[randomizedSlots[1]].ToString())
//            {
//                if (slots2[randomizedSlots[1]].GetComponent<SlotPractice>().canBeSolved == true && slots2[randomizedSlots[1]].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots2[randomizedSlots[1]].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots2[randomizedSlots[1]].GetComponentInChildren<TMP_Text>().text = set2[randomizedSlots[1]].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots2[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots2[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots2[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots2[randomizedSlots[1]]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis3 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set3[randomizedSlots[2]].ToString())
//            {
//                if (slots3[randomizedSlots[1]].GetComponent<SlotPractice>().canBeSolved == true && slots3[randomizedSlots[1]].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots3[randomizedSlots[1]].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots3[randomizedSlots[1]].GetComponentInChildren<TMP_Text>().text = set3[randomizedSlots[1]].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots3[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots3[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots3[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots3[randomizedSlots[1]]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }

//        }
//        else if (dis4 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set4[randomizedSlots[3]].ToString())
//            {
//                if (slots4[randomizedSlots[randomizedSlots[3]]].GetComponent<SlotPractice>().canBeSolved == true && slots4[randomizedSlots[3]].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots4[randomizedSlots[3]].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots4[randomizedSlots[3]].GetComponentInChildren<TMP_Text>().text = set4[randomizedSlots[3]].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots4[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots4[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots4[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots4[randomizedSlots[3]]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis5 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set5[randomizedSlots[4]].ToString())
//            {
//                if (slots5[randomizedSlots[4]].GetComponent<SlotPractice>().canBeSolved == true && slots5[randomizedSlots[4]].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots5[randomizedSlots[4]].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots5[randomizedSlots[4]].GetComponentInChildren<TMP_Text>().text = set5[randomizedSlots[4]].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots5[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots5[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots5[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots5[randomizedSlots[4]]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else if (dis6 < 1)
//        {
//            if (choice.GetComponentInChildren<TMP_Text>().text == set6[randomizedSlots[5]].ToString())
//            {
//                if (slots6[randomizedSlots[5]].GetComponent<SlotPractice>().canBeSolved == true && slots6[randomizedSlots[5]].GetComponent<SlotPractice>().solved == false)
//                {
//                    choice.GetComponent<DragButton>().answerPosition = slots6[randomizedSlots[5]].GetComponent<Transform>().transform.position;
//                    choice.GetComponent<DragButton>().isInCorrectSpot = true;
//                    slots6[randomizedSlots[5]].GetComponentInChildren<TMP_Text>().text = set6[randomizedSlots[5]].ToString();
//                    if (choice.GetComponent<DragButton>().correct == true)
//                    {
//                        slots6[2].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots6[1].GetComponentInChildren<TMP_Text>().color = Color.white;
//                        slots6[0].GetComponentInChildren<TMP_Text>().color = Color.white;
//                    }
//                }
//                whenCorrect(choice, slots6[randomizedSlots[5]]);
//            }
//            else
//            {
//                choice.GetComponent<DragButton>().isInCorrectSpot = false;
//                //bugsy.Play("NotCorrect");
//            }
//        }
//        else
//        {
//            choice.GetComponent<DragButton>().isInCorrectSpot = false;
//        }
//    }
//}

//void whenCorrect(GameObject choice, GameObject slot)
//{
//    if (choice.GetComponent<DragButton>().correct == true)
//    {
//        choice.SetActive(false);
//        choice.GetComponent<DragButton>().correct = false;
//        slot.GetComponent<SlotPractice>().solved = true;
//        slot.GetComponent<SlotPractice>().canBeSolved = false;
//        //bugsy.Play("Correct");
//        passingAmount++;
//    }
//}