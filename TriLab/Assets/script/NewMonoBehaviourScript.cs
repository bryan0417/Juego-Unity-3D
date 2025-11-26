using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Referencias a los Canvas")]
    public GameObject canvasMenu;       // Canvas principal
    public GameObject canvasOpciones;   // Canvas de opciones

    public void Volver()
    {
        SceneManager.LoadScene("Fin");
    }
}
