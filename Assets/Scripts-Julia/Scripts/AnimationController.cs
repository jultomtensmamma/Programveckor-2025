using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;      // Referens till Animator-komponenten
    private bool isRunning = false; // Bool för att hålla reda på spelarens rörelsestatus

    void Start()
    {
        // Hämta Animator-komponenten på spelaren
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Kontrollera om spelaren rör sig (t.ex. via input)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Om spelaren rör sig, sätt isRunning till true, annars false
        if (Mathf.Abs(horizontalInput) > 0.7f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        // Uppdatera Animator med bool-värdet
        animator.SetBool("isRunning", isRunning);
    }
}
