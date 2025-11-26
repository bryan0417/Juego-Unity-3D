using UnityEngine;
using UnityEngine.AI;

public class EnemigoRutina : MonoBehaviour
{
    [Header("Rutina y Animación")]
    public int rutina;
    public float cronometro;
    public Animator animator;

    [Header("Movimiento Aleatorio")]
    public Quaternion angulo;
    public float grado;
    public float velocidadCaminar = 2f;

    [Header("Persecución")]
    public GameObject jugador;
    public float velocidadCorrer = 8f;
    public bool ataque;
    public NavMeshAgent agente;
    public float distancia_ataque = 1.5f; // Distancia mínima para atacar
    public float radio_vision = 10f; 

    public int nivelRisa = 19;
    [SerializeField] private AudioClip risa;     // El clip de la risa

    private AudioSource audioSource;  // El AudioSource que está en la cámara

    void Start()
    {
        animator = GetComponent<Animator>();
        jugador = GameObject.Find("jugador");
        agente = GetComponent<NavMeshAgent>();

        // Configuración inicial del agente
        agente.speed = velocidadCorrer;
        agente.stoppingDistance = distancia_ataque;
        agente.autoBraking = true; // Se desacelera al llegar al destino
        agente.angularSpeed = 120f; // Velocidad de giro
        agente.acceleration = 8f;   // Aceleración

        // Obtener el AudioSource de la cámara principal
        audioSource = Camera.main.GetComponent<AudioSource>();  // Accede al AudioSource de la cámara
    }

    void Update()
    {
        ComportamientoEnemigo();
    }

    void ComportamientoEnemigo()
    {
        if (jugador == null) return;

        float distanciaJugador = Vector3.Distance(transform.position, jugador.transform.position);

        if (distanciaJugador > radio_vision)
        {
            var randomNumero = Random.Range(0, 21);
            if (randomNumero < nivelRisa)
            {
                nivelRisa++;
                // SONIDO RISA
                if (audioSource != null && risa != null)  // Asegurarse de que audioSource y risa no sean null
                {
                    audioSource.PlayOneShot(risa);  // Reproducir el sonido usando el AudioSource de la cámara
                }
            }

            // Comportamiento aleatorio
            agente.enabled = false;
            animator.SetBool("run", false);

            cronometro += Time.deltaTime;
            if (cronometro >= 4f)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    animator.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * velocidadCaminar * Time.deltaTime);
                    animator.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            // Perseguir al jugador usando NavMesh
            agente.enabled = true;
            agente.speed = velocidadCorrer;
            agente.SetDestination(jugador.transform.position);

            // Revisar distancia para atacar
            if (distanciaJugador > distancia_ataque)
            {
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
            }
            else
            {
                // Si está dentro de distancia de ataque y agente ya llegó al destino
                if (!ataque && agente.remainingDistance <= agente.stoppingDistance && !agente.pathPending)
                {
                    agente.isStopped = true; // Detener movimiento antes de atacar
                    transform.LookAt(new Vector3(jugador.transform.position.x, transform.position.y, jugador.transform.position.z));

                    animator.SetBool("walk", false);
                    animator.SetBool("run", false);
                    animator.SetBool("attack", true);
                    ataque = true;
                }
            }
        }
    }

    // Llamar desde Animation Event al final de la animación de ataque
    public void finalAtaque()
    {
        animator.SetBool("attack", false);
        ataque = false;
        agente.isStopped = false; // Reanudar movimiento después de atacar
    }
}
