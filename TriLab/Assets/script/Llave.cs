using UnityEngine;

public class Llave : MonoBehaviour
{
    [Header("Rango de aparición aleatoria")]
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;

    public bool cercaJugador = false;
    public static bool jugadorTieneLlave = false;

    private Transform jugador;

    void Start()
    {
        // Posición aleatoria de aparición
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        transform.position = new Vector3(randomX, transform.position.y, randomZ);
    }

    void Update()
    {
        if (cercaJugador && !jugadorTieneLlave && Input.GetKeyDown(KeyCode.E))
        {
            jugadorTieneLlave = true;
            Debug.Log("LLAVE RECOGIDA");

            transform.SetParent(jugador);
            transform.localPosition = new Vector3(0.3f, 0.8f, 0.2f);
            transform.localRotation = Quaternion.identity;

            GetComponent<Collider>().enabled = false;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null) Destroy(rb);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaJugador = true;
            jugador = other.transform;
            Debug.Log("Cerca = True");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaJugador = false;
            jugador = null;
        }
    }
}
