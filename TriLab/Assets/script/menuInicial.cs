using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [Header("Referencias a los Canvas")]
    public GameObject canvasMenu;       // Canvas principal
    public GameObject canvasOpciones;   // Canvas de opciones

    // Jugar → Ir a la escena para elegir personaje
    public void Jugar()
    {
        SceneManager.LoadScene("Elegir Personaje");
    }

    // Abrir Canvas de Opciones
    public void AbrirOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    // Salir del juego
    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego se cerraría aquí (solo compilado).");
    }
}
