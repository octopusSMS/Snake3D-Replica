using UnityEngine;
using UnityEngine.UI;

public class LevelTextScript : MonoBehaviour
{
    public Text Text;
    public GameControllerScript Game;

    private void Start()
    {
        Text.text = "Level: " + (Game.LevelIndex).ToString();
    }
}
