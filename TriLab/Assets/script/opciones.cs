using UnityEngine;
using UnityEngine.SceneManagement;

public class opciones : MonoBehaviour
{
    [Header("Referencias a los Canvas")]
    public GameObject canvasMenu;       // Canvas principal
    public GameObject canvasOpciones;   // Canvas de opciones

    // Jugar → Ir a la escena para elegir personaje
    public void Volver()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
