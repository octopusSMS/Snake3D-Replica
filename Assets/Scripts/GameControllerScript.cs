using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public List<GameObject> Snake;

    public GameObject SnakePrefab;

    public SnakeScript Controls;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; private set; }

    private const string LevelIndexKey = "LevelIndex";

    public void OnSnakeDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over!");

        //Slider.SetActive(false);
        //TextDestroyedPlatforms.SetActive(false);
        //RestartButton.SetActive(true);
        ReloadLevel();
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        //LevelIndex++;
        Controls.enabled = false;
        Debug.Log("You won!");
        
        ReloadLevel();
    }

    private void Awake()
    {
        //CreateSnakePart(3);
        //DestroySnakePart(1);
    }
    public void CreateSnakePart(int _partsnumber)
    {
        for (int i = 0; i < _partsnumber; i++)
        {
            var Snakepart = Instantiate(SnakePrefab, this.transform);
            Snakepart.GetComponent<SnakeScript>().previouspart = Snake.Last();
            Snake.Add(Snakepart);
        }
    }
    public void DestroySnakePart( int _partsnumber)
    {
        for (int i = 0; i < _partsnumber; i++)
        {
            Destroy(Snake.Last());
            Snake.RemoveAt(Snake.IndexOf(Snake.Last()));
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
}
