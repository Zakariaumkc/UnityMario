using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject PlayerPrefab;
    public Text scoreText;
    public Text levelText;
    public Text extraLifesText;

    public GameObject panelPlay;
    public GameObject panelMenu;
    public GameObject panelScore;
    public GameObject panelextraLifes;
    public GameObject panelLevel;

    public static GameManager Instance { get; private set; }
    private int _score;
    private int _level;
    private int _extraLifesScore;
    public enum State { Menu, Init, Play, GameOver, LevelCompleted}
    State _state;
    public int Score
    {
        get { return _score; }
        set { _score = value;
        scoreText.text = "SCORE: " + _score ;}
    }
    public int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            levelText.text = "LEVEL: " + _level;
        }
    }
    public int ExtraLifes
    {
        get { return _extraLifesScore; }
        set
        {
            _extraLifesScore = value;
            extraLifesText.text = "LIFESCORE: " + _extraLifesScore;
        }
    }
    public void PlayClicked()
    {
        Score = 0;
        Level = 1;
        ExtraLifes = 0;
        Player.PlayerInstance.BeginGameSet = true;
        SwitchState(State.Init);
    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case State.Menu:
                break;
            case State.Init:
                
                break;
            case State.GameOver:
                break;
            case State.Play:
                break;
            case State.LevelCompleted:
                break;
        }
    }
    public void SwitchState(State newState)
    {
        EndState();
        BeginState(newState);
    }
    void BeginState(State newState)
    {
        switch(newState)
        {
            case State.Menu:
                panelMenu.SetActive(true);
                break;
            case State.Init:
                panelPlay.SetActive(false);
                panelScore.SetActive(true);
                break;
            case State.GameOver:
                break;
            case State.Play:
                break;
            case State.LevelCompleted:
                break;
        }
    }
    void EndState()
    {
        switch (_state)
        {
            case State.Menu:
                //panelMenu.SetActive(false);
                break;
            case State.Init:
                break;
            case State.GameOver:
                break;
            case State.Play:
                break;
            case State.LevelCompleted:
                break;
        }
    }
}
