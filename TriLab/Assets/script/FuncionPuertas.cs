using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaCorrecta : MonoBehaviour
{
    public int miNumeroDePuerta = 1;   // 1, 2 o 3
    public static int puertaCorrecta;  // igual para todas

    void Awake()
    {
        puertaCorrecta = 0;
    }

    void Start()
    {
        if (puertaCorrecta == 0)
        {
            puertaCorrecta = Random.Range(1, 4); // 1 a 3
            Debug.Log("Puerta correcta = " + puertaCorrecta);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si NO tiene la llave
            if (!Llave.jugadorTieneLlave)
            {
                Debug.Log("No puedes pasar. Necesitas la llave.");
                return;
            }

            // Si es la puerta correcta
            if (miNumeroDePuerta == puertaCorrecta)
            {
                Debug.Log("PUERTA CORRECTA. Cargando nivel...");
                SceneManager.LoadScene("Pasar Nivel 1");
            }
            else
            {
                Debug.Log("Puerta incorrecta. Pierdes una vida.");

                // 🔥 RESTAR VIDA
                other.GetComponent<VidaJugador>().PerderVida();
            }
        }
    }
}
