using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;

    public CharacterController player;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    private float playerSpeed = 15f;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    private float verticalVelocity = 0f;

    public float jumpForce = 2f;
    public float PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }

    private bool isGrounded;

    // Start is called before the first frame update
    void Start(){
        // Intentar obtener el CharacterController del GameObject
        player = GetComponent<CharacterController>();

        // Si no encuentra el CharacterController, agregarlo manualmente
        if (player == null){
            Debug.LogError("No CharacterController found! Please add one to the player.");
            player = gameObject.AddComponent<CharacterController>();  // Agregar un CharacterController si no está
        }

        // Asignar la cámara principal si no se ha hecho manualmente
        if (mainCamera == null){
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update(){
        // Asegurarse de no continuar si no hay CharacterController
        if (player == null) return;

        // Obtener entrada del jugador
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1); // Limitar el vector de entrada para evitar exceder la velocidad máxima

        camDirection(); // Calcular la dirección en función de la cámara

        // Mover al jugador según la entrada y la dirección de la cámara
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        // Aplicar gravedad y salto
        SetGravityAndJump();

        // Rotar el personaje hacia la dirección del movimiento
        if (movePlayer.magnitude > 0.1f) {
            Vector3 direction = new Vector3(movePlayer.x, 0, movePlayer.z);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }

        // Mover al jugador con la velocidad ajustada, incluida la gravedad
        player.Move(movePlayer * playerSpeed * Time.deltaTime);
    }

    // Calcular la dirección de la cámara
    void camDirection(){
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        // Asegurarse de que los ejes Y no afecten el movimiento
        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    // Aplicar gravedad y permitir saltar
    void SetGravityAndJump(){
        if (player == null) return; // Evitar errores si no hay CharacterController

        // Comprobar si el jugador está en el suelo
        isGrounded = player.isGrounded;

        if (isGrounded){
            // Si está en el suelo, resetear la velocidad vertical
            verticalVelocity = -gravity * Time.deltaTime; // Mantenerlo pegado al suelo

            // Si el jugador presiona el botón de salto
            if (Input.GetButtonDown("Jump")) {
                verticalVelocity = jumpForce;
            }
        } else {
            // Aplicar gravedad mientras está en el aire
            verticalVelocity -= gravity * Time.deltaTime; 
        }

        // Aplicar la velocidad vertical al vector de movimiento
        movePlayer.y = verticalVelocity;
    }
}