using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarMiniJuego : MonoBehaviour
{
    void Start()
    {
        // Hacer visible el cursor
        Cursor.visible = true;

        // Desbloquear el cursor
        Cursor.lockState = CursorLockMode.None;
    }
    public void EntrarMiniJuego()
    {
        Debug.Log("Entrando al minijuego...");
        SceneManager.LoadScene("Escena Juego");   // ← Cambia al nombre de tu escena real
    }
}
