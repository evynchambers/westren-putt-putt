using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    public enum GameStates
    {
        MAINMENU,
        GAME,
        SETTINGS
    }

    public GameStates gameStates;
    public GameObject[] states;

    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }

        
    }

	// Use this for initialization
	void Start () {
        gameStates = GameStates.MAINMENU;
        ChangeState();
	}

    public void StartGame()
    {
        gameStates = GameStates.GAME;
        ChangeState();
    }

    void ChangeState()
    {
        switch (gameStates)
        {
            case GameStates.MAINMENU:
                states[0].SetActive(true);
                states[1].SetActive(false);
                states[2].SetActive(false);
                break;

            case GameStates.GAME:
                states[0].SetActive(false);
                states[1].SetActive(true);
                states[2].SetActive(false);
                break;

            case GameStates.SETTINGS:
                states[0].SetActive(false);
                states[1].SetActive(false);
                states[2].SetActive(true);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
