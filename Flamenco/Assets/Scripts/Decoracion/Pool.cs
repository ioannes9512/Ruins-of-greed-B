using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public int size;
    public GameObject pref;
    public GameObject storage;
    public GameObject[] dardo;
 
    /// <summary>
    /// crea una cantidad designada de un objeto y lo hace hijo del storage 
    /// </summary>
    void Start()
    {
        dardo = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
           GameObject dr = Instantiate(pref, storage.transform.position, Quaternion.identity);
            dardo[i] = dr;
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

        dardo[0].transform.position = gunPos;
        dardo[0].transform.rotation = gunRot;
        dardo[0].SetActive(true);
        dardo[size-1] = dardo[0];
        
        for (int i = 0; i < size-1; i++)
        {

            dardo[i].GetComponent<TrailRenderer>().enabled = true;
           dardo[i] = dardo[i + 1];
            
        }
        
    }
}
