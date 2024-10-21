using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button investButton; // Botón para invertir en infraestructura
    public int investmentAmount = 1000; // Cantidad a invertir

    void Start()
    {
        investButton.onClick.AddListener(() => InvestInInfrastructure());
    }

    void InvestInInfrastructure()
    {
        GameManager.instance.InvestInInfrastructure(investmentAmount); // Llama al método de inversión en GameManager
    }
}
