using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StateSO : ScriptableObject
{
    [SerializeField]
    private GameManager.GameStates _gameState;
    [SerializeField]
    private GameManager.GameStates _nextGameState;
    [SerializeField]
    private GameManager.GameStates _prevGameState;


    public GameManager.GameStates CurrentState{
        get { return _gameState; }
        set { _gameState = value; }
    }

    public GameManager.GameStates NextState{
        get { return _nextGameState; }
        set { _nextGameState = value; }
    }

    public GameManager.GameStates PrevState{
        get { return _prevGameState; }
        set { _prevGameState = value; }
    }
}
