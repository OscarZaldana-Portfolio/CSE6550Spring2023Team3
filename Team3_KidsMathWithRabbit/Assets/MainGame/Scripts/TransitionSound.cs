using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionSound : MonoBehaviour
{
    public void transitionPlay()
    {
        GameManager.Instance.AudioManager.musicSource.Pause();
        GameManager.Instance.AudioManager.PlaySound("ProblemSolved", 0.6f);
        StartCoroutine(Transition());
    }


    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(6.0f);
        GameManager.Instance.AudioManager.musicSource.UnPause();
    }
}
