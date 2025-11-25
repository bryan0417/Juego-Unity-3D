using UnityEngine;

public class Movimientos_Caroline : MonoBehaviour
{
    public float velocidad = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidad);

        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);
    }
}
