using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instancia única de GameManager
    public Text moneyText; // Texto para mostrar el dinero
    public Text studentCountText; // Texto para mostrar la cantidad de estudiantes
    public int budget = 5000; // Presupuesto inicial del colegio
    public int studentCount = 0; // Número de estudiantes matriculados

    void Awake()
    {
        // Asegúrate de que solo haya una instancia de GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject); // Destruir instancias duplicadas
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        budget += amount; // Agrega dinero al presupuesto
        UpdateUI();
    }

    public void InvestInInfrastructure(int amount)
    {
        if (budget >= amount)
        {
            budget -= amount;
            studentCount += 5; // Incrementar estudiantes por cada inversión
            Debug.Log("Inversión realizada. Estudiantes matriculados: " + studentCount);
            UpdateUI();
        }
        else
        {
            Debug.LogWarning("No hay suficiente presupuesto para esta inversión.");
        }
    }

    void UpdateUI()
    {
    // Verifica que `moneyText` no es nulo antes de intentar acceder a él
    if (moneyText != null)
    {
        moneyText.text = budget.ToString();
    }
    else
    {
        Debug.LogError("El campo moneyText no está asignado en el Inspector.");
    }

    // Verifica que `studentCountText` no es nulo antes de intentar acceder a él
    if (studentCountText != null)
    {
        studentCountText.text = "Estudiantes: " + studentCount.ToString();
    }
    else
    {
        Debug.LogError("El campo studentCountText no está asignado en el Inspector.");
    }
    }
    public void SubtractMoney(int amount)
    {
    if (budget >= amount)
    {
        budget -= amount;
        UpdateUI();
        Debug.Log("Se restaron " + amount + " del presupuesto.");
    }
    else
    {
        Debug.LogWarning("No hay suficiente presupuesto para realizar esta acción.");
    }
}
}