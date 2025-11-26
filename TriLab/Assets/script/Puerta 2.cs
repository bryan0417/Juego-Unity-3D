using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!Recogerllave.jugadorTieneLlave)
            {
                Debug.Log("No puedes pasar. Necesitas la llave.");
                return;
            }

            Debug.Log("Entrando al Nivel 2...");
            SceneManager.LoadScene("Pasar Nivel 2");
        }
    }
}
