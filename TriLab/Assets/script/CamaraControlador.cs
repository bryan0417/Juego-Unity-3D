using UnityEngine;
using System.Collections;
public class ControladorCamara:MonoBehaviour
{
    public GameObject jugador;
    public Vector3 _distanciaCamara;
    
    void Start()
    {
        _distanciaCamara = transform.position- jugador.transform.position;
    }
    void Update()
    {
        transform.position = jugador.transform.position +_distanciaCamara;
    }

}


