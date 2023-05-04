using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SlotPractice : MonoBehaviour
{
    public bool solved = false;
    public bool canBeSolved = false;


    public void emptySlot()
    {

    }

    private void Update()
    {
        if(solved)
        {
            this.gameObject.GetComponent<Image>().enabled = false;
            this.gameObject.GetComponentInChildren<TMP_Text>().color = Color.white;
        }
    }
}
