using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardos : MonoBehaviour
{
    //variable de referencia al srcript del pool el cual contiene la 
    //la cantidad de prefabs instanciados
    public Pool pool;
   
    //llamadp de corrutina 
    void Start()
    {
        StartCoroutine("MyCorrutine");

    }
  
    //corrutina encargada de llamar al metodo trama el cual instancia el prefavb desde
    //la posicion y la rotacion de este objeto este es llamado cada cierto tiempo entre
    //la tasa de repeticion
    IEnumerator MyCorrutine()
    {
        
        yield return new WaitForSeconds(3);
        InvokeRepeating("trampa", 2f, 1500f);
        StartCoroutine("MyCorrutine");
    }

    //metodo que instancia el prefab
    void trampa()
    {
        pool.Spawn(this.gameObject.transform.position, this.gameObject.transform.rotation);
    } 


}
