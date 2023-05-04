using UnityEngine;

public class ButtonClickAnimation : MonoBehaviour
{
    public Animation animationComponent;
    public string animationClipName;

    public void OnClick()
    {
        animationComponent.Play(animationClipName);
    }
}
