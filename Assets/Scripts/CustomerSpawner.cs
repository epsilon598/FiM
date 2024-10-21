using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab; // Prefab del cliente
    public float spawnInterval = 3f; // Intervalo entre la generación de clientes

    void Start()
    {
        InvokeRepeating("SpawnCustomer", 0f, spawnInterval); // Genera clientes a intervalos regulares
    }

    void SpawnCustomer()
    {
        Instantiate(customerPrefab, transform.position, Quaternion.identity); // Genera un nuevo cliente en la posición del spawner
    }
}
