using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sword : MonoBehaviour
{
    /// <summary>
    /// variables:
    /// eventos de unity
    /// flotante para manipular la direccion mediante la escala
    /// gameobject que sera la referencia al personaje
    /// flotante estatico cuyo valor representa al daño
    /// </summary>
    public UnityEvent ActuadorL;
    public UnityEvent ActuadorR;
    float direcion;
    public GameObject hero;
    SpriteRenderer red;
    public static float daño;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //generacion de eventos
        if (ActuadorL == null)
            ActuadorL = new UnityEvent();

        ActuadorL.AddListener(Ping);
        if (ActuadorR == null)
            ActuadorR = new UnityEvent();
        //
        ActuadorR.AddListener(Ping);

        //valor del daño
        daño = 1;
    }
   

    // Update is called once per frame
    void Update()
    {
        //cambio de direccion atravez de la escala del personaje
        if (hero.transform.localScale.x > 0)
        {
            direcion = 1;
                   
        }
        else
        {
            direcion = -1;
            
        }
     
    }
 
    //on trigger donde se  genera el daño al enemigo 
    //ese solo se genera si el objeto tiene la tag de enemy
    //dentro de este se obtiene el coponente del objeto que entra al espacio de este gameobject 
    //si la tag es la que pide le resta vida y cambia el color del objeto para dar retroalimentacion
    //y adicionalmente con cada golpe se suma puntos de mana los cuales son requiridos para poder usar el ataque secundario
    private void OnTriggerEnter2D(Collider2D collision)
    {

       if(collision.gameObject.tag == "Enemy")
       {
            
            if (hero.transform.localScale.x >= 0)
            {
                ActuadorL.Invoke();
            }
            else
            {
                ActuadorR.Invoke();
            }
            if (collision.gameObject.GetComponent<crab2>())
            {
                collision.gameObject.GetComponent<crab2>().HP -= daño;

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce((Vector2.right * direcion) * 500f);                                         
            }
            if (collision.gameObject.GetComponent<Enemigo>())
            {
                collision.gameObject.GetComponent<Enemigo>().HP -= daño;
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce((Vector2.right * direcion) * 500f);
            }
            red = collision.gameObject.GetComponent<SpriteRenderer>();           
            Vida.mana += 3;

        }
        //on trigger donde se  genera el daño al boss
        //ese solo se genera si el objeto tiene la tag de boss
        //dentro de este se obtiene el coponente del objeto que entra al espacio de este gameobject 
        //si la tag es la que pide le resta vida y cambia el color del objeto para dar retroalimentacion
        //y adicionalmente con cada golpe se suma puntos de mana los cuales son requiridos para poder usar el ataque secundario
        if (collision.gameObject.tag == "Boss")
        {
            if (hero.transform.localScale.x >= 0)
            {
                ActuadorL.Invoke();
            }
            else
            {
                ActuadorR.Invoke();
            }
            if (collision.gameObject.GetComponent<Bossbehavior>())
            {
                collision.gameObject.GetComponent<Bossbehavior>().HP -= daño;
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce((Vector2.right * direcion) * 500f);
            }
          
            red = collision.gameObject.GetComponent<SpriteRenderer>();
            Vida.mana += 1;
        }
       
    }
    //trigger de salida en el cual el enemigo vuelve a su color normal
    private void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
       
    }
    //metodo de extenxion por el cual enemigo cambia de color a rojo 
    void Damage()
    {

        red.RenderEnemy();

    }
    //metodos on enable y disable relacionados con los eventos 
    private void OnEnable()
    {
        EventManager.OnClicked += Damage;
    }
    private void OnDisable()
    {
        ActuadorL.RemoveListener(Ping);
        ActuadorR.RemoveListener(Ping);
        EventManager.OnClicked -= Damage;
    }
    //
    void Ping()
    {

    }
}
