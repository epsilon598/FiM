using UnityEngine;
public class BuildingPlacer : MonoBehaviour
{
    public GameObject buildingPrefab;
    private GameObject currentBuilding;

    void Update()
    {
        if (currentBuilding != null)
        {
            // Mover el edificio donde el mouse apunte
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                currentBuilding.transform.position = hit.point;
            }

            // Confirmar la construcción al hacer clic
            if (Input.GetMouseButtonDown(0))
            {
                currentBuilding = null; // Finaliza la colocación
            }
        }
    }

    public void StartPlacingBuilding()
    {
        currentBuilding = Instantiate(buildingPrefab);
    }
}
