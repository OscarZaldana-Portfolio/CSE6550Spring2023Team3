using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInfo : ScriptableObject
{
    [SerializeField]
    private int _level;
    private int _max;
    private int _practiceLevel;

    public int PlayerLevel
    {
        get { return _level; }
        set { _level = value; }
    }

    public int MaxLevel
    {
        get { return _max; }
        set { _max = value; }
    }

    public int PracticeLevel
    {
        get { return _practiceLevel; }
        set { _practiceLevel = value; }
    }
}
