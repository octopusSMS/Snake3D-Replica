using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextScript : MonoBehaviour
{
    public GameControllerScript Game;
    public Text Text;

    private void Update()
    {
        Text.text = (Game.SnakeHealth).ToString();
    }
}
