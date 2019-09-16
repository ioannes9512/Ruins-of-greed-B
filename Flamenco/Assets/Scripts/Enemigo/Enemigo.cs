using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class Enemigo : MonoBehaviour
{
    /// <summary>
    /// variables:
    /// unityevents
    /// gameobject referente al personaje
    /// flotante que sera usado como la vida del enemigo y otro para implmentar 
    /// un contador
    /// un entero que sera usado para modificar la direcion del enemigo atravez 
    /// de del localscale
    /// y un audiosource
    /// </summary>
    public UnityEvent Actuador;
    public UnityEvent Actuador2;
    public GameObject hero;
    public float HP;
    int direccion;
    float tiempo;
    public AudioSource stepc;
    // Start is called before the first frame update
    void Start()
    {
        //creacion de un nuevo evento
        if (Actuador == null)
            Actuador = new UnityEvent();

        Actuador.AddListener(Ping);
        //reproduccion del audiosource junto con el loop para que haya retroalimentacion
        stepc.Play();
        stepc.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        //condicional que regula la direccion del enemigo
        if(hero.transform.localScale.x < 0)
        {
            direccion = 1;
            
        }
        else
        {
            direccion = -1;
        }
        //inicializacion del contador
        tiempo = tiempo + Time.deltaTime;
        //cambio de color y reinicio de contador
        if (tiempo > 0.5f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
            tiempo = 0; 
        }
        //condicion de muerte del enemigo
        if (HP <= 0)
        {
            AnalyticsEvent.Custom("Matar Enemigos", null);
            Tullip.Enemigos = Tullip.Enemigos + 1;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Actuador.Invoke();
            Invoke("Desactivar", 3);
        }
        
    }

    //condicion para hacer daño al personaje
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Actuador2.Invoke();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.right * direccion) * 5000f);
            collision.gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
           // collision.gameObject.GetComponent<Froga>().daño.Play();           
            Vida.healt -= 1;


        }
    }
    //condicion de salida para que el personaje 
    //pueda volver a su color original
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void Desactivar()
    {
        gameObject.SetActive(false);
    }
    void Ping()
    {
       
    }
    private void OnDisable()
    {
        Actuador.RemoveListener(Ping);
    }
}
