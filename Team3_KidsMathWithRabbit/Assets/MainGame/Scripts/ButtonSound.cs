using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSound : MonoBehaviour
{
    public void onSoundForButton()
    {
        switch (GetComponentInChildren<TMP_Text>().text.ToString())
        {
            case "1":
                GameManager.Instance.AudioManager.PlaySound("One", 1.0f);
                break;
            case "2":
                GameManager.Instance.AudioManager.PlaySound("Two", 1.0f);
                break;
            case "3":
                GameManager.Instance.AudioManager.PlaySound("Three", 1.0f);
                break;
            case "4":
                GameManager.Instance.AudioManager.PlaySound("Four", 1.0f);
                break;
            case "5":
                GameManager.Instance.AudioManager.PlaySound("Five", 1.0f);
                break;
            case "6":
                GameManager.Instance.AudioManager.PlaySound("Six", 1.0f);
                break;
            case "7":
                GameManager.Instance.AudioManager.PlaySound("Seven", 1.0f);
                break;
            case "8":
                GameManager.Instance.AudioManager.PlaySound("Eight", 1.0f);
                break;
            case "9":
                GameManager.Instance.AudioManager.PlaySound("Nine", 1.0f);
                break;
            case "10":
                GameManager.Instance.AudioManager.PlaySound("Ten", 1.0f);
                break;
            case "11":
                GameManager.Instance.AudioManager.PlaySound("Eleven", 1.0f);
                break;
            case "12":
                GameManager.Instance.AudioManager.PlaySound("Twelve", 1.0f);
                break;
            case "13":
                GameManager.Instance.AudioManager.PlaySound("Thirteen", 1.0f);
                break;
            case "14":
                GameManager.Instance.AudioManager.PlaySound("Fourteen", 1.0f);
                break;
            case "15":
                GameManager.Instance.AudioManager.PlaySound("Fifteen", 1.0f);
                break;
            case "16":
                GameManager.Instance.AudioManager.PlaySound("Sixteen", 1.0f);
                break;
            case "17":
                GameManager.Instance.AudioManager.PlaySound("Seventeen", 1.0f);
                break;
            case "18":
                GameManager.Instance.AudioManager.PlaySound("Eighteen", 1.0f);
                break;
            case "19":
                GameManager.Instance.AudioManager.PlaySound("Nineteen", 1.0f);
                break;
            case "20":
                GameManager.Instance.AudioManager.PlaySound("Twenty", 1.0f);
                break;
            case "21":
                GameManager.Instance.AudioManager.PlaySound("TwentyOne", 1.0f);
                break;
            case "22":
                GameManager.Instance.AudioManager.PlaySound("TwentyTwo", 1.0f);
                break;
            case "23":
                GameManager.Instance.AudioManager.PlaySound("TwentyThree", 1.0f);
                break;
            case "24":
                GameManager.Instance.AudioManager.PlaySound("TwentyFour", 1.0f);
                break;
            case "25":
                GameManager.Instance.AudioManager.PlaySound("TwentyFive", 1.0f);
                break;
            case "26":
                GameManager.Instance.AudioManager.PlaySound("TwentySix", 1.0f);
                break;
            case "27":
                GameManager.Instance.AudioManager.PlaySound("TwentySeven", 1.0f);
                break;
            case "28":
                GameManager.Instance.AudioManager.PlaySound("TwentyEight", 1.0f);
                break;
            case "29":
                GameManager.Instance.AudioManager.PlaySound("TwentyNine", 1.0f);
                break;
            case "30":
                GameManager.Instance.AudioManager.PlaySound("Thirty", 1.0f);
                break;
            case "X":
                GameManager.Instance.AudioManager.PlaySound("Multiply", 1.0f);
                break;
            case "=":
                GameManager.Instance.AudioManager.PlaySound("EqualTo", 1.0f);
                break;
        }
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