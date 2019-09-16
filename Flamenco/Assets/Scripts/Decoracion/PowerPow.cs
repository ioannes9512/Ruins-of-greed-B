using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPow : MonoBehaviour
{
    public int size;
    public GameObject pref;
    public GameObject storage;
    public GameObject[] Power;

    /// <summary>
    /// crea una cantidad designada de un objeto y lo hace hijo del storage 
    /// </summary>
    void Start()
    {
        Power = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            GameObject dr = Instantiate(pref, storage.transform.position, Quaternion.identity);
            Power[i] = dr;
            dr.transform.SetParent(storage.transform);
        }

    }
    /// <summary>
    /// toma al objeto antes instaciado y lo mueve a una nueva posicion con nueva rotacion y es activado nuevamente 
    /// </summary>
    /// <param name="gunPos"></param>
    /// <param name="gunRot"></param>

    public void Spawn(Vector3 gunPos, Quaternion gunRot)
    {

        Power[0].transform.position = gunPos;
        Power[0].transform.rotation = gunRot;
        
        Power[size - 1] = Power[0];

        for (int i = 0; i < size - 1; i++)
        {

            Power[i] = Power[i + 1];

        }
        Power[0].SetActive(true);
    }
}
