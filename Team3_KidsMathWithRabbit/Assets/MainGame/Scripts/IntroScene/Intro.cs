using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Intro : MonoBehaviour
{

    public Animator anim;
    public Slider slider;
    AnimationClip clip;
    public TMP_Text percentText;
    float timeOf;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.changeState("MainMenu");
        GameManager.Instance.AudioManager.PlaySound("IntroScene", 0.5f);

        clip = anim.runtimeAnimatorController.animationClips[0];
        timeOf = clip.length;
    }

    private void Update()
    {
        float currentTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime * timeOf;
        slider.value = currentTime/10;
        percentText.text = ((int)(slider.value * 100)+1).ToString();
    }
}

