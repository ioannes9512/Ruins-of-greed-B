using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour
{
    /// <summary>
    /// variables a asignar en el canvas
   /// </summary>
    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected;

    /// <summary>
    /// se le asigna las teclas con las cuales se puede navegar en el canvas y hace verificación de él elemento en el que esta 
    /// </summary>
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
    }
    /// <summary>
    /// verifica si el elemento ha sido deselecionado
    /// </summary>
    private void OnDisable()
    {
        buttonSelected = false;
    }
}