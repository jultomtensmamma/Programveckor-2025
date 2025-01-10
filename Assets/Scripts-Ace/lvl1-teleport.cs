using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportButton : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void TeleportToScene(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }
}

