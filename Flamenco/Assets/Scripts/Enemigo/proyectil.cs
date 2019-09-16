using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Analytics;

public class proyectil : MonoBehaviour
{
    /// <summary>
    /// variables:
    /// variable tipo unityevent
    /// gameobjects referentes al jugador y al prefab usado como proyectil
    /// flotante usado para referenciar la direccion del jugador
    /// entero usado para dar direccion al prefab
    /// </summary>
    public UnityEvent Actuador;
    public GameObject Jugador;
    public GameObject prefab;
    public Rigidbody2D cuerpo;
    
    float direccion;
    int flecha;
    // Start is called before the first frame update
    void Start()
    {
        if (Actuador == null)
            Actuador = new UnityEvent();

        direccion = Jugador.transform.position.x - transform.position.x;
        if (direccion < 0)
        {
            flecha = -1;
        }
        else
        {
            flecha = 1;
        }
    }

    // se le da una velocidad de desplazamiento al proyectil
    void Update()
    {
        // direccion = Vector3.Dot(transform.position, Jugador.transform.position);
      
        prefab.GetComponent<Rigidbody2D>().velocity = ((transform.right * flecha) *8f );
        
    }
    
    //trigger de entrada que se ecarga del daño al jugador y el comportamiento del prefab en caso de econtrarse con otro objeto
    //si la tag corresponde a player activa un evento y accede al rigidbody del objeto y le agrega fuerza para dar a entender que se ha generado daño y evitar algun atasco
    //si la tag es la de respawn es decir que que impacta en el tilemap el objeto se desactiva el proyectil
    //si es la de uileria es decir los elementos del escenario se le agrega fuerza al objeto con el que impacta y se desactiva el proyectil
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AnalyticsEvent.Custom("Golpe Burbuja", null);
            Actuador.Invoke();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.right * flecha) * 5000f);
            collision.gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
            
            Vida.healt -= 1;
            prefab.SetActive(false);
            
        }
        if(collision.gameObject.tag == "Respawn")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Utileria")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.right * direccion) * 5000f);
            gameObject.SetActive(false);
        }
    }
    void Ping()
    {

    }
    private void OnDisable()
    {
        Actuador.RemoveListener(Ping);
    }

}
