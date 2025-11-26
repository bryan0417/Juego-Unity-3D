using UnityEngine;
using UnityEngine.UI;

public class Recogerllave : MonoBehaviour
{
    public Image iconoLlave; // Se crea para tener la imagen de la llave
    private bool activo; // Para saber cuando el personaje este en el box collider para activación


    void Update()
    {
        if (activo && Input.GetKeyDown(KeyCode.E)) // Si el juagdor esta en ell box collider y oprime la tecla E
        {
            iconoLlave.enabled = true; // Se muestra la llave
            gameObject.SetActive(false); // El objeto desaparece 3D
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
        if (other.CompareTag("Player")) //Si el que entra en esa zona tiene el tag de player
        {
            activo = false;
        }
    }
}
