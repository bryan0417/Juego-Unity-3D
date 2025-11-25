using UnityEngine;

public class RecogerAntorcha : MonoBehaviour
{

    public GameObject antorcha; // Se crea para tener el objeto de la antorcha
    public Transform mano; // Para saber en que posicion y donde posicionar la mano
    private bool activo; // Para saber cuando el personaje este en el box collider para activación


    void Update()
    {
        if(activo == true)
        {
            if (Input.GetKeyDown(KeyCode.E)) //Si esta activo y digita la tecla E
            {
                antorcha.transform.SetParent(mano); //Posicionarlo y que la antorcha sea hijo de la mano
                antorcha.transform.localPosition = Vector3.zero; // Quede en la misma posicion de la mano
                antorcha.transform.localRotation = Quaternion.identity; //Hace la misma rotacion de la mano
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) //Si el que entra en esa zona tiene el tag de player
        {
            activo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) //Si el que entra en esa zona tiene el tag de player
        {
            activo = false;
        }
    }
}
