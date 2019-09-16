using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plancas : MonoBehaviour
{
    public GameObject Puerta;
    public Sprite flip;
    bool Cambio;
    public AudioSource soundefectt;
  
    /// <summary>
    /// abre una puerta en especifico 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.A) && collision.gameObject.tag == "Player")
        {
            if(Cambio == false)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = flip;
                StartCoroutine(Subida());
                Cambio = true;
                soundefectt.Play();
            }
        }
    }
    IEnumerator Subida()
    {
        Puerta.transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        Puerta.transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        Puerta.transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        Puerta.transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        Puerta.transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        Puerta.transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        Puerta.transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        Puerta.transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
        Puerta.transform.Translate(0, 0.7f, 0f);
        yield return new WaitForSeconds(0.2f);
    }
}
