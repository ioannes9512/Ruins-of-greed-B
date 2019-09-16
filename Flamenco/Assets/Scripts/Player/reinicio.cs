using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reinicio : MonoBehaviour {
    //referencia al script del personaje
    public Froga froga;
	
	
    //colision  con la cual se devuelve al jugador a la ultima posicion 
    private void OnCollisionEnter2D(Collision2D muerte)
    {
        if (muerte.gameObject.tag == "Player")
        {
            
            muerte.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Vida.healt -= 2;
            froga.idelCam.SetActive(false);
            froga.movingCam.SetActive(false);
            froga.damageCam.SetActive(true);
           if( muerte.gameObject.GetComponent<Rigidbody2D>()){
                muerte.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            muerte.collider.transform.position = new Vector3(froga.UltimaPosicion.x, froga.UltimaPosicion.y, 0);

        }
    }
    //trigger que se encarga de desactivar todas las camaras salvo la de daño
    private void OnCollisionStay2D(Collision2D muerte)
    {
        if (muerte.gameObject.tag == "Player")
        {
            
            froga.dañino = false;
            froga.idelCam.SetActive(false);
            froga.movingCam.SetActive(false);
            froga.damageCam.SetActive(true);

        }
    }

    //una vez que el personaje muere este regresa a su estado normal
    private void OnCollisionExit2D(Collision2D muerte)
    {
        if (muerte.gameObject.tag == "Player")
        {
            
            muerte.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            froga.idelCam.SetActive(true);
            froga.movingCam.SetActive(false);
            froga.damageCam.SetActive(false);
            froga.dañino = true;
        }
    }
}
