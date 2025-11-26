using UnityEngine;
using UnityEngine.UI;

public class Recogerllave : MonoBehaviour
{
    public static bool jugadorTieneLlave = false;  // <-- Variable global
    public Image iconoLlave; 
    private bool activo; 

    void Update()
    {
        if (activo && Input.GetKeyDown(KeyCode.E)) 
        {
            iconoLlave.enabled = true;     // Muestra el icono
            jugadorTieneLlave = true;      // <-- Ahora el jugador SÍ tiene la llave
            gameObject.SetActive(false);   // Desaparece la llave 3D
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activo = false;
        }
    }
}
