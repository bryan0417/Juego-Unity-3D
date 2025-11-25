using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;
public class Cronometro : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoCronometro;
    [SerializeField] private float tiempo;
    private int tiempoMinutos, tiempoSegundos, tiempoDecimasSegundo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void CronometroTiempo()
    {
        tiempo -= Time.deltaTime;
        // TRASNFORMAR TIEMPO MINUTOS, SEGUNDOS, DECIMAL
        tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
        tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
        tiempoDecimasSegundo = Mathf.FloorToInt((tiempo % 1) * 100);

        // ASIGNAR VALORES A EL TEXTO DE CANVA
        textoCronometro.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoDecimasSegundo);
    }

    // Update is called once per frame
    void Update()
    {
        CronometroTiempo();
    }
}
