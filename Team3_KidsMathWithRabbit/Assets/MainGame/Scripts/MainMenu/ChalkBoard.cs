using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkBoard : MonoBehaviour
{
    public Animator chalkBoard;
    public void RandomChalkBoardAnim()
    {
        int num = Random.Range(0, 4);
        switch (num)
        {
            case 0:
                chalkBoard.Play("ChalkBoard1imes2");
                break;
            case 1:
                chalkBoard.Play("ChalkBoard2imes3");
                break;
            case 2:
                chalkBoard.Play("ChalkBoard1times4");
                break;
            case 3:
                chalkBoard.Play("ChalkBoard4Times3");
                break;
        }
    }
}
