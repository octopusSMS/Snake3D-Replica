using System.Collections;
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
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<CapsuleCollider>());   
        StartCoroutine(WaitForSecondAndDestroy(1));
    }

    IEnumerator WaitForSecondAndDestroy(int seconds)
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
