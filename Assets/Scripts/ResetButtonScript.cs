using UnityEngine;
using UnityEngine.UI;

public class ResetButtonScript : MonoBehaviour
{
    public GameControllerScript Game;
    public Button Button;

    private void Update()
    {
        Button.onClick.AddListener(Game.ReloadLevel);
    }
}
