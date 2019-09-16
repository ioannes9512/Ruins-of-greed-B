using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{/// <summary>
/// variables asignadas en el canvas
/// </summary>
    public GameObject panel;
    public GameObject panelSound;
    public GameObject panelCtrl;
   /// <summary>
   /// metodo para cargar la escena 1
   /// </summary>
    public void Cambio()
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// activacion del panel de creditos 
    /// </summary>
    public void Credit()
    {
        panel.SetActive(true);
    }
    /// <summary>
    /// activacion del panel de sonido
    /// </summary>
    public void Sound()
    {
        panelSound.SetActive(true);
    }
    /// <summary>
    /// desactivacion de los posibles paneles activos 
    /// </summary>
    public void Back()
    {
        panel.SetActive(false);
        panelSound.SetActive(false);
        panelCtrl.SetActive(false);

    }
    /// <summary>
    /// activacion panel de controles 
    /// </summary>
    public void Controll()
    {
        panelCtrl.SetActive(true);
    }
    /// <summary>
    /// cerrar la aplicacion
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
    /// <summary>
    /// segunda forma de desactivar los posibles paneles activos
    /// </summary>
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))

        {
            panel.SetActive(false);
            panelSound.SetActive(false);
            panelCtrl.SetActive(false);
        }
       
    }

}
