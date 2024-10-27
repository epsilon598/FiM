using UnityEngine;

public class PlacaClick : MonoBehaviour
{
    public MenuComprarController menuComprarController; // Referencia al controlador del menú

    void OnMouseDown()
    {
        if (menuComprarController != null)
        {
            menuComprarController.MostrarMenu(); // Mostrar el menú de compra
        }
        else
        {
            Debug.LogError("MenuComprarController no está asignado en el Inspector.");
        }
    }
}
