using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dinero : MonoBehaviour
{
/// <summary>
/// variables a asignar en canvas y utilizar en varios scrpits
/// </summary>
    public TextMeshProUGUI Cash;
    public int Money;
    
    /// <summary>
    /// actuliza enb tiempo real el valor del int Money
    /// </summary>
	void Update ()
    {
        Cash.text = Money.ToString();
      
	}
}
