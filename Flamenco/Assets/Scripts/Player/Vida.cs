using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class Vida : MonoBehaviour {
    /// <summary>
    /// Variables:
    ///  sliders uno para la barra de vida y otro para el mana que consume el ataque secundario
    ///  booleanos uno para el estado de veneno y otro para hacer testing el cual vuelve al personaje inmortal
    ///  flotante estatico para la cantidad de vida del personaje
    ///  entero para la cantidad de mana
    ///  referencia a un sprite renderer que sera el del persona al cual se le cambiara el color por medio de una corrutina
    ///  un array de transform el cual sera usado para almacenar los puntos de respawn
    ///  un entero que almacenara las posiciones de cada transform en el array
    /// </summary>
    public bool Inmortal;
    public Slider Vitalidad;
    public Slider chargePower;
    public static float healt;
    public static int mana;
    public bool poisen;
    public SpriteRenderer hero;
    public Transform[] Respawn;
    public int RespawnN;
    //Imagen del slider
    public Image vit;
    public GameObject d;
    public int EscenaRevive;
    // Use this for initialization
    public UnityEvent Actuador;

    void Start()
    {
        //condicional que genera e evento de unity
        //cantidad de vida y mana iniciales
        //se optiene el sprite renderer del personaje
        if (Actuador == null)
            Actuador = new UnityEvent();

        Actuador.AddListener(Ping);
        healt = 10;
        mana = 0;
        d.SetActive(false);
        hero.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        //los valores de los sliderss son igualados a la cantidad de vida y mana iniciales
        Vitalidad.value = healt;
        chargePower.value = mana;
        //condicion que regula la muerte del personaje 
        //en el cual se tiene en cuenta el valor de l slider es decir la cantidad de vida y el booleano de inmortalidad
        //lo cual añade le posicion al array y se detiene la corrutina y se aplica le da una cantidad de vida para poder respawnear
      if (Vitalidad.value == 0 && !Inmortal)
      {
            AnalyticsEvent.Custom("Murio", null);
            //SceneManager.LoadScene(EscenaRevive);
            transform.position =Respawn[RespawnN].position;
            StopCoroutine("poison");
            healt = 5;
      }
      // codicional que regula el estado de veneno
      if (poisen)
      {
            Actuador.Invoke();
            StartCoroutine(poison());
            poisen = false;
      }
      //condicion que habilita el uso del power up a travez del valor del slider para luego de ser reiniciado 
      //cosa que pueda ser utilizado posteriormente 
      if (mana >= 15)
      {
            Froga.habilitado = true;
            d.SetActive(true);
            if (Input.GetKeyUp("d"))
            {
                mana = 0;
                d.SetActive(false);
            }
      }
    }
    void Ping()
    {
        Debug.Log("Ping");
    }

    private void OnDisable()
    {
        Actuador.RemoveListener(Ping);
    }
    public void TPRapido(GameObject portal)
    {

    }

    //corrutina encargada del cambio color esta es usada para el estado de veneno 
    IEnumerator poison()
    {
        healt -= 0.2f;
        hero.color = Color.green;
        vit.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.2f);
        healt -= 0.2f;
        hero.color = new Color(140, 38, 211, 0.9f);
        yield return new WaitForSeconds(0.2f);
        healt -= 0.2f;
        vit.GetComponent<Image>().color = Color.green;
        hero.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        healt -= 0.2f;
        hero.color = new Color(140, 38, 211, 0.9f);
        yield return new WaitForSeconds(0.2f);
        healt -= 0.2f;
        hero.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        healt -= 0.2f;
        hero.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        healt -= 0.2f;
        vit.GetComponent<Image>().color = Color.green;
        hero.color = new Color(140, 38, 211, 0.9f);
        yield return new WaitForSeconds(0.2f);
        healt -= 0.2f;
        hero.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        healt -= 0.2f;
        hero.color = new Color(140, 38, 211, 0.9f); ;
        vit.GetComponent<Image>().color = Color.red;
        hero.color = Color.white;
        StopCoroutine(poison());
    }
}
