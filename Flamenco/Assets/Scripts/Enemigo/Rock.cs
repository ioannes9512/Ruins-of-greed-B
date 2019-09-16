using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Analytics;

public class Rock : MonoBehaviour
{
    //variables: solo una variable tipo unityevent
    public UnityEvent Actuador;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Actuador == null)
            Actuador = new UnityEvent();

        Actuador.AddListener(Ping);
    }

    //en el update solo se añade rotacion en z
    void Update()
    {
        gameObject.transform.Rotate(0,0,5);
    }
 
    //colision que se encarga del daño de la piedra 
    //si colisiona con el tag designado el personaje cambia de color 
    //y se le resta vida ára luego desactivar el sprite y el collider y por ultimo notifica de que colision se  por medio de un evento 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AnalyticsEvent.Custom("Piedraso", null);
            
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Vida.healt -= 2;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            Actuador.Invoke();
            Invoke("Desactivar", 3);
            Debug.Log("rock");

        }
        //para evitar posibles errores o incovenientes el objeto se desactiva si choca con objetos que tengan el tag respawn o utileria los
        //los cuales pertenecen al posicion o checkpoint donde reaparece el jugador o al ambiente
        if ((collision.gameObject.tag == "Respawn")||(collision.gameObject.tag == "Utileria"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            Actuador.Invoke();
            Invoke("Desactivar", 3);
        }
            
    }
    //salida de la colision en donde el jugador el color del jugador cambia de nuevo por el original y se llama al evento que desactiva el objeto
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Actuador.Invoke();
            Invoke("Desactivar", 3);
        }
    }
    void Ping()
    {
        //Debug.Log("Ping");
    }
    //metodo usado por el objeto para desactivar el objeto
    void Desactivar()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        Actuador.RemoveListener(Ping);
    }
}
