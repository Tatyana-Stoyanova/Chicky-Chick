using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject egg_prefab;
    public GameObject coin_prefab;
    public GameObject chicken_prefab;

    public Text highScore;
    public Text scoreText;
    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelGameOver;

    GameObject chicken;
    GameObject egg;
    private float nextActionTime = 0.0f;
    public float period = 0.2f;
    GameObject _coin;
    private float nextActTime = 0.0f;
    float timePeriod = 4f;
    float _currentTime = 0f;

    public static GameManager Instance { get; private set; }
    
    private int _score;

    public int Score
    {
        get { return _score; }
        set { _score = value;
            scoreText.text = "SCORE: " + _score;
        }
    }

    public enum state { MENU, INIT, PLAY, GAMEOVER }
    state _state;   //current state


    public void PlayClicked()
    {
        SwitchState(state.INIT);
    }

    public void QuitClicked()
    {
        Application.Quit();
    }

    void Start()
    {
        Instance = this;
        SwitchState(state.MENU);
    }


    public void SwitchState(state newState)
    {
        EndState();
        _state = newState;
        BeginState(newState);
    }


    void BeginState(state newState)
    {
        switch (newState)
        {
            case state.MENU:
                panelMenu.SetActive(true);
                break;
            case state.INIT:
                panelPlay.SetActive(true);
                chicken = Instantiate(chicken_prefab);
                Score = 0;
                SwitchState(state.PLAY);
                break;
            case state.PLAY:
                _currentTime = Time.time;
                break;
            case state.GAMEOVER:
                _currentTime = 0f;
                nextActionTime = 0f;
                nextActTime = 0f;
                if (Score> PlayerPrefs.GetInt("highscore"))
                {
                    PlayerPrefs.SetInt("highscore", Score);
                }
                if (egg != null)
                {
                    Destroy(egg);
                }
                if (_coin != null)
                {
                    Destroy(_coin);
                }
                highScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
                panelGameOver.SetActive(true);
                
                break;
        }
    }

    void Update()
    {
        switch (_state)
        {
            case state.MENU:
                break;
            case state.INIT:
                break;
            case state.PLAY:
                if (Time.time - _currentTime > nextActionTime)
                {
                    nextActionTime += period;
                    egg = Instantiate(egg_prefab);
                    egg.SetActive(true);
                    egg.transform.position = new Vector3(Random.Range(-19, 20), 12, 0);
                }

                if (Time.time - _currentTime > nextActTime)
                {
                    nextActTime += timePeriod;
                    _coin = Instantiate(coin_prefab);
                    _coin.SetActive(true);
                    _coin.transform.position = new Vector3(Random.Range(-19, 20), -5, 0);

                }
                if (chicken == null)
                {
                    SwitchState(state.GAMEOVER);
                }
                break;
            case state.GAMEOVER:
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case state.MENU:
                panelMenu.SetActive(false);
                break;
            case state.INIT:
                break;
            case state.PLAY:
                break;
            case state.GAMEOVER:
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }
    }
}
