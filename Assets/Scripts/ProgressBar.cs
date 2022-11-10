using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public SnakeScript Player;
    public Transform FinishPlatform;
    public Slider Slider;

    private void Update()
    {
        float finishZ = FinishPlatform.transform.position.z;
        float t = (Player.transform.position.z+5)/finishZ;

        Slider.value = t;
    }
}
