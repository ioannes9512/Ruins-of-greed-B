using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class forja : MonoBehaviour
{/// <summary>
/// declaracion de variables para asignar en el canvas
/// </summary>
    public GameObject interfaz;
    public Dinero dinero;
    public GameObject accion;
    public  TextMeshProUGUI changeColorRepare;
    public  TextMeshProUGUI changeColorUpgrade;      
    
  /// <summary>
  /// activacion del objeto que muestra la accion a seguir
  /// </summary>
  /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          
           accion.SetActive(true);      
          
        }
        
    }
    /// <summary>
    /// despligue del canvas con informacion interactiva y acciones que se pueden realizar
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                interfaz.SetActive(true);
            }

            if (dinero.Money >= 38)
            {
                changeColorRepare.color = Color.white;
               
            }
            if (dinero.Money < 38)
            {
                changeColorRepare.color = Color.red;
            }
            if(dinero.Money >= 98)
            {
                changeColorUpgrade.color = Color.white;
            }
            if(dinero.Money < 98)
            {
                changeColorUpgrade.color = Color.red;
            }
        }

    }
    /// <summary>
    /// verificacion para desactivar el canvas
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interfaz.SetActive(false);
        }
    }
    /// <summary>
    /// accion de recuperar vida y cobro por el servicio 
    /// </summary>
    public void Reapre()
    {
       if(dinero.Money >= 38)
       {
            Debug.Log("reparar");
            Vida.healt += 4;
            if (Vida.healt > 10)
            {
                Vida.healt = 10;
            }
            
            dinero.Money -= 38;

       }
       
    }
    /// <summary>
    /// accion de aumentar daño y cobro por el servicio
    /// </summary>
    public void Upgrade()
    {
        if (dinero.Money >= 95)
        {         
            Sword.daño = 3;           
            dinero.Money -= 95;
        }      
    }
}
