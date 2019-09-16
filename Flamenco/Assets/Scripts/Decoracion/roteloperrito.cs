using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class roteloperrito : MonoBehaviour {
    public Vida vida;

    /// <summary>
    /// genera una rotacion constante del objeto
    /// </summary>
	void Update () {
        transform.Rotate(0f, 0f,5f );
	}
    /// <summary>
    /// si el objeto que entra en contacto es el jugador le reduce 2 puntos de vida y cambia el color del sprite a rojo
    /// </summary>
    /// <param name="collision"></param>
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AnalyticsEvent.Custom("DañoSierra", null);
            vida = GetComponent<Vida>(); 
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Vida.healt -=  2;
        }
        
        
    }
    /// <summary>
    /// cambia el color del sprite a blanco
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
