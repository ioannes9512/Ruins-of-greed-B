using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Gemas : MonoBehaviour
{
    public Dinero dinero;
    int duracion = 3;
   /// <summary>
   /// le otorga una duracion al objeto y agrega dinero al jugador una vez termina la duracion
   /// </summary>
   /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent <Sword>())
        {
            AnalyticsEvent.Custom("Tumulos", null);
            duracion -= 1;

            if(duracion == 0)
            {
                gameObject.SetActive(false);
                dinero.Money =  dinero.Money+Random.Range(20, 40);
            }
            

        }
    }
}
