using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StateSO : ScriptableObject
{
    [SerializeField]
    private GameManager.GameStates _gameState;
    private GameManager.GameStates _nextGameState;


    public GameManager.GameStates CurrentState
    {
        get { return _gameState; }
        set { _gameState = value; }
    }

    public GameManager.GameStates NextState
    {
        get { return _gameState; }
        set { _gameState = value; }
    }
}
