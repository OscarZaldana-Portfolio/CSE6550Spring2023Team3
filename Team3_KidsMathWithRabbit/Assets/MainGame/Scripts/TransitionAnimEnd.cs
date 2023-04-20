using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionAnimEnd : MonoBehaviour
{
    public UnityEvent onEnd;
    public Animator GoodJobAnim;
    public int count;
    //public ParticleSystem particleSystem1; 
    //public ParticleSystem particleSystem2; 
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
        if (count % 3 == 0)
        {
            GoodJobAnim.Play("goodJobConfetti");
            //GetComponent<ParticleSystem>().GetComponent<ParticleSystem>().enableEmission = true;
        }
    }

    public void stopParticles()
    {
        //GetComponent<ParticleSystem>().GetComponent<ParticleSystem>().enableEmission = false;
    }


}
