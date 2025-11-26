using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoCronometro;
    [SerializeField] private float tiempo;
    private int tiempoMinutos, tiempoSegundos, tiempoDecimasSegundo;
    public GameObject finDelJuego;


    // Referencia al AudioSource y los clips de música
    [SerializeField] private AudioSource musica;         // El AudioSource actual
    [SerializeField] private AudioClip gameOver;     // El clip de la nueva canción (tipo AudioClip)

    // Función para actualizar el cronómetro
    void CronometroTiempo()
    {
        tiempo -= Time.deltaTime;
        
        // Transformar tiempo en minutos, segundos y decimales
        tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
        tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
        tiempoDecimasSegundo = Mathf.FloorToInt((tiempo % 1) * 100);

        // Asignar los valores al texto en pantalla
        textoCronometro.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoDecimasSegundo);
    }

    // Función para validar si el cronómetro llegó a 00:00:00
    void ValidarCronometro()
    {
        if (tiempo <= 0)
        {
            // Si el tiempo es 0 o menor, se termina el juego
            TerminarJuego();
        }
    }

    // Función para finalizar el juego
   public void TerminarJuego()
    {
        // Aquí puedes hacer lo que sea necesario al terminar el juego
        Debug.Log("¡El tiempo se ha agotado! Fin del juego.");
         //finDelJuego.SetActive(true);
    SceneManager.LoadScene("Game Over");  
        // Detener el tiempo
        Time.timeScale = 0f;

        // Desactivar personaje
        gameObject.SetActive(false);
        
        // Detener la música actual
        if (musica != null)
        {
            musica.Stop();
            Debug.Log("Música actual detenida.");
        }

        // Cambiar el clip de música y reproducir la nueva canción
        if (musica != null && gameOver != null)
        {
            musica.clip = gameOver;  // Cambiar el clip de música
            musica.Play();               // Reproducir la nueva música
            Debug.Log("Nueva música comenzó a sonar.");
        }

        // Si quieres cargar una escena de fin de juego, por ejemplo:
        // SceneManager.LoadScene("GameOverScene");

        // O para cerrar el juego completamente:
        // Application.Quit();
    }

    public void muerto()
    {
        // Aquí puedes hacer lo que sea necesario al terminar el juego
        tiempo = 0;
    }
    // Update se ejecuta una vez por frame
    void Update()
    {
        CronometroTiempo();    // Actualizar el cronómetro
        ValidarCronometro();   // Validar si el cronómetro terminó
    }
}
