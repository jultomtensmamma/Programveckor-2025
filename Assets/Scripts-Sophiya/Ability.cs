using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ability : MonoBehaviour
{
    public float floatForce = 6f; // hur mkt kraft för att sväva
    public float moveSpeed = 5f; //rörelsehastighet
    private Rigidbody2D rb3; //Fysik komponent
    public bool isFloating;
    void Start()
    {
        rb3 = GetComponent<Rigidbody2D>();
        if (rb3 == null)
        {
            Debug.LogError("Rb2D saknas på objektet");

        }
    }

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.LeftShift)) //ifall E tangenten trycks ned
        {
            isFloating = !isFloating; //Växla mellan sväva och inte sväva
            rb3.gravityScale = isFloating ? 0 : 1; //Växla gravitationen
        }
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isFloating = true;
        }

        

        float moveInput = Input.GetAxis("Horizontal"); //Hanterar horisontell rörelse
        rb3.velocity = new Vector2(moveInput* moveSpeed, rb3.velocity.y);
        
        if (isFloating) //Uppåtriktad kraft
        {
            rb3.AddForce(Vector2.up * floatForce, ForceMode2D.Force);
            //rb.velocity = new Vector2(rb.velocity.x, floatForce);
            //Debug.Log(rb3.velocity.y);
        }
        
    }
}
