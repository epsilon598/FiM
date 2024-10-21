using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;  // Velocidad de movimiento
    public float scrollSpeed = 20f;  // Velocidad de zoom
    public float minY = 10f;  // Altura mínima de la cámara
    public float maxY = 80f;  // Altura máxima de la cámara
    public float rotationSpeed = 100f;  // Velocidad de rotación

    public Vector2 panLimit;  // Límites de movimiento en X y Z

    void Update()
    {
        Vector3 pos = transform.position;

        // Movimiento en el eje local de la cámara, sin afectar el eje Y
        Vector3 forwardMovement = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Vector3 rightMovement = new Vector3(transform.right.x, 0, transform.right.z).normalized;

        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            pos += forwardMovement * panSpeed * Time.deltaTime;  // Mover hacia adelante
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            pos -= forwardMovement * panSpeed * Time.deltaTime;  // Mover hacia atrás
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            pos -= rightMovement * panSpeed * Time.deltaTime;  // Mover hacia la izquierda
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            pos += rightMovement * panSpeed * Time.deltaTime;  // Mover hacia la derecha
        }

        // Zoom con la rueda del ratón
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);  // Limitar el zoom

        // Rotación con el botón derecho del ratón
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationX, Space.World);  // Rotar sobre el eje Y global (girar la cámara alrededor del área)
        }

        // Limitar el movimiento de la cámara para que no salga del área definida
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}
