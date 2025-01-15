using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public bool hasComponent1 = false; // Om spelaren har plockat upp Komponent1
    public bool hasComponent2 = false; // Om spelaren har plockat upp Komponent2
    public bool hasComponent3 = false; // Om spelaren har plockat upp Komponent3

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kontrollera vilket objekt spelaren plockar upp
        if (other.CompareTag("Component1"))
        {
            hasComponent1 = true;
            Debug.Log("Picked up Component1!");
            Destroy(other.gameObject); // Ta bort objektet från scenen
        }
        else if (other.CompareTag("Component2"))
        {
            hasComponent2 = true;
            Debug.Log("Picked up Component2!");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Component3"))
        {
            hasComponent3 = true;
            Debug.Log("Picked up Component3!");
            Destroy(other.gameObject);
        }
    }
}
