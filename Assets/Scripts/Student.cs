using UnityEngine;

public class Student : MonoBehaviour
{
    public int tuitionAmount = 200; // Cantidad que el estudiante paga por matrícula

    void Start()
    {
        // Simula un tiempo aleatorio para realizar el pago de la matrícula
        Invoke("MakePayment", Random.Range(2f, 5f));
    }

    void MakePayment()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.AddMoney(tuitionAmount); // Agrega la matrícula al presupuesto
            Destroy(gameObject); // Elimina al estudiante después del pago
        }
        else
        {
            Debug.LogWarning("GameManager instance is null! Please ensure it is set up correctly.");
        }
    }
}
