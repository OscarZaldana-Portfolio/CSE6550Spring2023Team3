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

    private void Awake()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Vector2.zero,
            canvas.worldCamera,
            out position);
        transform.position = canvas.transform.TransformPoint(position);
    }

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
