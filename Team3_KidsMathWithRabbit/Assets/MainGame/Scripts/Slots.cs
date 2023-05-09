using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public int answerNumber;
    public string answerText;

    public bool slotAccepting = true;
    Color colorC;
    ParticleSystem particle;

    private void Start()
    {
        if (GetComponentInChildren<ParticleSystem>() != null)
        {
            particle = GetComponentInChildren<ParticleSystem>();
        }
    }

    public void ChooseNumber() { 
        if(GameManager.Instance.GetLevel() == 1)
        {
            answerNumber = Random.Range(0, 6);
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            answerNumber = Random.Range(0, 11);
        }
        else
        {
            answerNumber = Random.Range(0, 21);
        }
    }

    public void SetText()
    {
        answerText = answerNumber.ToString();
    }

    public void SetTextColor(string colorHexCode)
    {
        ColorUtility.TryParseHtmlString(colorHexCode, out colorC);
    }

    public void CorrectSlot()
    {
        slotAccepting = false;
        if(this.gameObject.GetComponent<Image>() != null)
        {
            this.gameObject.GetComponent<Image>().enabled = false;
        }
        colorC = Color.white;
        GameManager.Instance.AudioManager.PlaySound("CorrectAnswer",1.0f);
        if (particle != null)
        {
            particle.Play();
        }
    }

    void Update()
    {
        GetComponentInChildren<TMP_Text>().text = answerText;
        GetComponentInChildren<TMP_Text>().color = colorC;
    }
}
