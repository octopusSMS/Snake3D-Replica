using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public bool IsInvisibleBlock;
    public int Difficulty;

    private void Start()
    {
        if (IsInvisibleBlock)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
