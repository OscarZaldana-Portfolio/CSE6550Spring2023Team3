using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExitButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Animator carrot;
    [SerializeField]
    private Canvas canvas;
    Vector3 homePosition;
    public Transform endPosition;
    bool atHome = false;
    bool exitScene = false;
    public UnityEvent onExit;
    public GameObject exitSlotImg;

    private void Start()
    {
        homePosition = transform.position;
        exitSlotImg.SetActive(false);
    }

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        if(atHome == false)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                pointerData.position,
                canvas.worldCamera,
                out position);
            transform.position = new Vector2(canvas.transform.TransformPoint(position).x, homePosition.y);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameManager.Instance.AudioManager.PlaySound("ExitButton", 0.8f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(atHome != true)
        {
            transform.position = homePosition;
        }
    }

    private void Update()
    {
        if((transform.position.x == endPosition.position.x || transform.position.x < endPosition.position.x) && exitScene == false) {
            atHome = true;
            exitScene = true;
            GameManager.Instance.changeState("MainMenu");
            carrot.Play("carrot");
            onExit.Invoke();
        }
    }
}
