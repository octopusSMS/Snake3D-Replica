using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public List<GameObject> Snake;

    public GameObject SnakePrefab;

    public SnakeScript Controls;
    public GameObject WinTextImage;
    public GameObject ResetButton;
    public ParticleSystem FinishParticle;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; private set; }

    private const string LevelIndexKey = "LevelIndex";
    private const string SnakeHealthKey = "SnakeHealth";

    public void OnSnakeDied()
    {
        if (CurrentState != State.Playing) return;
        
        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over!");

        ResetButton.SetActive(true);        
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        Snake[0].GetComponent<SnakeScript>().Speed = 0;
        CurrentState = State.Won;
        LevelIndex++;
        Controls.enabled = false;
        //Debug.Log("You won!");
        StartCoroutine (WaitForSecondAndReload(1));
        WinTextImage.SetActive(true);
    }

    private void Awake()
    {
        if (SnakeHealth<=2)
            CreateSnakePart(2);
        else
            CreateSnakePart(SnakeHealth);
    }

    private void Update()
    {
        SnakeHealth = transform.childCount-1;
        if (SnakeHealth <=0)
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
    }
    public void DestroySnakePart( int _partsnumber)
    {
        for (int i = 0; i < _partsnumber; i++)
        {
            if (Snake.Count == 1) return;
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
        get => PlayerPrefs.GetInt(LevelIndexKey, 1);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    public int SnakeHealth
    {
        get => PlayerPrefs.GetInt(SnakeHealthKey, 2);
        private set
        {
            PlayerPrefs.SetInt(SnakeHealthKey, value);
            PlayerPrefs.Save();
        }
    }

    IEnumerator WaitForSecondAndReload(int seconds)
    {
        FinishParticle.Play();
        yield return new WaitForSeconds(seconds);
        ReloadLevel();
    }
}
