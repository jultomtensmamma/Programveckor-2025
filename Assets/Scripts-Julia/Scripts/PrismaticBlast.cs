using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismaticBlast : MonoBehaviour
{
    public GameObject blastPrefab;       // Prefab för PrismaticBlast
    public float blastSpeed = 10f;       // Hastigheten på konen
    public float blastLifetime = 2f;     // Livslängden för konen

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // Aktivera konen med LeftShift
        {
            FireBlast();
        }
    }

    private void FireBlast()
    {
        if (blastPrefab != null)
        {
            // Skapa konen vid spelarens position
            GameObject blast = Instantiate(blastPrefab, transform.position, Quaternion.identity);

            // Räkna ut riktning baserat på spelarens skala (höger eller vänster)
            Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

            // Lägg till rörelse till konen
            Rigidbody2D rb = blast.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * blastSpeed; // Sätt hastighet baserat på riktning
            }

            // Rätta till rotationen på konen
            float rotationZ = direction.x > 0 ? 0 : 180;
            blast.transform.rotation = Quaternion.Euler(0, rotationZ, 0);

            // Förstör konen efter en viss tid
            Destroy(blast, blastLifetime);

            Debug.Log("Prismatic Blast fired!");
        }
    }
}
