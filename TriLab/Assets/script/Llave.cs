using UnityEngine;

public class Llave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Carolita")
        {
            Debug.Log("¡Carolita recogió la llave!");

            Destroy(gameObject);
        }
    }
}

