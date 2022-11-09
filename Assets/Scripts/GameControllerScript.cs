using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public List<GameObject> Snake;

    public GameObject SnakePrefab;

    public SnakeScript Controls;

    [HideInInspector]
    public int SnakeHealt;

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
        SnakeHealt = 3;
        CreateSnakePart(SnakeHealt - 1);
    }

    private void Update()
    {
        if (SnakeHealt <=0)
            OnSnakeDied();
    }
    public void CreateSnakePart(int _partsnumber)
    {
        for (int i = 0; i < _partsnumber; i++)
        {
            var Snakepart = Instantiate(SnakePrefab, this.transform);
            Snakepart.GetComponent<SnakeScript>().previouspart = Snake.Last();
            Snakepart.transform.position = new Vector3(Snake.Last().transform.position.x, Snakepart.transform.position.y, (Snake.Last().transform.position.z-1));
            Snake.Add(Snakepart);
        }
        SnakeHealt += _partsnumber;
    }
    public void DestroySnakePart( int _partsnumber)
    {
        for (int i = 0; i < _partsnumber; i++)
        {
            Destroy(Snake.Last());
            Snake.RemoveAt(Snake.IndexOf(Snake.Last()));
        }
        SnakeHealt -= _partsnumber;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 1);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
}
