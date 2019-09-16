using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class analitycs : MonoBehaviour
{
    public bool repetir;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (repetir)
            {
                Invoke("activa", 0.2f);
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    private void activa()
    {
        this.gameObject.SetActive(true);
    }
}
