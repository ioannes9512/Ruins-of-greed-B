using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class Bossbehavior : MonoBehaviour
{
    /// <summary>
    /// En teoria tiene todo lo de un enemigo normal pero solo se cambia cosas como la ganacia de mana  y un activador para darle fin al nivel
    /// </summary>
    public UnityEvent Actuador;
    public UnityEvent Actuador2;
    public GameObject hero;
    public GameObject portalFinal;
    public float HP;
    int direccion;
    float tiempo;
    public AudioSource stepc;
    // Start is called before the first frame update
    void Start()
    {
        if (Actuador == null)
            Actuador = new UnityEvent();

        Actuador.AddListener(Ping);
        stepc.Play();
        stepc.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hero.transform.localScale.x < 0)
        {
            direccion = 1;

        }
        else
        {
            direccion = -1;
        }
        tiempo = tiempo + Time.deltaTime;
        if (tiempo > 0.5f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
            tiempo = 0;
        }
        if (HP <= 0)
        {
            AnalyticsEvent.Custom("Matar Enemigos", null);
            Tullip.Enemigos = Tullip.Enemigos + 1;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Actuador.Invoke();
            portalFinal.SetActive(true);
            Invoke("Desactivar", 3);
        }

    }
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
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
