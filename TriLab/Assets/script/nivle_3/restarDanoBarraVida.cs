using System;
using UnityEngine;

public class restarDanoBarraVida : MonoBehaviour
{
    public logicaBarraVida barraPersonaje;
    public float dano =  2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestarVida(bool bandera)
    {
        if (bandera)
        {
            barraPersonaje.vidaActual -= dano;
        }
    }

}
