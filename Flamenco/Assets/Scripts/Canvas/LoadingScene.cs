using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScene : MonoBehaviour
{/// <summary>
/// array de posibles mensajes
/// </summary>
    string[] TIPS = { "Lo unico qué sobrevivió a la ruina fueron los molestos cangrejos", "Las cuevas antes estaban haibitadas por los enanos ahora solo son un yermo desolado y lleno de ruinas",
        "En un intento desesperado por escapar la mayoria de los habitantes escondieron sus tesoros en salas secretas" };
    /// <summary>
    /// variables para asignar elementos del Canvas
    /// </summary>
    public GameObject loadingPanel;
    public Slider slider;
    public TextMeshProUGUI progressTx;
    public TextMeshProUGUI Tips;
    /// <summary>
    /// elige uno de los string del array y lo muestra el canvas
    /// empieza la coroutine y le asigna el int nivel que se a definido en el inspector
    /// </summary>
    /// <param name="nivel"></param>
    public void startChange(int nivel)
    {
        Tips.text = TIPS[Random.Range(0, 3)];
        StartCoroutine(LoadAsinc(nivel));
    }
    /// <summary>
    /// activa el panel de la pantalla de carga y determina el tiempo que demora en cargar la siguiente escena 
    /// muestra el tiempo de progreso en forma del slider
    /// </summary>
    /// <param name="sIndex"></param>
    /// <returns></returns>
    IEnumerator LoadAsinc(int sIndex)
    {
        loadingPanel.SetActive(true);
        yield return new WaitForSeconds(2);

        AsyncOperation asyncOP = SceneManager.LoadSceneAsync(sIndex);

        while (!asyncOP.isDone)
        {
            float progress = Mathf.Clamp01(asyncOP.progress / 0.9f);
            slider.value = progress;
            progressTx.text = progress * 100f + "%";

            yield return null;
        }
       
        

    }

}



