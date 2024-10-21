using UnityEngine;

public class Customer : MonoBehaviour
{
    public int spendingAmount = 50; // Cantidad que el cliente gasta

    void Start()
    {
        // Simula un tiempo aleatorio para realizar la compra
        Invoke("MakePurchase", Random.Range(2f, 5f));
    }

    void MakePurchase()
    {
        // Asegúrate de que GameManager.instance no sea null
        if (GameManager.instance != null)
        {
            GameManager.instance.AddMoney(spendingAmount); // Agrega el dinero al GameManager
            Destroy(gameObject); // Elimina al cliente después de la compra
        }
        else
        {
            Debug.LogWarning("GameManager instance is null! Please ensure it is set up correctly.");
        }
    }
}
