using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float floatForce = 6f; // hur mkt kraft för att sväva
    private Rigidbody2D rb; //Fysik komponent
    private bool isFloating = false;// kontrollerar ifall katten svävar

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rb2D saknas på objektet");

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //ifall E tangenten trycks ned
        {
            isFloating = !isFloating; //Växla mellan sväva och inte sväva

            if (isFloating)
            {
                rb.gravityScale = 0; //Stänger av gravitationen
            }
            else
            {
                rb.gravityScale = 1; //Återställs gravitationen
            }
        }
    }

    private void FixedUpdate()
    {
        if (isFloating) //Uppåtriktad kraft
        {
            rb.AddForce(Vector2.up * floatForce, ForceMode2D.Force);
        }
    }
}
