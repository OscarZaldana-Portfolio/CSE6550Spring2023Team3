using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    public Animation anim;

    void Start()
    {
        // Play the animation
        anim.Play("carrot");
    }

    void Update()
    {
        // Check if the animation is finished
        if (anim.isPlaying == false)
        {
            // Pause the animation for 2 seconds
            anim.Stop();
            StartCoroutine(WaitAndResume(2.0f));
        }
    }

    IEnumerator WaitAndResume(float delayTime)
    {
        // Wait for the delay time
        yield return new WaitForSeconds(delayTime);

        // Resume the animation
        anim.Play("carrot");

        // Return to the idle position
        anim.CrossFade("Idle", 1.0f);
    }
}
