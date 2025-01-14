using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;      // Referens till Animator-komponenten
    private bool isRunning = false; // Bool f�r att h�lla reda p� spelarens r�relsestatus

    void Start()
    {
        // H�mta Animator-komponenten p� spelaren
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Kontrollera om spelaren r�r sig (t.ex. via input)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Om spelaren r�r sig, s�tt isRunning till true, annars false
        if (Mathf.Abs(horizontalInput) > 0.20f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        // Uppdatera Animator med bool-v�rdet
        animator.SetBool("isRunning", isRunning);
    }
}
