using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instancia única de GameManager
    public Text moneyText; // Texto para mostrar el dinero
    private int money; // Variable para almacenar el dinero del jugador

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
        money = 1000; // Inicializa el dinero del jugador
        UpdateMoneyUI();
    }

    public void AddMoney(int amount)
    {
        money += amount; // Añade dinero
        UpdateMoneyUI();
    }

    void UpdateMoneyUI()
    {
        moneyText.text = "Money: $" + money.ToString(); // Actualiza el UI del dinero
    }
}
