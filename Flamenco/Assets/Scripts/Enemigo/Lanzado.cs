
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Lanzado : MonoBehaviour
{
    //variables:booleano para censar que el objeto choca cona algo con algo
    //referencia al script que gestiona todo lo de la vida del personaje
    //variables tipo unityevent
    bool Chocar;
    public Vida vida;
    public UnityEvent Actuador;
    public UnityEvent Actuador1;


    
    //habilita el trailrenderer del objeto y crea los eventos de unity
    void Start()
    {
        GetComponent<TrailRenderer>().enabled = true;
        if (Actuador == null)
            Actuador = new UnityEvent();

        Actuador.AddListener(Ping);
        if (Actuador1 == null)
            Actuador1 = new UnityEvent();

        Actuador1.AddListener(Ping);
    }    
    void Ping()
    {
        Debug.Log("Ping");
    }
    //
    private void OnDisable()
    {
        Actuador.RemoveListener(Ping);
        Actuador1.RemoveListener(Ping);
    }
    //
    public void TPRapido(GameObject portal)
    {

    }
    //se cersiora de que el objeto no haya chocado
    //de ser ese el caso se le agrega un addforce para aplicar fuerza constante al objeto
    void Update()
    {
        if(!Chocar)
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 50);
    }
    //metodo de entrada por el cuel se aplica el estado de veneno al jugador
    //si el objeto choca con este y luego se le quita toda la fuerza al objeto y se
    //desactiva todos los componentes del objeto y hace un invoke al metodo desactivar
    //el cual reactiva y desactiva varias propidades del objeto las cuales se aplican en otr
    //corrutina
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Chocar = true;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.right * 0;
        if (collision.gameObject.tag == "Player")
        {
            vida.poisen = true;
        }
        Actuador1.Invoke();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false; 
        Invoke("Desactivar", 0.7f);
    }

    //
    void Desactivar()
    {
        GetComponent<TrailRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        Chocar = false;
        gameObject.SetActive(false);
    }
}
