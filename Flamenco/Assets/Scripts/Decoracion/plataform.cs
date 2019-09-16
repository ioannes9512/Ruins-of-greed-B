using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataform : MonoBehaviour {


    /// <summary>
    /// hace al jugador hijo en la herencia de la plataforma
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        collision.gameObject.transform.SetParent(gameObject.transform);
    }
    /// <summary>
    /// deshace al jugador hijo en la herencia de la plataforma
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
