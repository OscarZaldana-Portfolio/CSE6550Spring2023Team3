using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class DragButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string choiceText;
    [SerializeField]
    private Canvas canvas;
    public bool isInCorrectSpot = false;
    public bool beingGrabbed = false;
    public bool correct = false;
    public bool atWrongNumber = false;
    public bool clickable = true;
    public int slotNumber;
    public int slotSetNumber = 0;
    Animator anim;
    public Vector3 answerPosition;
    public Vector3 homePosition;    

    //Handles the drag movement by matching it to the screen rather then the canvas
    public void DragHandler(BaseEventData data)
    {
        if(clickable)
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
    }

    public void OnClicked()
    {
        if (clickable)
        {
            beingGrabbed = true;
            anim.enabled = false;
            if (gameObject.GetComponentsInChildren<ParticleSystem>() != null)
            {
                gameObject.GetComponentsInChildren<ParticleSystem>()[0].Play();
                gameObject.GetComponentsInChildren<ParticleSystem>()[1].Play();
            }
        }
    }

    public void OnUnClicked()
    {
        if (clickable)
        {
            beingGrabbed = false;
            anim.enabled = true;
            float dis = Vector2.Distance(homePosition, answerPosition);
            if (gameObject.GetComponentsInChildren<ParticleSystem>() != null)
            {
                gameObject.GetComponentsInChildren<ParticleSystem>()[0].Stop();
                gameObject.GetComponentsInChildren<ParticleSystem>()[1].Stop();
            }

            if (isInCorrectSpot)
            {
                CorrectSpot();
            }
            else
            {
                if (atWrongNumber)
                {
                    GameManager.Instance.AudioManager.PlaySound("WrongAnswer", 0.6f);
                    GameManager.Instance.UIManager.OnPlayAnimation("NotCorrect");
                }
                else
                {
                    GameManager.Instance.AudioManager.PlaySound("ButtonHeadsBack", 1.0f);
                }
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void CorrectSpot()
    {
        GameManager.Instance.UIManager.OnPlayAnimation("Correct");
        slotSetNumber = slotNumber;
        transform.position = answerPosition;
        correct = true;
        this.gameObject.GetComponent<Image>().enabled = false;
        choiceText = "";
        clickable = false;
        anim.enabled = false;
    }

    public void ResetChoices()
    {
        transform.position = homePosition;
        correct = false;
        this.gameObject.GetComponent<Image>().enabled = true;
        anim.enabled = true;
        clickable = true;
    }

    public void PlayAnim(string source)
    {
        anim.Play(source);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Save the homePosition
        homePosition = transform.position;
        if (GetComponent<Animator>() != null)
        {
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponentInChildren<TMP_Text>() != null)
        {
            gameObject.GetComponentInChildren<TMP_Text>().text = choiceText;
        }
        if (beingGrabbed == false && correct == false) 
        {
            transform.position = Vector3.Lerp(transform.position, homePosition, 5 * Time.deltaTime);
        }
    }
}
