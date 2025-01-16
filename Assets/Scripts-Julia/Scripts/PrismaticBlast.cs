using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismaticBlast : MonoBehaviour
{
    public GameObject blastPrefab;       // Prefab f�r PrismaticBlast
    public float blastSpeed = 10f;       // Hastigheten p� konen
    public float blastLifetime = 2f;     // Livsl�ngden f�r konen

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

            // R�kna ut riktning baserat p� spelarens skala (h�ger eller v�nster)
            Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

            // L�gg till r�relse till konen
            Rigidbody2D rb = blast.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * blastSpeed; // S�tt hastighet baserat p� riktning
            }

            // R�tta till rotationen p� konen
            float rotationZ = direction.x > 0 ? 0 : 180;
            blast.transform.rotation = Quaternion.Euler(0, rotationZ, 0);

            // F�rst�r konen efter en viss tid
            Destroy(blast, blastLifetime);

            Debug.Log("Prismatic Blast fired!");
        }
    }
}
