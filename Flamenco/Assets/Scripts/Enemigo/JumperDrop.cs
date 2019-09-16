using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperDrop : MonoBehaviour
{
    /// <summary>
    /// variables:
    /// transform referenta al jugador
    /// vectores3 para verificar distancias
    /// gameobject para el prefab de la piedra
    /// booleano para operar entre la corrutina y el codicional el cual 
    /// 
    /// </summary>
    public Transform Player;
    Vector3 vectorOther;
    Vector3 vectorForward;
    public GameObject rock;
    bool espera = true;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //censa la distancia y verifica el estado del booleano para iniciar o parar la corrutina
        if(Vector3.Dot(vectorForward, vectorOther) <= 10 && Vector3.Dot(vectorForward, vectorOther) >=  -10)
        {
            
            if (espera)
            StartCoroutine(Drop());
        }
        else
        {
            
            StopCoroutine(Drop());
        }
    }
   
    //corrutina encargada de instanciar el prfab cada 5 segundos y cambiar el estado del
    //booleano para luego este ser censado en el condicional 
    IEnumerator Drop()
    {
        GameObject temp;
        temp = Instantiate(rock,new Vector2( gameObject.transform.position.x, gameObject.transform.position.y-3f), Quaternion.identity);
        temp.SetActive(true);
        espera = false;
        yield return new WaitForSeconds(5);
        espera = true;

    }
   


}
