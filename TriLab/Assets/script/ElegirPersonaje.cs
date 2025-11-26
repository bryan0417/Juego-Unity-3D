using UnityEngine;
using UnityEngine.SceneManagement;

public class ElegirPersonaje : MonoBehaviour
{
    [Header("Referencias a los Canvas")]
    public GameObject canvasMenu;
    public GameObject canvasOpciones;

    public void Volver()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    // Cuando se presiona el botón Yipsi
    public void ElegirYipsi()
    {
        SeleccionPersonaje.personajeElegido = "T-Pose";
        SceneManager.LoadScene("Nivel 1");
    }

    // Cuando se presiona el botón JuanM
    public void ElegirJuanM()
    {
        SeleccionPersonaje.personajeElegido = "juan_T-Pose (1)";
        SceneManager.LoadScene("Nivel 1");
    }

    // Cuando se presiona el botón BryanC
    public void ElegirBryanC()
    {
        SeleccionPersonaje.personajeElegido = "BRYAN PERSONAJE";
        SceneManager.LoadScene("Nivel 1");
    }
}
