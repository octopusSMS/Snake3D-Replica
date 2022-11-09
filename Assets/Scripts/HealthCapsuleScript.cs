using UnityEngine;
using Random = System.Random;

public class HealthCapsuleScript : MonoBehaviour
{
    private GameControllerScript Game;
    public int HealthCapacity;    
    private TextMesh Text;

    private void Awake()
    {
        Game = FindObjectOfType<GameControllerScript>();
        Random random = new Random();
        HealthCapacity = random.Next(1, 5);
        Text = GetComponentInChildren<TextMesh>();
        Text.text = HealthCapacity.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        Game.CreateSnakePart(HealthCapacity); 
        Destroy(this.gameObject);
    }
    
}
