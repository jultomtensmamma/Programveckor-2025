using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ability : MonoBehaviour
{
    public float floatForce = 6f; // hur mkt kraft för att sväva
    public float moveSpeed = 5f; //rörelsehastighet
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
        if (Input.GetKeyDown(KeyCode.LeftShift)) //ifall E tangenten trycks ned
        {
            isFloating = !isFloating; //Växla mellan sväva och inte sväva
            rb.gravityScale = isFloating ? 0 : 1; //Växla gravitationen
        }

         
        float moveInput = Input.GetAxis("Horizontal"); //Hanterar horisontell rörelse
        rb.velocity = new Vector2(moveInput* moveSpeed, rb.velocity.y);

        if (isFloating) //Uppåtriktad kraft
        {
            rb.AddForce(Vector2.up * floatForce, ForceMode2D.Force);
        }
    }
}
