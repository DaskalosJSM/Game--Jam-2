using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
    principalMenu,
    History,
    Tutorial,
    Level1,
    Level2,
    Level3,
    FianlBoss,
    gameOver,
    Credits,
    Controls,
    YouWin
}

public class GameManager : MonoBehaviour
{
    // Inicializo el singleton en el primer script 
    public static GameManager sharedInstance;

    // Declaración del estado del juego
    public GameState currentGameState = GameState.principalMenu;

    public void Awake()
    {
        // que despierte y enfatizo con el siguiente fragmento
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Función encargado de iniciar la scena menú principal
    public void PrincipalMenu()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.principalMenu);
    }
    // Función encargado de iniciar la scena historia
    public void History()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.History);
    }
    // Función encargado de iniciar la scena level1
    public void Tutorial()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.Tutorial);
    }
    // Función encargado de iniciar la scena level2
    public void Level1()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.Level1);
    }
    // Función encargado de iniciar la scena level3
    public void Level2()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.Level2);
    }
    // Función encargado de iniciar la scena level4
    public void Level3()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.Level3);
    }
    // Función encargado de iniciar la scena level5
    public void FinalBoss()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.FianlBoss);
    }
    public void Credits()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.Credits);
    }
    public void Controls()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.Controls);
    }
    // Función encargado de iniciar la scena de final de juego
    public void GameOver()
    {
        Time.timeScale = 0f;
        SetGameState(GameState.gameOver);
    }
    public void YouWin()
    {
        Time.timeScale = 0f;
        SetGameState(GameState.YouWin);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetGameState(GameState newGameState)
    {
        this.currentGameState = newGameState;

        if (newGameState == GameState.principalMenu)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("MainMenu");
        }
        else if (newGameState == GameState.History)
        {
            //TODO: colocar la logica del historia
            SceneManager.LoadScene("History");
        }
        else if (newGameState == GameState.Level1)
        {
            //TODO: colocar la logica del level 1
            SceneManager.LoadScene("GameLevel1");
        }
        else if (newGameState == GameState.Level2)
        {
            //TODO: colocar la logica del level 2
            SceneManager.LoadScene("GameLevel2");
        }
        else if (newGameState == GameState.Level3)
        {
            //TODO: colocar la logica del level 3
            SceneManager.LoadScene("GameLevel3");
        }
        else if (newGameState == GameState.FianlBoss)
        {
            //TODO: colocar la logica del level 4
            SceneManager.LoadScene("FinalBoss");
        }
        else if (newGameState == GameState.Tutorial)
        {
            //TODO: colocar la logica del level 5
            SceneManager.LoadScene("Tutorial");
        }
        else if (newGameState == GameState.Credits)
        {
            //TODO: colocar la logica del level 5
            SceneManager.LoadScene("Credits");
        }
        else if (newGameState == GameState.Controls)
        {
            //TODO: colocar la logica del level 5
            SceneManager.LoadScene("Controls");
        }
        else if (newGameState == GameState.gameOver)
        {
            //TODO: colocar la logica del gameOver
            SceneManager.LoadScene("GameOver");
        }
        else if (newGameState == GameState.YouWin)
        {
            //TODO: colocar la logica del gameOver
            SceneManager.LoadScene("YouWin");
        }
    }
}