using UnityEngine;
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
<<<<<<< HEAD
        StartCoroutine(SendDataToAzure(inputField.text));
=======
        //StartCoroutine(SendDataToAzure(inputField.text));
>>>>>>> main
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
