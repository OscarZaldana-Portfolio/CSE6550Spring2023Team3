using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSizeExpand : MonoBehaviour
{
    public RectTransform buttonTransform;
    private Vector3 originalScale;
   
    void Start()
    {
        //buttonObject = gameObject;
        RectTransform rect = GetComponent<RectTransform>();
        //originalSize = new Vector2(rect.width, rect.height);
         originalScale = transform.localScale;
        buttonTransform = GetComponent<RectTransform>();
        GetComponent<Button>().onClick.AddListener(ExpandButton);
        originalScale = transform.localScale;

        void ExpandButton()
        {
            
            buttonTransform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
            Invoke("MinimizeButton", 0.1f);
           // originalScale = transform.localScale;
                    //MinimizeButton();
            
        }
        void MinimizeButton()
        {
             buttonTransform.localScale = originalScale;
            //buttonTransform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
