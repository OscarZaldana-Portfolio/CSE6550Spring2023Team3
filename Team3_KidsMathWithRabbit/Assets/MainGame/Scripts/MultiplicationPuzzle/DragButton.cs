using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string choice;
    [SerializeField]
    private Canvas canvas;
    Transform ParentAfterDrag;

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);
        transform.position = canvas.transform.TransformPoint(position);
    }





    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameObject.GetComponentInChildren<ParticleSystem>() != null)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
        //ParentAfterDrag = transform.parent;
        //transform.SetParent(transform.root);
        //transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject.GetComponentInChildren<ParticleSystem>() != null)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponentInChildren<TMP_Text>() != null)
        {
            choice = gameObject.GetComponentInChildren<TMP_Text>().text;
        }
    }
}
