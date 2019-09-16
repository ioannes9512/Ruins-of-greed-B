using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    bool Check = false;
    /// <summary>
    /// guarda la posicion del jugador despues de cierto punto en el manpa
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (!Check)
        {
            if (collision.gameObject.tag == "Player")
            {
                Vida vida = collision.GetComponent<Vida>();
                vida.RespawnN = vida.RespawnN + 1;
                Debug.Log(vida.RespawnN);
                Check = true;
            }
        }

    }
}
