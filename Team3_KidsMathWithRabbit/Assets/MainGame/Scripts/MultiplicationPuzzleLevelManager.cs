using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class MultiplicationPuzzleLevelManager : MonoBehaviour
{
    public UnityEvent onSolved;
    public GameObject nextButton;
    public GameObject UIButton;
    public GameObject UICanvas;
    public List<TMP_Text> solutions_Text = new List<TMP_Text>();
    List<TMP_Text> solutions_Holder = new List<TMP_Text>();
    public List<TMP_Text> keys_Text  = new List<TMP_Text>();
    List<TMP_Text> keys_Holder = new List<TMP_Text>();

    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        CreateText();
        //UICanvas.GetComponent<Animator>().Play("QuestionsTransition");
    }

    // Update is called once per frame
    void Update()
    {
        //if (CheckSolution())
        //{
        //    Debug.Log("test");
        //    keys_Holder.Clear();
        //    //onSolved.Invoke();
        //}
    }

    void CreateText()
    {
        solutions_Text[0].text = Random.Range(1, 6).ToString();
        solutions_Text[2].text = Random.Range(1, 6).ToString();
        solutions_Text[4].text = (int.Parse(solutions_Text[0].text) * int.Parse(solutions_Text[2].text)).ToString();
        
        CopyList(solutions_Holder, solutions_Text);

        foreach (TMP_Text texts in keys_Text)
        {
            int rand = Random.Range(0, solutions_Holder.Count);
            texts.text = solutions_Holder[rand].text;
            solutions_Holder.RemoveAt(rand);
        }
    }

    bool CheckSolution()
    {
        for (int i = 0; i < 0; i++)
        {
            if (keys_Holder[i].text != solutions_Text[i].text)
            {
                return false;
            }
        }
            return false;
    }

    void CopyList(List<TMP_Text> a, List<TMP_Text> b)
    {
        a.Clear();
        a.AddRange(b);

        for(int i = 0; i < b.Count; i++)
        {
            a[i].text = b[i].text;
        }
    }

    public void Reset()
    {
        CreateText();
        onSolved.Invoke();
        ButtonsOff();
        NextButtonOff();
        //UICanvas.GetComponent<Animator>().Play("QuestionsTransition");
    }

    public void NextButtonOn()
    {
        nextButton.SetActive(true);
    }

    public void NextButtonOff()
    {
        nextButton.SetActive(false);
    }

    public void ButtonsOff()
    {
        UIButton.SetActive(false);
    }

    public void ButtonsOn()
    {
        UIButton.SetActive(true);
    }


}
