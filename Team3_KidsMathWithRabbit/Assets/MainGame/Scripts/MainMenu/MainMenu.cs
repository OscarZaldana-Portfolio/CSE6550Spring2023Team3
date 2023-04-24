using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button[] buttons;
    Color colorB;
    public Animator carrot;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.getPreviousState() == GameManager.GameStates.Intro && GameManager.Instance.getCurrentState() == GameManager.GameStates.MainMenu)
        {
            GameManager.Instance.AudioManager.musicSource.Pause();
            GameManager.Instance.AudioManager.PlaySound("IntrotoMain", 0.5f);
            if (!GameManager.Instance.AudioManager.soundFXSource.isPlaying)
            {
                GameManager.Instance.AudioManager.musicSource.UnPause();
            }
        }

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }

        ColorUtility.TryParseHtmlString("#C8C8C8", out colorB);

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

    public void MainMenuButtonSound()
    {
        GameManager.Instance.AudioManager.PlaySound("", 0.5f);
    }

    public void CarrotTransition()
    {
        carrot.Play("carrot");
        GameManager.Instance.AudioManager.PlaySound("Transition", 0.6f);
    }
}
