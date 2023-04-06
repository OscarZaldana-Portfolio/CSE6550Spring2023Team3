using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StateSO : ScriptableObject
{
    [SerializeField]
    private GameManager.GameStates _gameState;

    public GameManager.GameStates States
    {
        get { return _gameState; }
        set { _gameState = value; }
    }
}
