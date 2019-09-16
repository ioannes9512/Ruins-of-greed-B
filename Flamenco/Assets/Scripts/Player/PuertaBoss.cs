using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaBoss : MonoBehaviour {
    //referencia referencuida con el script de la llave
    public LlaveBoss Key;
	
    //ontrigger que verifica el stado del booleano
    //si el estado de este es verdadero ejecuta la corrutinaa encargada de la puerta
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Key.Key)
        {
            StartCoroutine(Subida());
        }
    }

    //corrutina que se encarga de levantar la puerta
    IEnumerator Subida()
    {
        transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
    }
}
