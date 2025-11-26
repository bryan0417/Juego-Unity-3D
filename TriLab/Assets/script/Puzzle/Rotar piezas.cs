using UnityEngine;

public class Rotarpiezas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int[] angulos = { 0, 90, 180, 270 };
        foreach (Transform pieza in transform)
        {
            int randomIndex = Random.Range(0, angulos.Length);
            int randomZ = angulos[randomIndex];

            pieza.rotation = Quaternion.Euler(0, 0, randomZ);
        }

    }
}
