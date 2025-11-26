using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    [Header("Referencias a los Canvas")]
    public GameObject canvasMenu;       // Canvas principal
    public GameObject canvasOpciones;   // Canvas de opciones

    // Jugar → Ir a la escena para elegir personaje
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    public void IrCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Volver()
    {
        SceneManager.LoadScene("Nivel 3");
    }
}
