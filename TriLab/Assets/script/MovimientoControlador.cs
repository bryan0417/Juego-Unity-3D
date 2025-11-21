
using UnityEngine;
using UnityEngine.InputSystem;

public class controlador_movimientos : MonoBehaviour
{
    public int _velocidad = 10;
    Rigidbody _rigidbody = null;
    Vector3 _direccion = Vector3.zero;
    Transform cam;// CAMARA
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        ReadInput();
        JumpCube();
    }

    void FixedUpdate()
    {
        MoveCube();
    }

    private void ReadInput()
    {
        var keyBoard = Keyboard.current;

        float _horizontal = 0;
        float _vertical = 0;

        if (keyBoard.dKey.isPressed) _horizontal = 1;
        if (keyBoard.aKey.isPressed) _horizontal = -1;

        if (keyBoard.wKey.isPressed) _vertical = 1;
        if (keyBoard.sKey.isPressed) _vertical = -1;

        _direccion = new Vector3(_horizontal, 0, _vertical).normalized;//NORMALIZAR CON LACAMARA
    }

    private void MoveCube()
    {
        /* 
        Vector3 movimiento = _direccion * _velocidad * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movimiento);
        */
        // Si NO hay dirección → detener velocidad horizontal
        if (_direccion.magnitude > 0)
        {   
            Vector3 forward = cam.forward;
            forward.y =0;
            forward.Normalize();

            Vector3 right = cam.right;
            right.y= 0;
            right.Normalize();

            Vector3 direccionFinal = forward * _direccion.z + right * _direccion.x;
            Vector3 movimiento = direccionFinal * _velocidad * Time.fixedDeltaTime;

            _rigidbody.MovePosition(_rigidbody.position + movimiento);
        }
        else
        {
            Vector3 v = _rigidbody.linearVelocity;
            v.x = 0;
            v.z = 0;     // NO tocamos Y para no romper el salto
            _rigidbody.linearVelocity = v;            
        }
    }

    private void JumpCube()
    {
        var keyBoard = Keyboard.current;

        // Detectar si está en suelo: velocidad vertical casi cero
        bool estaEnSuelo = Mathf.Abs(_rigidbody.linearVelocity.y) < 0.01f;

        if (keyBoard.spaceKey.isPressed && estaEnSuelo)
        {
            _rigidbody.AddForce(Vector3.up * 200);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finilitaciones Ha salido.");
        }
    }
}
