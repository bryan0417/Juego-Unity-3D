using UnityEngine;

public class EnemigoRutina:MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator animator;
    public Quaternion angulo;
    public float grado;


    void Start()
    {
        //INICIALIZAR ANIMACION
        animator = GetComponent<Animator>();    
    }

    public void ComportamientoEnemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >=4)
        {
            // NUMERO ALEATORIO ENTRE 0,1
            rutina = Random.Range(0,2);
            cronometro =0;
        }
        switch (rutina)
        {
            case 0:
                animator.SetBool("walk", false);
                break;

            case 1:
                //ESCOGER VALORES ALEATORIOS PARA MOVER AL ENEMIGO
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina ++;
                break;

            case 2:
                // CAMINAR
                transform.rotation = Quaternion.RotateTowards(transform.rotation,angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 *  Time.deltaTime);
                animator.SetBool("walk",true);
                break;
        }
    }
    void Update()
    {
        ComportamientoEnemigo();
    }

}
