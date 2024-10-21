using UnityEngine;

public class StudentSpawner : MonoBehaviour
{
    public GameObject studentPrefab; // Prefab del estudiante
    public float spawnInterval = 3f; // Intervalo entre la generación de estudiantes

    void Start()
    {
        InvokeRepeating("SpawnStudent", 0f, spawnInterval); // Genera estudiantes a intervalos regulares
    }

    void SpawnStudent()
    {
        Instantiate(studentPrefab, transform.position, Quaternion.identity); // Genera un nuevo estudiante en la posición del spawner
    }
}
