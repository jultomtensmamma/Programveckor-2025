using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float floatForce = 6f; // hur mkt kraft f�r att sv�va
    private Rigidbody2D rb; //Fysik komponent
    private bool isFloating = false;// kontrollerar ifall katten sv�var

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rb2D saknas p� objektet");

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) //ifall E tangenten trycks ned
        {
            isFloating = !isFloating; //V�xla mellan sv�va och inte sv�va

            if (isFloating)
            {
                rb.gravityScale = 0; //St�nger av gravitationen
            }
            else
            {
                rb.gravityScale = 1; //�terst�lls gravitationen
            }
        }
    }

    private void FixedUpdate()
    {
        if (isFloating) //Upp�triktad kraft
        {
            rb.AddForce(Vector2.up * floatForce, ForceMode2D.Force);
        }
    }
}
