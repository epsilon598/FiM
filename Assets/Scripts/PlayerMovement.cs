using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent player;      // Referencia al NavMeshAgent del jugador
    public Camera mainCamera;         // Referencia a la cámara principal
    public float gravity = 9.81f;     // Fuerza de gravedad
    private Vector3 velocity;         // Velocidad actual de caída
    public LayerMask groundLayer;     // Layer que identifica el suelo
    public GameObject menuComprar;    // Referencia al menú MenuComprar
    public Animator animator;
    public bool caminar;
    private Vector3 posicionActual;
    public Transform avatar;


    void Start()
    {
        // Obtiene el componente NavMeshAgent automáticamente al iniciar el juego
        player = GetComponent<NavMeshAgent>();

        avatar = transform.GetChild(0);

        if (mainCamera == null)
        {
            mainCamera = Camera.main;  // Si no se ha asignado, toma la cámara principal
        }

        // Si no se encuentra el NavMeshAgent, mostrar un mensaje de advertencia
        if (player == null)
        {
            Debug.LogError("No se encontró el componente NavMeshAgent en el jugador.");
        }
    }

    void Update()
    {
        HandleMovement();
        ApplyGravity();
        animation();
    }

    // Manejar el movimiento hacia el punto clickeado
    void HandleMovement()
    {
        // Si el menú está activo, se impide el movimiento del jugador
        if (menuComprar != null && menuComprar.activeSelf) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                // Mueve el jugador hacia la posición donde se hizo clic
                if (player.isOnNavMesh)
                {
                    player.SetDestination(hit.point);
                }
                else
                {
                    Debug.LogError("El jugador no está en el NavMesh.");
                }
            }

            //Quaternion rotation = Quaternion.LookRotation(hit.point);
            //rotation.eulerAngles = new Vector3(0,rotation.eulerAngles.y,0);
            //avatar.rotation = rotation;
        }
    }

    // Aplicar la gravedad manualmente
    void ApplyGravity()
    {
        // Crear un Raycast hacia abajo para detectar el suelo
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Si el Raycast no toca el suelo, aplica gravedad
        if (!Physics.Raycast(ray, out hit, 1.1f, groundLayer))
        {
            // Aplicar la gravedad
            velocity.y -= gravity * Time.deltaTime;

            // Mover el agente NavMesh verticalmente con la gravedad aplicada
            player.Move(velocity * Time.deltaTime);
        }
        else
        {
            // Reiniciar la velocidad vertical si está en el suelo
            velocity.y = 0;
        }
    }
    void animation()
    {

        
        //registro de movimiento
        if(transform.position != posicionActual){
            posicionActual=transform.position;
            caminar = true;
        }
        else{
             caminar = false;
        }
        animator.SetBool("caminar",caminar);     
    }    
}
