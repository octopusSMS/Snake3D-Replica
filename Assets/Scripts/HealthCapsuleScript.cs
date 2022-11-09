using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class HealthCapsuleScript : MonoBehaviour
{
    public GameControllerScript game;
    public int HealthCapacity;    
    private TextMesh Text;

    private void Awake()
    {
        Random random = new Random();
        HealthCapacity = random.Next(1, 5);
        Text = GetComponentInChildren<TextMesh>();
        Text.text = HealthCapacity.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        game.CreateSnakePart(HealthCapacity); 
        Destroy(this);
    }
    
}
