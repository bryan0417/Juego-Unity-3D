using UnityEngine;

public class SpawnerPersonaje : MonoBehaviour
{
    public GameObject YipsiPrefab;
    public GameObject JuanMPrefab;
    public GameObject BryanPrefab;

    public Transform puntoSpawn;

    void Start()
    {
        if (SeleccionPersonaje.personajeElegido == "T-Pose")
        {
            Instantiate(YipsiPrefab, puntoSpawn.position, puntoSpawn.rotation);
        }
        else if (SeleccionPersonaje.personajeElegido == "juan_T-Pose (1)")
        {
            Instantiate(JuanMPrefab, puntoSpawn.position, puntoSpawn.rotation);
        }
        else if (SeleccionPersonaje.personajeElegido == "BRYAN PERSONAJE")
        {
            Instantiate(BryanPrefab, puntoSpawn.position, puntoSpawn.rotation);
        }
        else
        {
            Debug.Log("No se seleccionó personaje");
        }
    }
}

