using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

<<<<<<< Updated upstream
public class ChangeScene : MonoBehaviour
=======
public class ChangeofScene : MonoBehaviour
>>>>>>> Stashed changes
{
    // Start is called before the first frame update
    void CompareStart()
    {
        
    }

    // Update is called once per frame
    void CompareUpdate()
    {
        
    }

<<<<<<< Updated upstream
    public void nextScene(string Cname)
=======
    public void nextLoadScene(string Cname)
>>>>>>> Stashed changes
    {
        SceneManager.LoadScene(Cname);
    }
}
