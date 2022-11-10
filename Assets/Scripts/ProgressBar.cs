using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public SnakeScript Player;
    public Transform FinishPlatform;
    public Slider Slider;
    private float AcceptableFinishPlayerDistance = 1f;

    private float _startZ;
    private float _minimumReachedZ;

    private void Start()
    {
        _startZ = Player.transform.position.z;
    }

    private void Update()
    {
        _minimumReachedZ = Mathf.Min(_minimumReachedZ, Player.transform.position.z);
        float finishZ = FinishPlatform.transform.position.z;

        float t = Mathf.InverseLerp(_startZ, finishZ + AcceptableFinishPlayerDistance, _minimumReachedZ);

        Slider.value = t;
    }
}
