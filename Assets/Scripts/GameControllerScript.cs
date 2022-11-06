using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public List<GameObject> Snake;

    public GameObject SnakePrefab;


    private void Awake()
    {
        //CreateSnakePart(3);
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
            //Destroy()
        }
    }
}
