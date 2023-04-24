using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundList library;
    public AudioSource soundFXSource;
    public AudioSource musicSource;


    public void PlaySound(string soundName, float volume)    {
        soundFXSource.PlayOneShot(library.GetClipFromName(soundName), volume);
    }

    public void PlayMusic(string soundName, float volume)
    {
        musicSource.clip = library.GetClipFromName(soundName);
        musicSource.loop = true;
        musicSource.volume = volume;
        musicSource.Play();
    }

    public void Start()
    {
        if(GameManager.Instance.getCurrentState() == GameManager.GameStates.MainMenu)
        {
            PlayMusic("MainMenuMusic", 0.2f);
        }
        else if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationPuzzle)
        {
            PlayMusic("MainMenuMusic", 0.2f);
        }
        else if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationFun)
        {
            PlayMusic("MainMenuMusic", 0.2f);
        }
        else if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationQuiz)
        {
            PlayMusic("MainMenuMusic", 0.2f);
        }
        else if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MultiplicationPractice)
        {
            PlayMusic("MainMenuMusic", 0.2f);
        }
    }


    public IEnumerator Transition()
    {
        yield return new WaitForSeconds(12.0f);
        GameManager.Instance.AudioManager.musicSource.Play();
    }

}
