using UnityEngine;

public class MenuComprarController : MonoBehaviour
{
    private GameManager gameManager; // Referencia al GameManager

    void Start()
    {
        // Encuentra el GameManager en la escena
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager no encontrado en la escena.");
        }

        // Asegurarse de que el menú esté desactivado al iniciar
        gameObject.SetActive(false);
    }

    public void MostrarMenu()
    {
        gameObject.SetActive(true); // Mostrar el menú
    }

    public void OcultarMenu()
    {
        gameObject.SetActive(false); // Ocultar el menú
    }

    public void AceptarCompra()
    {
        if (gameManager != null && gameManager.budget >= 2000)
        {
            gameManager.SubtractMoney(2000);
            Debug.Log("Compra realizada. Presupuesto restante: " + gameManager.budget);
        }
        else
        {
            Debug.Log("No tienes suficiente presupuesto.");
        }
        OcultarMenu(); // Ocultar el menú después de la compra
    }

    public void CancelarCompra()
    {
        OcultarMenu(); // Ocultar el menú sin hacer cambios
    }
}
