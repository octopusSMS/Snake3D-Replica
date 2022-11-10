using UnityEngine;
using Random = System.Random;

public class BlockScript : MonoBehaviour
{
    [Min(1)]
    public int Difficulty;
    public Material[] Material;
    private GameControllerScript Game;
    private TextMesh Text;

    private void Awake()
    {
        Game = FindObjectOfType<GameControllerScript>();
        Random random = new Random();
        Difficulty = random.Next(1, 5);
        Text = GetComponentInChildren<TextMesh>();
        Text.text = Difficulty.ToString();

        switch (Difficulty)
        {
            case 1:
                GetComponent<Renderer>().sharedMaterial = Material[0];
                break;
            case 2:
                GetComponent<Renderer>().sharedMaterial = Material[1];
                break;
            case 3:
                GetComponent<Renderer>().sharedMaterial = Material[2];
                break;
            case 4:
                GetComponent<Renderer>().sharedMaterial = Material[3];
                break;
            case 5:
                GetComponent<Renderer>().sharedMaterial = Material[4];
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Game.DestroySnakePart(Difficulty);
        Destroy(this.gameObject);
    }
}
