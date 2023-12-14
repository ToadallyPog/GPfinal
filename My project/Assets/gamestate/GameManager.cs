using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    public int lives;
    public int healthPoints;

    private void Awake()
    {
        lives = 3;
        healthPoints = 5;
        Instance = this;
    }


    public void UpdateGamestate(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.exploring:
                break;

            case GameState.lose:
                HandlePlayerDeath();
            break;

            default:
             State = newState;throw new System.ArgumentOutOfRangeException(nameof(newState), newState, null);


        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandlePlayerDeath()
    {

    }





    // Start is called before the first frame update
    void Start()
    {
        UpdateGamestate(GameState.exploring);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

public enum GameState
{
    exploring,
    lose
}