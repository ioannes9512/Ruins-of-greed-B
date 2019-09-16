using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasDeMadera : MonoBehaviour
{
  /// <summary>
  /// verifica si el objeto dentro del collaider es el jugador y si esta presionando la tecla A
  /// para ejecutar la coroutina
  /// </summary>
  /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.A) && collision.gameObject.tag == "Player")
        {
            StartCoroutine(Subida());
        }
    }
    /// <summary>
    /// sube el objetocada cierto tiempo
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
    }
}
