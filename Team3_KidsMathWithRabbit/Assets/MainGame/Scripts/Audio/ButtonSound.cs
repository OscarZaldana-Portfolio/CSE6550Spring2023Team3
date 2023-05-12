using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ButtonSound : MonoBehaviour
{
    public void onSoundForButton()
    {
        switch (GetComponentInChildren<TMP_Text>().text)
        {
            case "0":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "ZERO", 1.0f);
                break;
            case "1":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "ONE", 1.0f);
                break;
            case "2":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWO", 1.0f);
                break;
            case "3":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "THREE", 1.0f);
                break;
            case "4":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "FOUR", 1.0f);
                break;
            case "5":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "FIVE", 1.0f);
                break;
            case "6":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "SIX", 1.0f);
                break;
            case "7":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "SEVEN", 1.0f);
                break;
            case "8":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "EIGHT", 1.0f);
                break;
            case "9":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "NINE", 1.0f);
                break;
            case "10":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TEN", 1.0f);
                break;
            case "11":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "ELEVEN", 1.0f);
                break;
            case "12":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWELVE", 1.0f);
                break;
            case "13":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "THIRTEEN", 1.0f);
                break;
            case "14":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "FOURTEEN", 1.0f);
                break;
            case "15":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "FIFTEEN", 1.0f);
                break;
            case "16":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "SIXTEEN", 1.0f);
                break;
            case "17":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "SEVENTEEN", 1.0f);
                break;
            case "18":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "EIGHTEEN", 1.0f);
                break;
            case "19":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "NINETEEN", 1.0f);
                break;
            case "20":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTY", 1.0f);
                break;
            case "21":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTYONE", 1.0f);
                break;
            case "22":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTYTWO", 1.0f);
                break;
            case "23":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTYTHREE", 1.0f);
                break;
            case "24":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTYFOUR", 1.0f);
                break;
            case "25":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTYFIVE", 1.0f);
                break;
            case "26":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTYSIX", 1.0f);
                break;
            case "27":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTYSEVEN", 1.0f);
                break;
            case "28":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTYEIGHT", 1.0f);
                break;
            case "29":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "TWENTYNINE", 1.0f);
                break;
            case "30":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "THIRTY", 1.0f);
                break;
            case "X":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "Multiply", 1.0f);
                break;
            case "=":
                GameManager.Instance.AudioManager.PlayExactSounds("Numbers", "Equals", 1.0f);
                break;
        }
    }

    public void MainMenuButtonSelect()
    {
        GameManager.Instance.AudioManager.PlaySound("MainMenuButtonClick", 0.8f);
    }

    public void ExitButtonSelect()
    {
        GameManager.Instance.AudioManager.PlaySound("ExitButton", 0.8f);
    }

    public void buttonSpawnSound()
    {
        GameManager.Instance.AudioManager.PlaySound("ButtonPOP", 1.0f);
    }

    public void CarrotSound()
    {
        GameManager.Instance.AudioManager.PlaySound("CarrotSound", 0.4f);
    }

    public void YaySound()
    {
        GameManager.Instance.AudioManager.PlaySound("Yay", 1.0f);
    }

    public void SparkleSound()
    {
        GameManager.Instance.AudioManager.PlaySound("Sparkle", 1.0f);
    }
}



/*using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class AzureButton : MonoBehaviour
{
    public Button button;
    public InputField inputField;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {

        StartCoroutine(SendDataToAzure(inputField.text));

    }

    async Task SendDataToAzure(string data)
    {
        string url = "https://<Team3_KidMathsGameWithRabbit>.azurewebsites.net/api/<Team3_KidMathsGameWithRabbit>?data=" + data;

        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            Debug.Log(responseBody);
        }
    }
}
*/