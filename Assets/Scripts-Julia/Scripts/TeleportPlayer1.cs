using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // F�r att hantera scenbyte

public class TeleportPlayer : MonoBehaviour
{
    public string nextSceneName; // Namnet p� n�sta scen att teleportera till
    public InventorySystem inventory; // Referens till spelarens InventorySystem

    private bool canTeleport = false; // Om spelaren kan teleportera

    void Update()
    {
        //canTeleport = true;
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
        if (!string.IsNullOrEmpty("Level3"))
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
