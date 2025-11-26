using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel2 : MonoBehaviour
{
    [Header("Referencias a los Canvas")]
    public GameObject canvasMenu;       // Canvas principal
    public GameObject canvasOpciones;   // Canvas de opciones

    // Jugar → Ir a la escena para elegir personaje
    public void Nivel3()
    {
        SceneManager.LoadScene("Nivel 3");
    }

    // Jugar → Ir a la escena para elegir personaje
    public void Volver()
    {
        SceneManager.LoadScene("Nivel 2");
    }
}
