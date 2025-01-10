using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void TeleportToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

