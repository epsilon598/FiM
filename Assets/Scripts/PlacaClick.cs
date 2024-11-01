using UnityEngine;

public class PlacaClick : MonoBehaviour
{
    public GameObject menuComprar; // Asigna el objeto MenuComprar desde el Inspector
    public GameManager gameManager;

    private void Start()
    {
        // Busca el objeto GameManager en la escena
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Asegura que el menú esté inicialmente oculto
        menuComprar.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Muestra el menú
        menuComprar.SetActive(true);
        
        // Resta 2000 al presupuesto si es suficiente
    }
}
