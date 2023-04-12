using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickHandler : MonoBehaviour
{
    public Animator animator;
    public string sceneName;

    public void PlayAnimationAndLoadScene()
    {
        animator.SetTrigger("PlayAnimation");
        SceneManager.LoadScene(sceneName);
    }
}
