using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button[] buttons;
    Color colorB;
    public Animator carrot;
    public Animator reverseCarrot;
    public GameObject[] canvas;
    public ParticleSystem[] buttonEffects;
    int tracker = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.getPreviousState() == GameManager.GameStates.Intro && GameManager.Instance.getCurrentState() == GameManager.GameStates.MainMenu)
        {
            GameManager.Instance.AudioManager.musicSource.Pause();
            GameManager.Instance.AudioManager.PlaySound("IntrotoMain", 0.8f);
        }

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }

        ColorUtility.TryParseHtmlString("#C8C8C8", out colorB);

        if (GameManager.Instance.getCurrentState() == GameManager.GameStates.MainMenu)
        {
            if(GameManager.Instance.getPreviousState() != GameManager.GameStates.Intro && GameManager.Instance.getPreviousState() != GameManager.GameStates.MainMenu)
            {
                reverseCarrot.Play("reverseCarrots");
            }
        }

        foreach (GameObject obj in canvas) {
            obj.SetActive(false);
        }
    }

    private void Update()
    {
        if (!GameManager.Instance.AudioManager.soundFXSource.isPlaying && GameManager.Instance.getPreviousState() == GameManager.GameStates.Intro)
        {
            GameManager.Instance.AudioManager.musicSource.UnPause();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (tracker > 0)
            {
                tracker--;
            }
            foreach(ParticleSystem particle in buttonEffects)
            {
                particle.Stop(false);
            }
            buttonEffects[tracker].Play();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (tracker < buttonEffects.Length-1)
            {
                tracker++;
            }
            foreach (ParticleSystem particle in buttonEffects)
            {
                particle.Stop(false);
            }
            buttonEffects[tracker].Play();
        }
    }

    private void OnButtonClick(Button clickedButton)
    {
        foreach (Button button in buttons)
        {
            if (button != clickedButton)
            {
                button.interactable = false;
            }
            else
            {
                ColorBlock cb = button.colors;
                cb.disabledColor = colorB;
                button.colors = cb;
                button.interactable = false;
            }
        }
    }

    public void CarrotTransition()
    {
        carrot.Play("carrot");
    }
}
