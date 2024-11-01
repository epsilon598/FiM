using UnityEngine;
using UnityEngine.UI;

public class MenuComprarController : MonoBehaviour
{
    public GameObject menuComprar; // Asigna el objeto MenuComprar en el Inspector
    public GameObject placa;
    public GameObject edificio;
    public Button aceptarButton;   // Asigna el botón Aceptar desde el Inspector
    public Button cancelarButton;  // Asigna el botón Cancelar desde el Inspector
    public GameManager gameManager;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        aceptarButton.onClick.AddListener(OnAceptarClick);
        cancelarButton.onClick.AddListener(OnCancelarClick);
    }

    private void OnAceptarClick()
    {
        Debug.Log("Botón Aceptar presionado.");

        if (gameManager.budget >= 2000)
        {
            gameManager.SubtractMoney(2000);
            Debug.Log("2000 monedas restadas.");

            // Intenta ocultar el menú y confirma en la consola
            menuComprar.SetActive(false);
            placa.SetActive(false);
            edificio.SetActive(true);
            Debug.Log("MenuComprar ocultado.");
        }
        else
        {
            Debug.Log("No tienes suficiente presupuesto.");
        }
    }

    private void OnCancelarClick()
    {
        Debug.Log("Botón Cancelar presionado.");
        
        // Oculta el menú sin hacer cambios
        menuComprar.SetActive(false);
        Debug.Log("MenuComprar ocultado por el botón Cancelar.");
    }
}
