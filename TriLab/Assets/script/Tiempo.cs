using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tiempo : MonoBehaviour
{
    [SerializeField] public float tiempo;
    [SerializeField] public TMP_Text texto;

    public int minutos, segundos;

    void Update()
    {
        tiempo -= Time.deltaTime;

        if (tiempo < 0) tiempo = 0;

        minutos = (int)(tiempo / 60f);
        segundos = (int)(tiempo - minutos * 60f);

        texto.text = string.Format("{0:00}:{1:00}", minutos, segundos);

        // Cuando el tiempo llega a 0...
        if (tiempo == 0)
        {
            SceneManager.LoadScene("Game Over 1");
        }
    }
}
