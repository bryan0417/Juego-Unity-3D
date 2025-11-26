using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorCamara : MonoBehaviour
{
    public Transform jugador;
    public float distancia = 4f;          // distancia de la cámara al jugador
    public float altura = 2f;             // altura de la cámara
    public float sensibilidad = 200f;

    private Vector2 lookInput;
    private float rotacionX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (jugador == null)
            return;  // Evita error si el jugador no está asignado o fue destruido

        float mouseX = lookInput.x * sensibilidad * Time.deltaTime;
        float mouseY = lookInput.y * sensibilidad * Time.deltaTime;

        // rotación vertical (pitch)
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -40f, 60f);

        // rotación horizontal del jugador
        jugador.Rotate(Vector3.up * mouseX);

        // --- CÁLCULO DE LA POSICIÓN DE LA CÁMARA ---
        Quaternion rotacion = Quaternion.Euler(rotacionX, jugador.eulerAngles.y, 0);

        Vector3 offset =
            rotacion * new Vector3(0, altura, -distancia); // detrás del jugador

        transform.position = jugador.position + offset;

        // mirar al jugador
        transform.LookAt(jugador.position + Vector3.up * altura * 0.5f);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
