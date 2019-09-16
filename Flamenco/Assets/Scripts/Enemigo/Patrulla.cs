using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
    public float speed;
    public Transform Player;
    float vX;
    public float xIni;
    public float xFin;

    private float Visto;
    private Rigidbody2D body;

    private int direction = 1;
    /// <summary>
    /// asigna una variable para la escala en x del gameObject 
    /// inicia la coroutine Patrol()
    /// </summary>
    void Start()
    {

        vX = transform.localScale.x;
        StartCoroutine(Patrol());
    }
    /// <summary>
    /// Visto es asignada en la coroutine como un valor flotante entregado por la funcion Vector3.Dot
    /// de esta manera se determina la distancia del enemigo con el jugador
    /// </summary>

    void Update()
    {
       
        if(Visto < 5)
        {
            speed = 6;
        }
        else
        {
            speed = 4;
        }
    }
    /// <summary>
    /// se asigna el componente Rigidbody2D a la variable body,
    /// se realizan confirmaciones para determinar en que direccion deberia estar mirando el GameObject
    /// con la funcion velocity se le otorga al GameObject desplazamiento
    /// se le otorga el transform.position al vector3 vectorOther y se le resta la posicion del GameObject para determinar la distancia entre los dos GameObject
    /// </summary>
    /// <returns></returns>
    IEnumerator Patrol()
    {
        body = GetComponent<Rigidbody2D>();

        while (true)
        {
          
            if (transform.position.x > xFin )
            {
                direction = -1;
                
            }
            else if (transform.position.x < xIni)
            {
                direction = 1;
            }


        

            if (direction == 1 && transform.localScale.x > 0)
            {
                transform.localScale =  new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            if (direction == -1 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            body.velocity = (transform.right * direction) * speed;
            
            Vector3 vectorOther = Player.position - transform.position;
            Visto = (Vector3.Dot(-transform.right * direction, vectorOther));
            
            yield return new WaitForEndOfFrame();
        }
    }

    public int getDirection()
    {
        return direction;
    }
}
