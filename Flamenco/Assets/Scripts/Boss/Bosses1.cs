using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bosses1 : MonoBehaviour
{  
    public Animator animator; // toma el animator para las animaciones del mismo objeto
    public float Salto;//la fuerza para el salto
    public GameObject roca; // se toma para realizar un ataque
    public GameObject[] lanzaRocas = new GameObject[10]; // posiciones para la invocaion de las rocas
    public UnityEvent suelo;// evento para realizar cuando caiga al suelo
    public UnityEvent Jump;//   evento para realizar cuando salga al suelo
    public float xIni;// flotante para poner medidas del inicio del la patrulla
    public float xFin;// flotante para poner medidas del final de la patrulla
    public float speed;// se pone publico para hacer  una lectura de la velocidad para ver si el objeto si puedo  avistar al personaje
    private float Visto;// la referencias si esta viendo el objeto  y medir su distancia a
    private Rigidbody2D body; // rigidbody para el objeto
    float vX;// tomar el objeto para darle una rotacion correcta 
    private int direction = 1; // marca la direcion es para determinar el giro del personaje
    GameObject Player;// player para poder tomar medidas y tener actudador segun este el personaje
    float tiempo;// medidor de tiempo segun va cada accion
    int DescansoObligado;// para obligar el freno de acciones
   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        vX = transform.localScale.x;
        body = GetComponent<Rigidbody2D>();
        //ejector de las acciones al inicio del objeto
        int Suerte = Random.Range(0, 3);
        if (Suerte == 0)
        {
            animator.SetTrigger("salto");
            //StartCoroutine(Embestida());
            StopCoroutine(Caminata());
            Embestidas();
            Invoke("Embestidas", 3);
            Invoke("Embestidas", 9);
            Invoke("Embestidas", 15);
            Debug.Log("Embestida");
            DescansoObligado += 1;
        }
        else if (Suerte == 1)
        {
            animator.SetTrigger("ataque");
            //StopCoroutine(Embestida());
            StartCoroutine(Caminata());
            DescansoObligado += 1;
            Debug.Log("Caminata");
        }
        else if (Suerte == 2)
        {
            animator.SetTrigger("embiste");
            int lanzamientos = Random.Range(1, 4);
            Invoke("lanRocas", 0.01f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // activardor para iniciar el combate y su mismo controlador para las acciones
        if (FinalFight.iniciaFinal == true)
        {
            tiempo += Time.deltaTime;
            // velocidad segun si lo ve o no al player
            if (Visto < 10)
            {
                speed = 24;
            }
            else
            {
                speed = 10;
            }
            if (tiempo > 10)
            {
                int Suerte = Random.Range(0, 4);
                if (Suerte == 0 && DescansoObligado < 3)
                {
                    tiempo = 0;
                    animator.SetTrigger("salto");
                    StopCoroutine(Caminata());
                    //StartCoroutine(Embestida());
                    Embestidas();
                    Invoke("Embestidas", 3);
                    Invoke("Embestidas", 6);
                    Invoke("Embestidas", 9);
                    Debug.Log("Embestida");
                    DescansoObligado += 1;
                }
                if (Suerte == 1 && DescansoObligado < 3)
                {
                    tiempo = 0;
                    StartCoroutine(Caminata());
                    animator.SetTrigger("ataque");
                    //StopCoroutine(Embestida());
                    DescansoObligado += 1;
                    Debug.Log("Caminata");
                }
                if (Suerte == 2 && DescansoObligado < 3)
                {
                    tiempo = 0;
                    body.velocity = Vector2.zero;
                    animator.SetTrigger("embiste");
                    StopCoroutine(Caminata());
                    //StopCoroutine(Embestida());
                    int lanzamientos = Random.Range(1, 4);
                    Invoke("lanRocas", 0.01f);
                    Debug.Log("Rocas");
                    DescansoObligado += 1;
                }
                if (Suerte == 4 || DescansoObligado >= 3)
                {
                    tiempo = 0;
                    body.velocity = Vector2.zero;
                    animator.SetTrigger("idel");
                    StopCoroutine(Caminata());
                    //StopCoroutine(Embestida());
                    Debug.Log("Descanso");
                    DescansoObligado = 0;
                }
                tiempo = 0;

            }
            Invoke("Caida", 0.01f);
        }
    }
    IEnumerator Caminata()
    {
        // tiene el mismo codigo que tiene la patrulla pero tiene su  propia pausa para continuar las acciones
        while (true)
        {

            if (transform.position.x > xFin)
            {
                direction = -1;

            }
            else if (transform.position.x < xIni)
            {
                direction = 1;
            }

            if (direction == 1 && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            if (direction == -1 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            body.velocity = (transform.right * direction) * speed;
            Vector3 vectorOther = Player.transform.position - transform.position;
            Visto = (Vector3.Dot(-transform.right * direction, vectorOther));
            if (tiempo > 9)
                StopCoroutine(Caminata());
            yield return new WaitForEndOfFrame();
        }
    }
    void lanRocas()
    { 
        //este espara la accion de rocas para instanciar una tanda de rocas en posiciones aleatorias
            int estalanita = Random.Range(0, lanzaRocas.Length);
            Instantiate(roca, lanzaRocas[estalanita].transform.position, Quaternion.identity);
            estalanita = Random.Range(0, lanzaRocas.Length);
            Instantiate(roca, lanzaRocas[estalanita].transform.position, Quaternion.identity);
            estalanita = Random.Range(0, lanzaRocas.Length);
            Instantiate(roca, lanzaRocas[estalanita].transform.position, Quaternion.identity);
            estalanita = Random.Range(0, lanzaRocas.Length);
            Instantiate(roca, lanzaRocas[estalanita].transform.position, Quaternion.identity);
            estalanita = Random.Range(0, lanzaRocas.Length);
            Instantiate(roca, lanzaRocas[estalanita].transform.position, Quaternion.identity);
            estalanita = Random.Range(0, lanzaRocas.Length);
            Instantiate(roca, lanzaRocas[estalanita].transform.position, Quaternion.identity);
            estalanita = Random.Range(0, lanzaRocas.Length);
            Instantiate(roca, lanzaRocas[estalanita].transform.position, Quaternion.identity);
            estalanita = Random.Range(0, lanzaRocas.Length);
            Instantiate(roca, lanzaRocas[estalanita].transform.position, Quaternion.identity);
            estalanita = Random.Range(0, lanzaRocas.Length);
            Instantiate(roca, lanzaRocas[estalanita].transform.position, Quaternion.identity);
    }
    void Embestidas()
    {
        // se toma el principio de la direccion para hacer un salto segun la direccion que este el objeto  y hacer un salto 
        if (transform.position.x > xFin)
        {
            direction = -1;

        }
        else if (transform.position.x < xIni)
        {
            direction = 1;
        }

        if (direction == 1 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        if (direction == -1 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        //body.velocity = new Vector2((-body.velocity.x * Salto) * direction, Salto);
        body.AddForce((Vector2.up * Salto));//*(Vector2.right * direction) * Salto);
        Debug.Log("E");
    }
    void Caida()
    {
        // para dar una direccion 
        body.AddForce((Vector2.down * 100));
        animator.SetTrigger("ataque");
    }
    public int getDirection()
    {
        // si se quiere agregar un ataque de disparo a distancia desde el mismo objeto
        return direction;
    }
}
