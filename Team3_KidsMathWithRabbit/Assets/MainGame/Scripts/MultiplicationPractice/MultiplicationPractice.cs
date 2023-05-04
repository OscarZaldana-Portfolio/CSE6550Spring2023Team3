using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class MultiplicationPractice : MonoBehaviour
{
    int[] set1 = new int[3];
    int[] set2 = new int[3];
    int[] set3 = new int[3];
    int[] set4 = new int[3];
    int[] set5 = new int[3];
    int[] set6 = new int[3];
    
    int[] randomizedSlots = new int[6];

    public GameObject[] slots1;
    public GameObject[] slots2;
    public GameObject[] slots3;
    public GameObject[] slots4;
    public GameObject[] slots5;
    public GameObject[] slots6;
    Color colorC;

    int passingAmount = 0;

    List<int> response = new List<int>();

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;
    public GameObject choice5;
    public GameObject choice6;
    public GameObject choice7;

    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#2B7B55", out colorC);
        SetAllAnswers();
        SetText();
        setChoices();
    }

    // Update is called once per frame
    void Update()
    {
        if (choice1 != null) { inRightSpot(choice1); }
        if (choice2 != null) { inRightSpot(choice2); }
        if (choice3 != null) { inRightSpot(choice3); }
        if (choice4 != null) { inRightSpot(choice4); }
        if (choice5 != null) { inRightSpot(choice5); }
        if (choice6 != null) { inRightSpot(choice6); }
        if (choice7 != null) { inRightSpot(choice7); }

    }

    private void SetAnswers(int[] sets)
    {
        if (GameManager.Instance.GetLevel() == 1)
        {
            sets[0] = Random.Range(1, 6);
            sets[1] = Random.Range(1, 6);
            sets[2] = sets[0] * sets[1];
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            sets[0] = Random.Range(1, 11);
            sets[2] = Random.Range(1, 11);
            sets[4] = sets[0] * sets[2];
        }
        else if (GameManager.Instance.GetLevel() == 3)
        {
            sets[0] = Random.Range(1, 21);
            sets[2] = Random.Range(1, 21);
            sets[4] = sets[0] * sets[2];
        }
    }

    public void SetAllAnswers()
    {
        SetAnswers(set1);
        SetAnswers(set2);
        SetAnswers(set3);
        SetAnswers(set4);
        SetAnswers(set5);
        SetAnswers(set6);

        randomizedSlots[0] = Random.Range(0, 3);
        randomizedSlots[1] = Random.Range(0, 3);
        randomizedSlots[2] = Random.Range(0, 3);
        randomizedSlots[3] = Random.Range(0, 3);
        randomizedSlots[4] = Random.Range(0, 3);
        randomizedSlots[5] = Random.Range(0, 3);
    }

    void SetText() { 
        if (GameManager.Instance.GetPracticeLevel() == 1)
        {
            SetForLevel(slots1, set1);
            SetForLevel(slots2, set2);
            SetForLevel(slots3, set3);
            SetForLevel(slots4, set4);
            SetForLevel(slots5, set5);
            SetForLevel(slots6, set6);
            slots1[0].GetComponentInChildren<TMP_Text>().color = Color.green;
            slots1[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
            slots1[2].GetComponentInChildren<TMP_Text>().color = Color.white;
            slots1[2].GetComponent<SlotPractice>().canBeSolved = true;
        }
        else if (GameManager.Instance.GetPracticeLevel() == 2)
        {
            SetForLevel(slots1, set1);
            SetForLevel(slots2, set2);
            SetForLevel(slots3, set3);
            SetForLevel(slots4, set4);
            SetForLevel(slots5, set5);
            SetForLevel(slots6, set6);
            slots1[2].GetComponent<SlotPractice>().canBeSolved = true;
            slots2[2].GetComponent<SlotPractice>().canBeSolved = true;
            slots3[2].GetComponent<SlotPractice>().canBeSolved = true;
            slots4[2].GetComponent<SlotPractice>().canBeSolved = true;
            slots5[2].GetComponent<SlotPractice>().canBeSolved = true;
            slots6[2].GetComponent<SlotPractice>().canBeSolved = true;
        }
        else
        {
            LevelThree(slots1, set1, randomizedSlots[0]);
            LevelThree(slots2, set2, randomizedSlots[1]);
            LevelThree(slots3, set3, randomizedSlots[2]);
            LevelThree(slots4, set4, randomizedSlots[3]);
            LevelThree(slots5, set5, randomizedSlots[4]);
            LevelThree(slots6, set6, randomizedSlots[5]);
            slots1[randomizedSlots[0]].GetComponent<SlotPractice>().canBeSolved = true;
            slots2[randomizedSlots[1]].GetComponent<SlotPractice>().canBeSolved = true;
            slots3[randomizedSlots[2]].GetComponent<SlotPractice>().canBeSolved = true;
            slots4[randomizedSlots[3]].GetComponent<SlotPractice>().canBeSolved = true;
            slots5[randomizedSlots[4]].GetComponent<SlotPractice>().canBeSolved = true;
            slots6[randomizedSlots[5]].GetComponent<SlotPractice>().canBeSolved = true;
        }
    }

    void LevelThree(GameObject[] slots, int[] sets, int randSlot)
    {
        if (randSlot == 0)
        {
            slots[0].GetComponentInChildren<TMP_Text>().text = "?";
            slots[1].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
            slots[2].GetComponentInChildren<TMP_Text>().text = sets[2].ToString();
            slots[0].GetComponentInChildren<Image>().enabled = true;
        }
        else if (randSlot == 1)
        {
            slots[0].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
            slots[1].GetComponentInChildren<TMP_Text>().text = "?";
            slots[2].GetComponentInChildren<TMP_Text>().text = sets[2].ToString();
            slots[1].GetComponentInChildren<Image>().enabled = true;
        }
        else
        {
            slots[0].GetComponentInChildren<TMP_Text>().text = sets[0].ToString();
            slots[1].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
            slots[2].GetComponentInChildren<TMP_Text>().text = "?";
            slots[2].GetComponentInChildren<Image>().enabled = true;

        }
        slots[0].GetComponentInChildren<TMP_Text>().color = Color.green;
        slots[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
        slots[2].GetComponentInChildren<TMP_Text>().color = Color.white;
    }

    void SetForLevel(GameObject[] slots, int[] sets)
    {
        if (GameManager.Instance.GetPracticeLevel() == 1)
        {
            slots[0].GetComponentInChildren<TMP_Text>().text = sets[0].ToString();
            slots[1].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
            slots[2].GetComponentInChildren<TMP_Text>().text = "?";
            slots[2].GetComponent<Image>().enabled = true;
            slots[0].GetComponentInChildren<TMP_Text>().color = colorC;
            slots[1].GetComponentInChildren<TMP_Text>().color = colorC;
            slots[2].GetComponentInChildren<TMP_Text>().color = colorC;
        }
        else if (GameManager.Instance.GetPracticeLevel() == 2)
        {
            slots[0].GetComponentInChildren<TMP_Text>().text = sets[0].ToString();
            slots[1].GetComponentInChildren<TMP_Text>().text = sets[1].ToString();
            slots[2].GetComponentInChildren<TMP_Text>().text = "?";
            slots[2].GetComponent<Image>().enabled = true;
            slots[0].GetComponentInChildren<TMP_Text>().color = Color.green;
            slots[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
            slots[2].GetComponentInChildren<TMP_Text>().color = Color.white;
        }
    }

    private void addResponse()
    {
        if (GameManager.Instance.GetPracticeLevel() == 1)
        {
            int left = 0;
            if (slots1[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set1[2]);
                left++;
            }
            if (slots2[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set2[2]);
                left++;
            }
            if (slots3[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set3[2]);
                left++;
            }
            if (slots4[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set4[2]);
                left++;
            }
            if (slots5[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set5[2]);
                left++;
            }
            if (slots6[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set6[2]);
                left++;
            }
            for (int i = left; i < 7; i++)
            {
                if (GameManager.Instance.GetLevel() == 1)
                {
                    response.Add(Random.Range(1, 6));
                }
                else if (GameManager.Instance.GetLevel() == 2)
                {
                    response.Add(Random.Range(1, 11));
                }
                else
                {
                    response.Add(Random.Range(1, 21));
                }
            }

        }
        else if (GameManager.Instance.GetPracticeLevel() == 2)
        {
            int left = 0;
            if (slots1[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set1[2]);
                left++;
            }
            if (slots2[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set2[2]);
                left++;
            }
            if (slots3[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set3[2]);
                left++;
            }
            if (slots4[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set4[2]);
                left++;
            }
            if (slots5[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set5[2]);
                left++;
            }
            if (slots6[2].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set6[2]);
                left++;
            }
            for (int i = left; i < 7; i++)
            {
                if (GameManager.Instance.GetLevel() == 1)
                {
                    response.Add(Random.Range(1, 6));
                }
                else if (GameManager.Instance.GetLevel() == 2)
                {
                    response.Add(Random.Range(1, 11));
                }
                else
                {
                    response.Add(Random.Range(1, 21));
                }
            }
        }
        else
        {
            int left = 0;
            if (slots1[randomizedSlots[0]].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set1[randomizedSlots[0]]);
                left++;
            }
            if (slots2[randomizedSlots[1]].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set2[randomizedSlots[1]]);
                left++;
            }
            if (slots3[randomizedSlots[2]].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set3[randomizedSlots[2]]);
                left++;
            }
            if (slots4[randomizedSlots[3]].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set4[randomizedSlots[3]]);
                left++;
            }
            if (slots5[randomizedSlots[4]].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set5[randomizedSlots[4]]);
                left++;
            }
            if (slots6[randomizedSlots[5]].GetComponent<SlotPractice>().solved == false)
            {
                response.Add(set6[randomizedSlots[5]]);
                left++;
            }
            for (int i = left; i < 7; i++)
            {
                if (GameManager.Instance.GetLevel() == 1)
                {
                    response.Add(Random.Range(1, 6));
                }
                else if (GameManager.Instance.GetLevel() == 2)
                {
                    response.Add(Random.Range(1, 11));
                }
                else
                {
                    response.Add(Random.Range(1, 21));
                }
            }
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
        addResponse();
        Shuffle(response);
        if (GameManager.Instance.GetPracticeLevel() == 1)
        {
            choice1.GetComponentInChildren<TMP_Text>().text = response[0].ToString();
            choice2.GetComponentInChildren<TMP_Text>().text = response[1].ToString();
            choice3.GetComponentInChildren<TMP_Text>().text = response[2].ToString();
            choice4.GetComponentInChildren<TMP_Text>().text = response[3].ToString();
            choice5.GetComponentInChildren<TMP_Text>().text = response[4].ToString();
            choice6.GetComponentInChildren<TMP_Text>().text = response[5].ToString();
            choice7.GetComponentInChildren<TMP_Text>().text = response[6].ToString();
        }
        else if (GameManager.Instance.GetPracticeLevel() == 2)
        {
            choice1.GetComponentInChildren<TMP_Text>().text = response[0].ToString();
            choice2.GetComponentInChildren<TMP_Text>().text = response[1].ToString();
            choice3.GetComponentInChildren<TMP_Text>().text = response[2].ToString();
            choice4.GetComponentInChildren<TMP_Text>().text = response[3].ToString();
            choice5.GetComponentInChildren<TMP_Text>().text = response[4].ToString();
            choice6.GetComponentInChildren<TMP_Text>().text = response[5].ToString();
            choice7.GetComponentInChildren<TMP_Text>().text = response[6].ToString();
        }
        else
        {
            choice1.GetComponentInChildren<TMP_Text>().text = response[0].ToString();
            choice2.GetComponentInChildren<TMP_Text>().text = response[1].ToString();
            choice3.GetComponentInChildren<TMP_Text>().text = response[2].ToString();
            choice4.GetComponentInChildren<TMP_Text>().text = response[3].ToString();
            choice5.GetComponentInChildren<TMP_Text>().text = response[4].ToString();
            choice6.GetComponentInChildren<TMP_Text>().text = response[5].ToString();
            choice7.GetComponentInChildren<TMP_Text>().text = response[6].ToString();
        }
    }

    void inRightSpot(GameObject choice)
    {
        if (GameManager.Instance.GetPracticeLevel() == 1)
        {
            float dis1 = Vector2.Distance(slots1[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis2 = Vector2.Distance(slots2[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis3 = Vector2.Distance(slots3[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis4 = Vector2.Distance(slots4[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis5 = Vector2.Distance(slots5[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis6 = Vector2.Distance(slots6[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

            if (dis1 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set1[2].ToString())
                {
                    if (slots1[2].GetComponent<SlotPractice>().canBeSolved == true && slots1[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots1[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots1[2].GetComponentInChildren<TMP_Text>().text = set1[2].ToString();
                        if(choice.GetComponent<DragButton>().correct == true)
                        {
                            slots1[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots1[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots2[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
                            slots2[0].GetComponentInChildren<TMP_Text>().color = Color.green;
                            slots2[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
                            slots2[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots1[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis2 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set2[2].ToString())
                {
                    if (slots2[2].GetComponent<SlotPractice>().canBeSolved == true && slots2[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots2[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots2[2].GetComponentInChildren<TMP_Text>().text = set2[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots2[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots2[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots3[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
                            slots3[0].GetComponentInChildren<TMP_Text>().color = Color.green;
                            slots3[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
                            slots3[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots2[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis3 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set3[2].ToString())
                {
                    if (slots3[2].GetComponent<SlotPractice>().canBeSolved == true && slots3[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots3[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots3[2].GetComponentInChildren<TMP_Text>().text = set3[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots3[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots3[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots4[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
                            slots4[0].GetComponentInChildren<TMP_Text>().color = Color.green;
                            slots4[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
                            slots4[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots3[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }

            }
            else if (dis4 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set4[2].ToString())
                {
                    if (slots4[2].GetComponent<SlotPractice>().canBeSolved == true && slots4[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots4[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots4[2].GetComponentInChildren<TMP_Text>().text = set4[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots4[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots4[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots5[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
                            slots5[0].GetComponentInChildren<TMP_Text>().color = Color.green;
                            slots5[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
                            slots5[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots4[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis5 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set5[2].ToString())
                {
                    if (slots5[2].GetComponent<SlotPractice>().canBeSolved == true && slots5[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots5[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots5[2].GetComponentInChildren<TMP_Text>().text = set5[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots5[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots5[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots6[2].GetComponentInChildren<SlotPractice>().canBeSolved = true;
                            slots6[0].GetComponentInChildren<TMP_Text>().color = Color.green;
                            slots6[1].GetComponentInChildren<TMP_Text>().color = Color.yellow;
                            slots6[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots5[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis6 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set6[2].ToString())
                {
                    if (slots6[2].GetComponent<SlotPractice>().canBeSolved == true && slots6[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots6[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots6[2].GetComponentInChildren<TMP_Text>().text = set6[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots6[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots6[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots6[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
            }
        }
        else if (GameManager.Instance.GetPracticeLevel() == 2)
        {
            float dis1 = Vector2.Distance(slots1[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis2 = Vector2.Distance(slots2[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis3 = Vector2.Distance(slots3[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis4 = Vector2.Distance(slots4[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis5 = Vector2.Distance(slots5[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis6 = Vector2.Distance(slots6[2].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

            if (dis1 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set1[2].ToString())
                {
                    if (slots1[2].GetComponent<SlotPractice>().canBeSolved == true && slots1[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots1[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots1[2].GetComponentInChildren<TMP_Text>().text = set1[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots1[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots1[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots1[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis2 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set2[2].ToString())
                {
                    if (slots2[2].GetComponent<SlotPractice>().canBeSolved == true && slots2[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots2[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots2[2].GetComponentInChildren<TMP_Text>().text = set2[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots2[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots2[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots2[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis3 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set3[2].ToString())
                {
                    if (slots3[2].GetComponent<SlotPractice>().canBeSolved == true && slots3[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots3[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots3[2].GetComponentInChildren<TMP_Text>().text = set3[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots3[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots3[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots3[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }

            }
            else if (dis4 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set4[2].ToString())
                {
                    if (slots4[2].GetComponent<SlotPractice>().canBeSolved == true && slots4[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots4[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots4[2].GetComponentInChildren<TMP_Text>().text = set4[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots4[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots4[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots4[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis5 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set5[2].ToString())
                {
                    if (slots5[2].GetComponent<SlotPractice>().canBeSolved == true && slots5[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots5[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots5[2].GetComponentInChildren<TMP_Text>().text = set5[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots5[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots5[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots5[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis6 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set6[2].ToString())
                {
                    if (slots6[2].GetComponent<SlotPractice>().canBeSolved == true && slots6[2].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots6[2].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots6[2].GetComponentInChildren<TMP_Text>().text = set6[2].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots6[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots6[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots6[2]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
            }
        }
        else
        {
            float dis1 = Vector2.Distance(slots1[randomizedSlots[0]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis2 = Vector2.Distance(slots2[randomizedSlots[1]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis3 = Vector2.Distance(slots3[randomizedSlots[2]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis4 = Vector2.Distance(slots4[randomizedSlots[3]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis5 = Vector2.Distance(slots5[randomizedSlots[4]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);
            float dis6 = Vector2.Distance(slots6[randomizedSlots[5]].GetComponent<Transform>().transform.position, choice.GetComponent<Transform>().transform.position);

            if (dis1 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set1[randomizedSlots[0]].ToString())
                {
                    if (slots1[randomizedSlots[0]].GetComponent<SlotPractice>().canBeSolved == true && slots1[randomizedSlots[0]].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots1[randomizedSlots[0]].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots1[randomizedSlots[0]].GetComponentInChildren<TMP_Text>().text = set1[randomizedSlots[0]].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots1[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots1[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots1[randomizedSlots[0]]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis2 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set2[randomizedSlots[1]].ToString())
                {
                    if (slots2[randomizedSlots[1]].GetComponent<SlotPractice>().canBeSolved == true && slots2[randomizedSlots[1]].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots2[randomizedSlots[1]].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots2[randomizedSlots[1]].GetComponentInChildren<TMP_Text>().text = set2[randomizedSlots[1]].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots2[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots2[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots2[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots2[randomizedSlots[1]]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis3 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set3[randomizedSlots[2]].ToString())
                {
                    if (slots3[randomizedSlots[1]].GetComponent<SlotPractice>().canBeSolved == true && slots3[randomizedSlots[1]].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots3[randomizedSlots[1]].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots3[randomizedSlots[1]].GetComponentInChildren<TMP_Text>().text = set3[randomizedSlots[1]].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots3[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots3[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots3[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots3[randomizedSlots[1]]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }

            }
            else if (dis4 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set4[randomizedSlots[3]].ToString())
                {
                    if (slots4[randomizedSlots[randomizedSlots[3]]].GetComponent<SlotPractice>().canBeSolved == true && slots4[randomizedSlots[3]].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots4[randomizedSlots[3]].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots4[randomizedSlots[3]].GetComponentInChildren<TMP_Text>().text = set4[randomizedSlots[3]].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots4[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots4[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots4[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots4[randomizedSlots[3]]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis5 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set5[randomizedSlots[4]].ToString())
                {
                    if (slots5[randomizedSlots[4]].GetComponent<SlotPractice>().canBeSolved == true && slots5[randomizedSlots[4]].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots5[randomizedSlots[4]].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots5[randomizedSlots[4]].GetComponentInChildren<TMP_Text>().text = set5[randomizedSlots[4]].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots5[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots5[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots5[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots5[randomizedSlots[4]]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else if (dis6 < 1)
            {
                if (choice.GetComponentInChildren<TMP_Text>().text == set6[randomizedSlots[5]].ToString())
                {
                    if (slots6[randomizedSlots[5]].GetComponent<SlotPractice>().canBeSolved == true && slots6[randomizedSlots[5]].GetComponent<SlotPractice>().solved == false)
                    {
                        choice.GetComponent<DragButton>().answerPosition = slots6[randomizedSlots[5]].GetComponent<Transform>().transform.position;
                        choice.GetComponent<DragButton>().isInCorrectSpot = true;
                        slots6[randomizedSlots[5]].GetComponentInChildren<TMP_Text>().text = set6[randomizedSlots[5]].ToString();
                        if (choice.GetComponent<DragButton>().correct == true)
                        {
                            slots6[2].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots6[1].GetComponentInChildren<TMP_Text>().color = Color.white;
                            slots6[0].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                    whenCorrect(choice, slots6[randomizedSlots[5]]);
                }
                else
                {
                    choice.GetComponent<DragButton>().isInCorrectSpot = false;
                    //bugsy.Play("NotCorrect");
                }
            }
            else
            {
                choice.GetComponent<DragButton>().isInCorrectSpot = false;
            }
        }
    }

    void whenCorrect(GameObject choice, GameObject slot)
    {
        if (choice.GetComponent<DragButton>().correct == true)
        {
            choice.SetActive(false);
            choice.GetComponent<DragButton>().correct = false;
            slot.GetComponent<SlotPractice>().solved = true;
            slot.GetComponent<SlotPractice>().canBeSolved = false;
            //bugsy.Play("Correct");
            passingAmount++;
        }
    }
}
