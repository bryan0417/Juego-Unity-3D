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
        SceneManager.LoadScene("ElegirPersonaje");
    }

    // Abrir Canvas de Opciones
    public void AbrirOpciones()
    {
        canvasMenu.SetActive(false);
        canvasOpciones.SetActive(true);
    }

    // Cerrar Canvas de Opciones y volver al menú
    public void CerrarOpciones()
    {
        canvasOpciones.SetActive(false);
        canvasMenu.SetActive(true);
    }

    // Salir del juego
    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego se cerraría aquí (solo compilado).");
    }
}
