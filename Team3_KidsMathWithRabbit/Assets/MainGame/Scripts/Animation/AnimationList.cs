using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationList : MonoBehaviour
{
    public ClipGroup[] clipGroups = new ClipGroup[0];

    Dictionary<string, AnimationClip[]> groupDictionary = new Dictionary<string, AnimationClip[]>();

    void Awake()
    {

        //DontDestroyOnLoad(transform.gameObject);
        foreach (ClipGroup clipGroup in clipGroups)
        {
            groupDictionary.Add(clipGroup.clipGroupID, clipGroup.group);
        }

    }

    public AnimationClip GetClipFromName(string clipName)
    {
        if (groupDictionary.ContainsKey(clipName))
        {
            AnimationClip[] clips = groupDictionary[clipName];
            //return sounds[0];
            return clips[Random.Range(0, clips.Length)];
        }
        return null;
    }

    [System.Serializable]
    public class ClipGroup
    {
        public string clipGroupID;
        public AnimationClip[] group;
        [Range(0.0f, 1.0f)]
        static float sliderFloat;

    }
}
