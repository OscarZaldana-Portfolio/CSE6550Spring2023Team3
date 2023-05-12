using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionAnimEnd : MonoBehaviour
{
    public UnityEvent onEnd;
    public GameObject goodJob;
    public int count;
    public int endNum;
    public void callBoard()
    {
        onEnd.Invoke();
    }

    public void Counter()
    {
        count++;
    }

    public void playGoodJob()
    {
        if (count % endNum == 0)
        {
            goodJob.GetComponent<Animator>().Play("GoodJob");
            goodJob.GetComponentsInChildren<ParticleSystem>()[0].Play();
            goodJob.GetComponentsInChildren<ParticleSystem>()[1].Play();
            count = 0;
        }
    }

    public void stopParticles()
    {
        goodJob.GetComponentsInChildren<ParticleSystem>()[0].Stop();
        goodJob.GetComponentsInChildren<ParticleSystem>()[1].Stop();
    }


}
