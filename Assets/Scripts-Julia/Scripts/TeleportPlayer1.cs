using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // För att hantera scenbyte

public class TeleportPlayer : MonoBehaviour
{
    public string nextSceneName; // Namnet på nästa scen att teleportera till
    public InventorySystem inventory; // Referens till spelarens InventorySystem

    private bool canTeleport = false; // Om spelaren kan teleportera

    void Update()
    {
        // Kontrollera om alla komponenter har samlats in
        if (inventory != null && inventory.hasComponent1 && inventory.hasComponent2 && inventory.hasComponent3)
        {
            canTeleport = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kontrollera om spelaren nuddar teleportpunkten
        if (other.CompareTag("Player") && canTeleport)
        {
            Debug.Log("Player teleported to the next scene!");
            Teleport();
        }
    }

    private void Teleport()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
