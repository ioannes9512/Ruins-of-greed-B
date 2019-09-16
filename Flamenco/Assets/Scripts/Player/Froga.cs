    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Froga : MonoBehaviour {
    UnityEvent m_MyEvent;

    public Animator Frog;//animator del personaje
    public CharacterController2D Controle;//controlador de personaje del cual se importan caracteristicas como salto
    public Rigidbody2D m_Rigidbody2D;//rigidbody del personaje
    public GameObject idelCam;//camara de comportamiento idle
    public GameObject movingCam;//camara principal de movimiento
    public GameObject damageCam;//camara que da retroalimentacion del daño
    public GameObject camerapersp;//camara que sirve para dar perspectiva al jugador al mirar hacia abajo
    public GameObject actack;//referencia al gameobject que contiene el collider de la espada 
    public GameObject power;//referencia al gameobject instanciado que contiene el script del powerup
    public GameObject Final;//referencia de posicion para el instanciate del power up
    public AudioSource step;//sonido de los pasos del personaje
    public Vector2 UltimaPosicion;//referencia al raycast de la ultima posicion para los check points
    public PowerPow pow;//referencia al pool que contiene el prefab del power up
    ///variables float y booleanas utilizadas poara diferentes procesos
    ///como contadores manejo de velocidades habilitar o deshabilitar,
    ///permitir acciones como el movimiento etc junto con un vector 3 y un spriterenderer el cual es usado
    ///en una corrutina para cambio de color del rojo de daño a blanco es decir su color normal
    float direccion;
    bool Snif;
    bool Slar;
    bool Tempo;
    bool suenelo;
    float timpo;
    float Temporal;
    float otroTempo;
    SpriteRenderer colorNorm;
    float Null;
    float Can;
    public bool dañino = true;
    public bool stay = true;
    public static bool habilitado,dPress = false;
    float Moverla;
    int count;
    public static bool itsPause = false;
    Vector3 forward;
    // Use this for initialization
    void Start () {
        transform.TransformMe();//referencia al metodo de extension encargado del transform
        GetComponent<Rigidbody2D>().RigydFrezz();//uso de getcomponente junto con el metodo de extension
        colorNorm = GetComponent<SpriteRenderer>();//spriterenderer del personaje 
        actack.SetActive(false);//se desactiva el collider de la espada para que sea activado solo con la tecla asignado
        StartCoroutine("StayWhite");//inicio de corrutina encargada del cambio de color
        forward = transform.TransformDirection(Vector3.down);
    }
	
	// Update is called once per frame
	void Update ()
    {
        ///inicializacion de contadores
        ///creacion del axis del personaje
        ///llamado constante del metodo de ataque
        ///condicionales que gestionan el movimiento
        timpo = timpo + Time.deltaTime;
        Temporal = Temporal + Time.deltaTime;
        otroTempo += Time.deltaTime;
         Moverla = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime*100;
        Can = Moverla;
        Atack();
        if ((Moverla > 0 || Moverla < 0) || stay == false)
        {
            // step.Play();
            //condicional relacionado con el estado de pausa en el juego
            //el cual  deshabilita la camara idle si la pausa no esta activa
            //pone el parametro bool de animator verdadero

            if (itsPause == false)
            {
            

                idelCam.SetActive(false);

                Tempo = true;
                //condicional
                if (dañino == true)
                {
                    movingCam.SetActive(true);
                }
                Frog.SetBool("run", true);
            }
        }
       
        else
        {
            
            if(suenelo == false)
            {
                step.Play();
            }
           
            movingCam.SetActive(false);
            if(dañino == true && stay == true)
            {
                idelCam.SetActive(true);
            }   
            Frog.SetBool("run", false);
            Tempo = false;
        }
        //condicional que regula el movimiento hacia la izquierda
        if (Input.GetKeyUp("left"))
        {
           Moverla = Can * 0;
        }
        //condicional que regula el movimiento hacia la derecha
        if (Input.GetKeyUp("right"))
        {
            Controle.move = Can * 0;
        }

        //condicionales para regular el salto y el movimiento en el aire junto con el parametro del animator 
        if (Input.GetButtonDown("Jump"))
        {
            suenelo = true;
          if(suenelo == true)
            {
                step.Pause();
                suenelo = false;
            }
            Slar = true;
            Frog.SetBool("jump", true);
           
            timpo = 0;
            Tempo = true;
        }
     
        if (timpo > 0.2f)
        {                       
            Frog.SetBool("jump", false);
        }
      
        Controle.Move(Moverla, Snif, Slar);

        //condicionales para gestionar el ataque y su respectiva animacion al igual sus efectos en el personaje 
        if (Input.GetKeyDown("s"))
        {
            if (Temporal > 0.8f)
            {
                Frog.SetBool("Atack1", true); Temporal = 0;
                if (Moverla > 0)
                {
                    m_Rigidbody2D.RigydForce();

                }
                if (Moverla < 0)
                {
                    m_Rigidbody2D.AddForce(new Vector2(-10000f, 0f));
                }
            }
        }

        
        if (Temporal > 0.4)
        {
            Frog.SetBool("Atack1", false);
        }
        //

        //condicional para el uso de la camara de perspectiva el cual desactiva las otras camaras y deja activa solo
        if (Input.GetKey(KeyCode.DownArrow) && Moverla == 0)
        {
            camerapersp.SetActive(true);
            idelCam.SetActive(false);
            movingCam.SetActive(false);

        }
        
        else
        {
            camerapersp.SetActive(false);
        }
        //la de perspectiva de lo contrario se desactiva

        //condicional para el uso del poder 
        //y su respectiva disercion
        if (Input.GetKeyDown("d") && habilitado)
        {
            Frog.SetBool("Ultime", true);                                           
                habilitado = false;
                    
        }
        else if((Input.GetKeyUp("d")))
        {
            Frog.SetBool("Ultime", false);
            habilitado = false;
        }
        //raycast que es utilizado para censar la ultima posicion para colocarla como punto de respawn
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        { 
        
            if(hit.collider != null)
            {

                if (hit.collider.gameObject.tag == "Respawn")
                {
                    UltimaPosicion = transform.position;
                }

            }
        }
       
    }
    //metodo que se encarga de instanciar el prefab del power up a la vez que 
    //se encarga de hacer el booleano que lo habilita falso para no ser instanciado ifinitas veces
    private void PowerCreator()
    {
        habilitado = false;
        Instantiate(power,Final.transform.position,Quaternion.identity);  
        
    }
    //collision que gestiona el comportamiento del personaje cuando se encuentra en la plataforma
    //desactiva la animacion de correr
    //y desactiva las camaras de idle y moving para no interferir la vista en la plataforma
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<plataform>())
        {
            Frog.SetBool("run", false);
            stay = false;
            movingCam.SetActive(true);
            idelCam.SetActive(false);
        }
        
    }
    //metodo que contiene el funcionamiento del ataque principal
    void Atack()
    {
        //uso de la tecla a para el uso del ataque 
        //para ello se implementa un contador para aplicar un delay y evitar el espameo del boton
        //se activa la animacion 
        //de lo contrario es decir si se deja la tecla sostenida se activa la animacion y adicionamente 
        //se activa la animacion de combo y reinia el contador
        //y activa el gameoject de la espada
        if (Input.GetKeyDown("a"))
        {
            count += 1;
            if(count <= 1)
            {
                Frog.SetBool("Atack", true);
            }
            else 
            {
                Frog.SetBool("Atack", true);
                Frog.SetBool("ComboAttack", true);
                count = 0;
            }
            
            actack.SetActive(true);
        }
        //si el boton deja de ser presionado se ponen los parametros del animator falsos y se desactiva la espada
        if(Input.GetKeyUp("a"))
        {
            Frog.SetBool("Atack", false);
            Frog.SetBool("ComboAttack", false);
            actack.SetActive(false);
        }

    }
    //colisiones de entrada y salida para desactivar los booleanos de estay 
    //que es el que censa el comportamiento en la plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Slar = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<plataform>())
        {
            stay = true;
        }
    }
    //corrutina que se encarga del cambio de color 
    IEnumerator StayWhite()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine("StayWhite");
       colorNorm.RenderMe(); 

    }
}
