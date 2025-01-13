using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismaticBlast : MonoBehaviour
{
    public float blastRange = 5f;         // R�ckvidd f�r konen
    public float blastAngle = 60f;       // Vinkeln p� konen
    public GameObject blastEffectPrefab; // Visuell effekt f�r konen

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // N�r LShift trycks
        {
            ActivateBlast();
        }
    }

    private void ActivateBlast()
    {
        // Spela visuell effekt om s�dan finns
        if (blastEffectPrefab != null)
        {
            Instantiate(blastEffectPrefab, transform.position, Quaternion.identity);
        }

        // Rita en kon i scenen f�r att visa var effekten sker (endast visuellt)
        Debug.Log("Prismatic Blast Activated!");
    }

    private void OnDrawGizmosSelected()
    {
        // Visa r�ckvidd och vinkel f�r konen i scenen
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, blastRange);

        // Rita konens gr�nser
        Vector3 leftBoundary = Quaternion.Euler(0, 0, -blastAngle / 2) * transform.right * blastRange;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, blastAngle / 2) * transform.right * blastRange;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
