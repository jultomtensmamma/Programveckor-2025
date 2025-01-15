using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismaticBlast : MonoBehaviour
{
    public float blastRange = 5f;         // Räckvidd för konen
    public float blastAngle = 60f;       // Vinkeln på konen
    public GameObject blastEffectPrefab; // Visuell effekt för konen

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // När LShift trycks
        {
            ActivateBlast();
        }
    }

    private void ActivateBlast()
    {
        // Spela visuell effekt om sådan finns
        if (blastEffectPrefab != null)
        {
            Instantiate(blastEffectPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, transform.right));
        }

        Debug.Log("Prismatic Blast Activated!");
    }

    private void OnDrawGizmosSelected()
    {
        // Räkna ut spelarens riktning
        Vector3 forwardDirection = transform.right;

        // Rita konens gränser i spelarens riktning
        Vector3 leftBoundary = Quaternion.Euler(0, 0, -blastAngle / 2) * forwardDirection * blastRange;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, blastAngle / 2) * forwardDirection * blastRange;

        // Rita räckviddscirkel
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, blastRange);

        // Rita konens gränser
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
