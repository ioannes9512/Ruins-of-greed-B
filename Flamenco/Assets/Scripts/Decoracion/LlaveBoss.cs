using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveBoss : MonoBehaviour {
    public bool Key;
    public GameObject Forma;

    /// <summary>
    /// permite el acseso a la habitacion del jefe
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Key = true;
            Forma.SetActive(true);
            StartCoroutine(Subida());
        }
    }
    /// <summary>
    /// abre la puerta
    /// </summary>
    /// <returns></returns>
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
        gameObject.SetActive(false);
    }
}
