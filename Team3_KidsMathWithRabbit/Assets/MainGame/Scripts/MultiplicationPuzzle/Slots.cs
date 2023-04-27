using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public string answer;
    [SerializeField]
    private Canvas canvas;
    public bool slotAccepting = true;
    Color colorC;

    private void Start()
    {
        slotAccepting = true;
        ColorUtility.TryParseHtmlString("#016937", out colorC);
    }
    void Update()
    {
        answer = GetComponentInChildren<TMP_Text>().text;
    }

    public void emptySlot()
    {
        this.gameObject.GetComponent<Image>().enabled= false;
        this.gameObject.GetComponentInChildren<TMP_Text>().color = Color.white;
    }

    public void fillSlot()
    {
        this.gameObject.GetComponent<Image>().enabled = true;
        this.gameObject.GetComponentInChildren<TMP_Text>().color = colorC;
        this.slotAccepting = true;
    }
}
