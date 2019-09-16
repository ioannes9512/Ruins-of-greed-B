using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcrab : MonoBehaviour
{

    public Vida vida;
    public GameObject hero;
    public int HP;
    int direccion;
    float tiempo;
    public AudioSource stepc;
    public GameObject proyectil;
    // Start is called before the first frame update
    void Start()
    {
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
            Tullip.Enemigos = Tullip.Enemigos + 1;
            this.gameObject.SetActive(false);
        }

        detecta();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.right * direccion) * 5000f);
            collision.gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
            vida.Vitalidad.value = vida.Vitalidad.value - 1;


        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void detecta()
    {
        RaycastHit2D detecta = Physics2D.Raycast(transform.position, Vector2.left, 10f);
        if (detecta.collider.tag == "Player")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * detecta.distance, Color.yellow);
        }



    }
}
