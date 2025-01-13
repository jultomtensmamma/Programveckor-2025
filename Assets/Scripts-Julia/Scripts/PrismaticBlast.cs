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
            Instantiate(blastEffectPrefab, transform.position, Quaternion.identity);
        }

        // Rita en kon i scenen för att visa var effekten sker (endast visuellt)
        Debug.Log("Prismatic Blast Activated!");
    }

    private void OnDrawGizmosSelected()
    {
        // Visa räckvidd och vinkel för konen i scenen
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, blastRange);

        // Rita konens gränser
        Vector3 leftBoundary = Quaternion.Euler(0, 0, -blastAngle / 2) * transform.right * blastRange;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, blastAngle / 2) * transform.right * blastRange;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
