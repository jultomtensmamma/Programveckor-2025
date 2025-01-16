using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ability : MonoBehaviour
{
    public float floatForce = 6f; // hur mkt kraft f�r att sv�va
    public float moveSpeed = 5f; //r�relsehastighet
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
            rb.gravityScale = isFloating ? 0 : 1; //V�xla gravitationen
        }

         
        float moveInput = Input.GetAxis("Horizontal"); //Hanterar horisontell r�relse
        rb.velocity = new Vector2(moveInput* moveSpeed, rb.velocity.y);

        if (isFloating) //Upp�triktad kraft
        {
            rb.AddForce(Vector2.up * floatForce, ForceMode2D.Force);
        }
    }
}
