using System;
using UnityEngine;
using UnityEngine.UI;
public class logicaBarraVida : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image imagenBarraVida;
    public GameObject finDelJuego;
    public Cronometro cronometro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaActual = vidaMax;
        finDelJuego.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        if (vidaActual <= 0)
        {  
            juegoTerminado();
            
        }
    }

    void RevisarVida()
    {
        imagenBarraVida.fillAmount = vidaActual /vidaMax;
    }
    
    void juegoTerminado()
    {
        
        cronometro.muerto();
    }
}
