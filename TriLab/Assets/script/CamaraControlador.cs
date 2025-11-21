using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorCamara : MonoBehaviour
{
    public GameObject jugador;
    public Vector3 _distanciaCamara;
    public float sensibilidad = 200f;

    private Vector2 lookInput;
    private float rotacionX = 0f;

    void Start()
    {
        _distanciaCamara = transform.position - jugador.transform.position;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = lookInput.x * sensibilidad * Time.deltaTime;
        float mouseY = lookInput.y * sensibilidad * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -80f, 80f);

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        jugador.transform.Rotate(Vector3.up * mouseX);

        transform.position = jugador.transform.position + _distanciaCamara;
    }

    // ESTE MÉTODO LO LLAMA EL INPUT SYSTEM AUTOMÁTICAMENTE
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
