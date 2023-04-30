using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Z_CreateImages : MonoBehaviour
{
    public List<Sprite> images = new List<Sprite>();
    public TMP_Text operandText;
    int operand;

    // Start is called before the first frame update
    void Start()
    {
        operand = int.Parse(operandText.text);
        //var image = Instantiate(images[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        //image.transform.parent = gameObject.transform;
    }
}
