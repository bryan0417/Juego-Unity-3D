using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver2 : MonoBehaviour
{
    [Header("Referencias a los Canvas")]
    public GameObject canvasMenu;       // Canvas principal
    public GameObject canvasOpciones;   // Canvas de opciones

    // Jugar → Ir a la escena para elegir personaje
    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego se cerraría aquí (solo compilado).");
    }

    // Jugar → Ir a la escena para elegir personaje
    public void Volver()
    {
        SceneManager.LoadScene("Nivel 3");
    }
}

