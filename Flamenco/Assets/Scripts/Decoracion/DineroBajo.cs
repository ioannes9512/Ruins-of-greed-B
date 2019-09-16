using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DineroBajo : MonoBehaviour {
    public Dinero Doglas;
    public AudioSource chesto;
    public UnityEvent Actuador;

    /// <summary>
    /// elementos necesarios poara activar el evento
    /// </summary>
    void Start()
    {
        if (Actuador == null)
            Actuador = new UnityEvent();

        Actuador.AddListener(Ping);
    }


    void Ping()
    {
        Debug.Log("Ping");
    }
    private void OnDisable()
    {
        Actuador.RemoveListener(Ping);
    }
    /// <summary>
    /// reproduce particulas de dinero y suma a la cantidad total de dinero del jugador
    /// y se desactiva a si mismo
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Actuador.Invoke();          
            chesto.Play();
            chesto.loop = true;
            Doglas.Money = Doglas.Money + 20;
            Tullip.Cofres = Tullip.Cofres + 1;
            gameObject.SetActive(false);
        }
    }

}
