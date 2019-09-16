using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Analytics;

public class crab2 : MonoBehaviour
{
    /// <summary>
    /// declaracion de variables 
    /// eventos de unity
    /// referencia al script de vida del personaje
    ///  variables gameobject referente al jugador y al objeto instanciado como proyectil
    /// variables numericas 2 tipo float para la vida del enemigo y el tiempo que demora el cambio de color del sprite
    /// y una entera para modificar la escala del enemigo cuando cambie de direccion
    /// un audiosource del enemigo
    /// un trasform referente a la posicion desde la cual se instanciara el proyectil
    /// referencia al spriterenderer del personaje
    /// </summary>
    public UnityEvent Actuador;
    public UnityEvent Actuador2;
    public Vida vida;
    public GameObject hero;
    public float HP;
    int direccion;
    float tiempo;
    SpriteRenderer normal;
    public AudioSource stepc;
    public GameObject proyectil;
    public Transform referencia;
    float tempus;
    public Animator crab;
    bool caminar;
    private Patrulla patrol;
    bool Muerto;
    // Start is called before the first frame update
    void Start()
    {
        //condicional que crea le evento de unity
        if (Actuador == null)
            Actuador = new UnityEvent();
       normal =  this.gameObject.GetComponent<SpriteRenderer>();//obtiene el sprite renderer del enemigo       
        Actuador.AddListener(Ping);
        //reproduce y loopea el audiosource
        stepc.Play();
        stepc.loop = true;
      //  crab.SetBool("camine", true);
    }

    // Update is called once per frame
    void Update()
    {
        //obtiene el script de patrullla  
        patrol = GetComponent<Patrulla>();
        //cabio de escala al cambiar de direccion
        if (hero.transform.localScale.x < 0)
        {
            direccion = 1;

        }
        else
        {
            direccion = -1;
        }
        tiempo = tiempo + Time.deltaTime;
        //retorno al color normal pasado el tiempo del contador
        if (tiempo > 0.5f)
        {
            normal.material.color = Color.white;
            tiempo = 0;
        }
        //condicion para la muerte del enemigo
        if (HP <= 0)
        {
            AnalyticsEvent.Custom("Matar Lanzador Enemigos", null);
            Tullip.Enemigos = Tullip.Enemigos + 1;
            Muerto = true;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Actuador.Invoke();
        }
        //de lo contrario continua con su estado de patrulla
        if (!Muerto)
        {
            detecta();
        } 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //collision con el jugador en la cual se hace daño al jugador
        //con su respectiva reatroalimentacion
        if (collision.gameObject.tag == "Player")
        {
            Actuador2.Invoke();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.right * direccion) * 5000f);
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;          
            Vida.healt -= 1;


        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //condicion para retornar a su color original al jugador
            //collision.gameObject.GetComponent<Renderer>().material.color = Color.white;
            collision.gameObject.GetComponent<Renderer>().gestioncolor();
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
    //metodo donde se gestiona todo lo referente al lanzamiento de proyectiles
    void detecta()
    {
        RaycastHit2D detecta = Physics2D.Raycast(referencia.transform.position, referencia.transform.right *patrol.getDirection(), 1000f);
        //Debug.Log(detecta.point);
        Debug.DrawRay(referencia.position, referencia.transform.right * patrol.getDirection(), Color.yellow);
        tempus = tempus + Time.fixedDeltaTime;
        if (detecta.collider.gameObject.tag == "Player" && tempus >=3)
        {
            Debug.Log("Dispara");
            Instantiate(proyectil, referencia.position, Quaternion.identity);
            tempus = 0;
        }
    }
}

