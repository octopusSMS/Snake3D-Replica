using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out SnakeScript snake)) return;

        snake.ReachFinish();
    }
}
