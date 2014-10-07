using UnityEngine;
using System.Collections;

public class GameFlowManager : MonoBehaviour {

    public static GameFlowManager Instance;

    private GameStates _currentState;

    private enum GameStates
    {
        GameInitialize,
        LevelSelect,
        InLevel,
        LevelExit
    }

	// Use this for initialization
	void Start () {
        Instance = this;
        _currentState = GameStates.GameInitialize;
	}
	
	// Update is called once per frame
	void Update () {

        switch (_currentState)
        {
            case GameStates.GameInitialize:
                // Go to intro scene with play button
                break;
        }
	}

    private void ChangeState(GameStates newState)
    {
        GameStates oldState = _currentState;
        _currentState = newState;
        OnStateChanged(oldState, newState); //if you want it to do something in between changes
    }

    private void OnStateChanged(GameStates oldState, GameStates newState)
    {
        switch (oldState)
        {
        
        }

        switch (newState)
        {

        }
    }
}
