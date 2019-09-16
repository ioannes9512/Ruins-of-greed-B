using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combate : MonoBehaviour
{
    public AudioManager audioManager;
 /// <summary>
 /// reproduce la musica de enfrentamiento con el jefe del nivel
 /// </summary>
 /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioManager.cambioboss();
        }
    }
}
