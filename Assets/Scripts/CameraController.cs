using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // Referencia al jugador
    public Vector3 offset;          // Desplazamiento de la cámara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del movimiento de la cámara

    private Quaternion initialRotation;  // Almacena la rotación inicial de la cámara

    void Start()
    {
        // Si no has asignado al jugador manualmente en el inspector, búscalo por el nombre o tag
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        // Guardar la rotación inicial de la cámara para mantenerla fija
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // La nueva posición deseada de la cámara, manteniendo el desplazamiento
        Vector3 desiredPosition = player.position + offset;

        // Interpolar suavemente entre la posición actual de la cámara y la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Asignar la nueva posición suavizada a la cámara
        transform.position = smoothedPosition;

        // Mantener la rotación inicial de la cámara (sin rotar hacia el jugador)
        transform.rotation = initialRotation;
    }
}
