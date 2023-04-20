using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void transitionPlay()
    {
        GameManager.Instance.AudioManager.musicSource.Pause();
        GameManager.Instance.AudioManager.PlaySound("ProblemSolved", 0.4f);
        StartCoroutine(Transition());
    }


    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(10.0f);
        GameManager.Instance.AudioManager.musicSource.UnPause();
    }
}
