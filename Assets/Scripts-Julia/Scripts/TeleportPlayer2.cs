using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // För att hantera scenbyte

public class TeleportPlayer2 : MonoBehaviour
{
    public string nextSceneName; // Namnet på nästa scen att teleportera till

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kontrollera om spelaren nuddar teleportpunkten
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player teleported to the next scene!");
            Teleport();
        }
    }

    private void Teleport()
    {
        if (!string.IsNullOrEmpty("Level3"))
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
