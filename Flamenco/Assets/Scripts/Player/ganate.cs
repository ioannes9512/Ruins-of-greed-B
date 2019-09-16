using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class ganate : MonoBehaviour {
    //este escript solo es un trigger permite desencadenar 
    //el paso hacia el siguiente nivel a travez de un trigger enter
    public UnityEvent actuador;
    
	// Use this for initialization
	void Start () {
		if(actuador == null)
        {
            actuador = new UnityEvent();
        }
        actuador.AddListener(censar);
	}
	
	

    private void OnTriggerEnter2D(Collider2D juegalo)
    {
        if(juegalo.gameObject.tag == "Player")
        {
            //juegalo.GetComponent<Froga>().Ganate.Play();
            actuador.Invoke();
            
            Debug.Log("ganar");
        }
    }
    private void censar()
    {
        Debug.Log("ok");
    }
    void desactivar()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        actuador.RemoveListener(censar);
    }
}
