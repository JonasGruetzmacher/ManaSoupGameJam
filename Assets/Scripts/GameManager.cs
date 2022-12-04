using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Tutorial tutorial;
    [SerializeField] Transform enemies;
    [SerializeField] Transform pickUps;

    [SerializeField] GameObject uiMenu;
    [SerializeField] GameObject uiInGame;
    [SerializeField] GameObject uiGameOver;


    public static GameManager Instance;

    public GameObject player;

    public State _state;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(State.MENU);
    }

    public void StartGame()
    {
        player.GetComponent<Player>().ResetPlayer();
        ScoreManager.Instance.ResetScore();
        SwitchState(State.INGAME);
        StartCoroutine(tutorial.ShowTutorial());

    }


    public void GameOver() 
    {
        foreach (Transform enemy in enemies)
        {
            Destroy(enemy);
        }
        foreach (Transform pickUp in pickUps)
        {
            Destroy(pickUp);
        }
        SwitchState(State.GAMEOVER);
    }

    public void Menu()
    {
        SwitchState(State.MENU);
    }

    void SwitchState(State state)
    {
        switch (state)
        {
            case State.MENU:
                _state = State.MENU;
                uiInGame.SetActive(false);
                uiMenu.SetActive(true);
                uiGameOver.SetActive(false);
                Time.timeScale = 0;
                break;
            case State.INGAME:
                _state = State.INGAME;
                uiInGame.SetActive(true);
                uiMenu.SetActive(false);
                uiGameOver.SetActive(false);
                Time.timeScale = 1;
                break;
            case State.GAMEOVER:
                _state = State.GAMEOVER;
                uiInGame.SetActive(true);
                uiMenu.SetActive(false);
                uiGameOver.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
}

public enum State
{
    MENU,
    INGAME,
    GAMEOVER
}
