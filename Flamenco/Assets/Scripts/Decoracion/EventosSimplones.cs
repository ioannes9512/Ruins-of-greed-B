using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventosSimplones : MonoBehaviour
{
    public UnityEvent Actuador;
    /// <summary>
    /// regula los eventos 
    /// </summary>
    void Start()
    {
        if (Actuador == null)
            Actuador = new UnityEvent();

        Actuador.AddListener(Ping);
    }

    void Update()
    {
        if (Input.anyKeyDown && Actuador != null)
        {
            Actuador.Invoke();
        }
    }

    void Ping()
    {
        Debug.Log("Ping");
    }
    private void OnDisable()
    {
        Actuador.RemoveListener(Ping);
    }
    public void TPRapido(GameObject portal)
    {

    }
}
   
