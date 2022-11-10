using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameControllerScript Game;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out SnakeScript snake)) return;

        Game.OnPlayerReachedFinish();
    }
}
