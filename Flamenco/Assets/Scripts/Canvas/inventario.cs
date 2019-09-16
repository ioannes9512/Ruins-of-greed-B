using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventario : MonoBehaviour
{
   /// <summary>
   /// activa el panel con la informacion de los elemntos del inventario
   /// </summary>
   /// <param name="stats"></param>
    public void Sword(GameObject stats)
    {
        stats.SetActive(true);
    }
    /// <summary>
    /// desactiva el panel con la informacion de los elemntos del inventario
    /// </summary>
    /// <param name="stats"></param>
    public void Empty(GameObject stats)
    {
        stats.SetActive(false);
    }

}
