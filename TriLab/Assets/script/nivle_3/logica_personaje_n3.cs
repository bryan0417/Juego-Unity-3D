using UnityEngine;

public class logica_personaje_n3 : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 200f;
    public restarDanoBarraVida restarVida;
    private Animator ani;
    public CargarMiniJuego miniJuego;
    private float x, y;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

 
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Rotación
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

        // Movimiento (espacio LOCAL)
        Vector3 movimiento = transform.forward * y * velocidadMovimiento * Time.deltaTime;
        transform.position += movimiento;

        // Animación
        ani.SetFloat("VelX", x);
        ani.SetFloat("VelY", y);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            miniJuego.EntrarMiniJuego();
            Debug.Log("Finilitaciones Ha salido.");
        }
        else if (other.CompareTag("arma"))
        {
            restarVida.RestarVida(true);
            Debug.Log("Dano");
        }
    }
}
