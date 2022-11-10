using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public SnakeScript Snake;
    public Vector3 PlatformToCameraOfset;
    private float Speed;

    private void Awake()
    {
        Speed = Snake.Speed;
    }
    void Update()
    {
        if (Snake._previousposition == null) return;

        Vector3 targetPosition = Snake._previousposition + PlatformToCameraOfset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,  Speed);
        
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
