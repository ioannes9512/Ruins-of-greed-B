using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Pausa : MonoBehaviour
{/// <summary>
/// variables a asignar en el canvas
/// </summary>
    public bool gamepause = true;
    public GameObject panelito;
    public GameObject panelDeSonido;

    /// <summary>
    /// determina que key se utiliza para activar el panel de pausa y detener el tiempo en el juego
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gamepause = false;
            if (gamepause == false)
            {
                panelito.SetActive(true);
                Time.timeScale = 0;
                Froga.itsPause = true;
            }
           
        }
    }
    /// <summary>
    /// cierra el menu de pausa y restablece el tiempo en el jugo
    /// </summary>
    public void Reanudar()
    {
        panelito.SetActive(false);
        Cursor.visible = false;
        gamepause = true;
        Time.timeScale = 1;
        Froga.itsPause = false;
    }
    /// <summary>
    /// activa el panel que contiene las configuraciones del sonido del juego
    /// </summary>
    public void Sounds()
    {
        panelDeSonido.SetActive(true);

    }
    /// <summary>
    /// activa el panel que contiene las configuraciones del sonido del juego
    /// </summary>
    public void Back()
    {
        panelDeSonido.SetActive(false);

    }
    /// <summary>
    /// desactiva el panel que contiene las configuraciones del sonido del juego
    /// </summary>
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }    
    /// <summary>
    /// activa el panel del inventario
    /// </summary>
    public void Storage(GameObject stas)
    {
        stas.SetActive(true);
    }
    /// <summary>
    /// desactiva el panel del inventario
    /// </summary>
    public void OutofStorage(GameObject stas)
    {
        stas.SetActive(false);
    }
    /// <summary>
    /// cierra la aplicación
    /// </summary>
    public void Quitss()
    {
        Application.Quit();
    }
}
