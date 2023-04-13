using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundList library;
    public AudioSource soundFXSource;
    public AudioSource musicSource;


    public void PlaySound2D(string soundName)
    {
        //sfx2DSource.pitch = Random.Range(lowPitch, 1);
        soundFXSource.PlayOneShot(library.GetClipFromName(soundName), 0.5f);
    }
}
