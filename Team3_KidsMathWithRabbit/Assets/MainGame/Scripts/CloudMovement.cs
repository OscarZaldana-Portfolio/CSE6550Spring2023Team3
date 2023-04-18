using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [SerializeField]
    private float cloudSpeed;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.getState() == GameManager.GameStates.MainMenu)
        {
            moveCloud();
        }

        if (transform.position.x <= GameManager.Instance.UIManager.leftBarrier.position.x)
        {
            transform.position = new Vector3(GameManager.Instance.UIManager.rightBarrier.position.x, transform.position.y, transform.position.z);
        }
    }

    void moveCloud()
    {
        transform.Translate(Vector3.left * cloudSpeed * Time.deltaTime);
    }

}
