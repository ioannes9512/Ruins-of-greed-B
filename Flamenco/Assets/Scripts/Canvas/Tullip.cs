using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tullip : MonoBehaviour
{
    /// <summary>
    /// vriables:
    /// 3 enteros estaticos uno para la cantidad de cofres y los otros 2 para la cantidad de enemigos eleminados y la cantidad de secretos descubiertos
    /// de igual manera 3 enteros para la catidad total de enemigos,cofres,secretos
    /// gameobject para el panel del menu
    /// variables tipo textmeshpro para la interfaz  
    /// un slider para el porcentaje 
    /// </summary>
    public static int Cofres;
    public static int Enemigos;
    public static int Secretos;
    public GameObject panel;
    int CofresTotal;
    int EnemigosTotal;
    int SecretosTotal;
    public TextMeshProUGUI Enem;
    public TextMeshProUGUI Ches;
    public TextMeshProUGUI Secre;
    public TextMeshProUGUI Porcentaje;
    public TextMeshProUGUI Clasificacion;
    public Slider porcenaje;
    float Fsecretos, Fenemigos, Fcofres, Fsecretostotal, Fenemigostotal, FCofretotal;
  /// <summary>
  /// asigna los valores a cada una de las variables
  /// </summary>
    void Start()
    {
        Cofres = 0;
        Enemigos = 0;
        Secretos = 0;
        SecretosTotal = GameObject.FindGameObjectsWithTag("Secreto").Length;
        EnemigosTotal = GameObject.FindGameObjectsWithTag("Enemy").Length;
        CofresTotal = GameObject.FindGameObjectsWithTag("Cofres").Length;
        Fsecretostotal = (float)SecretosTotal;
        Fenemigostotal = (float)EnemigosTotal;
        FCofretotal = (float)CofresTotal;
        
    }
    /// <summary>
    /// le otorga los nuevos valores a las variables despues de haber completado el nivel y se le otorga una calificacion de acuerdo al desempeño
    /// </summary>
    void Puntuacion()
    {
        Fsecretos = (float)Secretos;
        Fenemigos = (float)Enemigos;
        Fcofres = (float)Cofres;
        panel.SetActive(true);
        float porcentajeCofres = 30f*(Fcofres/ FCofretotal);
        Debug.Log(porcentajeCofres);
        float porcentajeEnemigos = 20f *(Fenemigos / Fenemigostotal) ;
        Debug.Log(porcentajeEnemigos);
        float porcentajeSecretos = 50f*(Fsecretos / Fsecretostotal);
        Debug.Log(porcentajeSecretos);
        float totalPorcentaje = (porcentajeCofres + porcentajeEnemigos + porcentajeSecretos);
        Debug.Log(totalPorcentaje);
        porcenaje.value = totalPorcentaje;
        Enem.text = Enemigos + "/" + EnemigosTotal;
        Ches.text =  Cofres + "/" + CofresTotal;
        Secre.text = "Secretos Descubiertos : " + Secretos + "/" + SecretosTotal;
        Porcentaje.text = totalPorcentaje.ToString("F0") + "%";
        if (totalPorcentaje >= 0 && totalPorcentaje < 20)
        {
            Clasificacion.color = Color.HSVToRGB(97f, 57f, 0f);
            Clasificacion.text = "D";
        }
        if (totalPorcentaje >= 20 && totalPorcentaje < 40)
        {
            Clasificacion.color = Color.HSVToRGB(187f, 90f, 0f);
            Clasificacion.text = "C";
        }
        if (totalPorcentaje >= 40 && totalPorcentaje < 60)
        {
            Clasificacion.color = Color.HSVToRGB(198f, 246f, 216f);
            Clasificacion.text = "B";
        }
        if (totalPorcentaje >= 60 && totalPorcentaje < 80)
        {
            Clasificacion.color = Color.HSVToRGB(246, 197, 78);
            Clasificacion.text = "A";
        }
        if (totalPorcentaje >= 80 && totalPorcentaje < 90)
        {
            Clasificacion.color = Color.HSVToRGB(225, 204, 78);
            Clasificacion.text = "A+";
        }
        if (totalPorcentaje >= 90 && totalPorcentaje < 95)
        {
            Clasificacion.color = Color.HSVToRGB(184, 183, 245);
            Clasificacion.text = "S";
        }
        if (totalPorcentaje >=95 && totalPorcentaje < 97)
        {
            Clasificacion.color = Color.HSVToRGB(179, 187, 255);
            Clasificacion.text = "SS";
        }
        if (totalPorcentaje >= 97 && totalPorcentaje < 100)
        {
            Clasificacion.color = Color.HSVToRGB(111, 135, 255);
            Clasificacion.text = "SSS";
        }

    }
    /// <summary>
    /// activa el panel con la infomacion en el canvas
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        Puntuacion();
    }
}
