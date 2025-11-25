using UnityEngine;

public class EnemigoRutina:MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator animator;
    public Quaternion angulo;
    public float grado;

    public GameObject jugador;
    public float velocidadCaminar = 2f;
    public float velocidadCorrer = 8f;
    public bool ataque;
    void Start()
    {
        //INICIALIZAR ANIMACION
        animator = GetComponent<Animator>();
        //BUSCAR JUGADOS
        jugador = GameObject.Find("jugador");
    }

   public void ComportamientoEnemigo()
{
    if(Vector3.Distance(transform.position, jugador.transform.position) > 5)
    {
        // RANGO DE VISION DEL ENEMIGO
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
                animator.SetBool("run", false); // Aseguramos que "run" esté desactivado.
                break;

            case 1:
                // ESCOGER VALORES ALEATORIOS PARA MOVER AL ENEMIGO
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina ++;
                break;

            case 2:
                // CAMINAR
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                // ----------- ANADIR VELOCIDAD DE CAMINAR ----------
                transform.Translate(Vector3.forward * velocidadCaminar * Time.deltaTime);
                animator.SetBool("walk", true);
                animator.SetBool("run", false); // Aseguramos que "run" esté desactivado.
                break;
        }
    }
    else
    {
            if (Vector3.Distance(transform.position, jugador.transform.position)> 1 && !ataque)
            {
                // PERSEGUIR AL JUGADOR
                var miradaPosicion = jugador.transform.position - transform.position;
                miradaPosicion.y = 0;
                var giro = Quaternion.LookRotation(miradaPosicion);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, giro, 2);
                
                // Cancelar animación de caminar e iniciar animación de correr
                animator.SetBool("walk", false); 
                animator.SetBool("run", true); 
                transform.Translate(Vector3.forward * velocidadCorrer * Time.deltaTime);
                
                animator.SetBool("attack", false);
                // VELOCIDAD DE CORRER
            }
            else
            {
                animator.SetBool("walk", false);
                animator.SetBool("run", false);
                animator.SetBool("attack", true);
                ataque = true;
            }
    }
}
    void finalAtaque()
    {
        animator.SetBool("attack", false);
        ataque = false;
    }

    void Update()
    {
        ComportamientoEnemigo();
    }

}
