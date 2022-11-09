using UnityEngine;
using Random = System.Random;

public class BlockScript : MonoBehaviour
{
    
    public int Difficulty;
    private GameControllerScript Game;
    private TextMesh Text;

    private void Awake()
    {
        Game = FindObjectOfType<GameControllerScript>();
        Random random = new Random();
        Difficulty = random.Next(1, 5);
        Text = GetComponentInChildren<TextMesh>();
        Text.text = Difficulty.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Difficulty < Game.SnakeHealt+1)
        {
            Game.DestroySnakePart(Difficulty);
            Destroy(this.gameObject);
        }
        else
            Game.SnakeHealt -= 0;
    }
}
