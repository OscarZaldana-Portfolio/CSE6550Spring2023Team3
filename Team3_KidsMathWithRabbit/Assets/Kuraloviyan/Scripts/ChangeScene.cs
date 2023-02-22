using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeofScene : MonoBehaviour
{
    // Start is called before the first frame update
    void CompareStart()
    {
        
    }

    // Update is called once per frame
    void CompareUpdate()
    {
        
    }

    public void nextloadScene(string Cname)
    {
        SceneManager.LoadScene(Cname);
    }
}
