using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    Rigidbody2D rb;

    /// <summary>
    /// aumenta la gravedad del jugador cuando entra en el espacio de este objeto y le agrega una fuerza hacia abajo
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, -50));
            rb.gravityScale = 6;
            
        }
    }
    /// <summary>
    /// restable la grabbedad que tenia el jugador antes de entrar al espacio del objeto
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
    }


}
