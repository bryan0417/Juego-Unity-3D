using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    public int vidas = 3;          // Número de vidas actuales
    public Text textoVidas;        // Texto UI para mostrar las vidas

    void Start()
    {
        ActualizarUI();
    }

    public void PerderVida()
    {
        vidas--;

        if (vidas < 0)
            vidas = 0;

        ActualizarUI();

        if (vidas == 0)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("Menu Principal");  // o escena de Game Over
        }
    }

    void ActualizarUI()
    {
        if (textoVidas != null)
            textoVidas.text = "Vidas: " + vidas;
    }
}
