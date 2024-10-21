using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    public int resourceAmount = 10; // Cantidad de recursos generados
    public float generationRate = 5f; // Genera recursos cada 5 segundos
    private float timer;

    void Update()
    {
        // Actualiza el temporizador
        timer += Time.deltaTime;

        // Si el temporizador supera la tasa de generación, genera recursos
        if (timer >= generationRate)
        {
            GenerateResources();
            timer = 0f; // Reinicia el temporizador
        }
    }

    void GenerateResources()
    {
        // Asegúrate de que GameManager.instance no sea null
        if (GameManager.instance != null)
        {
            GameManager.instance.AddMoney(resourceAmount); // Agrega recursos al GameManager
        }
        else
        {
            Debug.LogWarning("GameManager instance is null! Please ensure it is set up correctly.");
        }
    }
}
