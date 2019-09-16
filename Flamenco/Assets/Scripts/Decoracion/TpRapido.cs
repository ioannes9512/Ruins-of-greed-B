using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpRapido : MonoBehaviour
{
    public GameObject portal;
   
    /// <summary>
    /// envia al jugador a la posicion en la cual se encuentra este objeto
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(portal.transform.position.x, portal.transform.position.y, 0);
        }
    }
}
