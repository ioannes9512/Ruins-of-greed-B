using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    /// <summary>
    /// varibles:
    /// rigidbody referente al rigidbody propio
    /// y un game object referente al jugador  
    /// y un flotante usado para cabmbiar  la direccion del obejeto a travez de l escala
    /// </summary>
    Rigidbody2D rb;
    GameObject player;
    float scale;

    // Start is called before the first frame update
    void Start()
    {
        ///se obtiene el rogidbody propio y se busca un objeto con la tag de player
        rb =  GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        ///se sincroniza la direccion del objeto con la del jugador y se le agrega fuerza para
        ///para que maneje un dezplazamiento constante
        if (player.transform.localScale.x < 0)
        {
            scale = -1;
            transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);
        }
        else
        {
            scale = 1;
            transform.localScale = new Vector2(transform.localScale.x* -1 , transform.localScale.y);
        }
        rb.AddForce((transform.right * 1000)*scale);
    }

    //se implementa un triger para con la tag de enemigo y los componentes del enemigo
    //la cual se encarga de eliminar a los enemigos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            if (collision.gameObject.GetComponent<Bossbehavior>())
            {
                collision.gameObject.GetComponent<Bossbehavior>().HP -= 5;
            }
            if (collision.gameObject.GetComponent<Enemigo>())
            {
                collision.gameObject.GetComponent<Enemigo>().HP -= 5;
            }
            if (collision.gameObject.GetComponent<crab2>())
            {
                collision.gameObject.GetComponent<crab2>().HP -= 5;
            }           
            
            collision.gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        // para evitar errores o posibles problemas el objeto se destruye si la tag no
        // es este entre una de las tres en el caso de secreto se destruye la barrera
        if(collision.gameObject.tag == "Respawn")
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Secreto")
        {
            Tullip.Secretos = Tullip.Secretos + 1;
            collision.gameObject.SetActive(false);
        }
    }
    // cambia el color del enemigo
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        collision.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
