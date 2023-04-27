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

    // Update is called once per frame
    void Update()
    {
        answer = GetComponentInChildren<TMP_Text>().text;
    }

    public void emptySlot()
    {
        this.gameObject.GetComponent<Image>().enabled= false;
        this.gameObject.GetComponentInChildren<TMP_Text>().color = Color.white;
    }
}
