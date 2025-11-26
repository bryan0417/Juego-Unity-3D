using UnityEngine;

public class ValidadorPuzzle : MonoBehaviour
{
    public Transform[] piezas;
    public Vector3[] posicionesCorrectas;
    public float[] rotacionesCorrectas; // <--- NUEVO
    public float toleranciaPosicion = 0.1f;
    public float toleranciaRotacion = 5f; // puedes usar 0 si quieres exactitud total

    public void RevisarPuzzle()
    {
        if (ValidarRompecabezas())
        {
            Debug.Log("¡Rompecabezas armado correctamente!");
        }
        else
        {
            Debug.Log("El rompecabezas aún no está completo.");
        }
    }

    bool ValidarRompecabezas()
    {
        for(int i = 0; i < piezas.Length; i++)
        {
            // validar posición
            if(Vector3.Distance(piezas[i].position, posicionesCorrectas[i]) > toleranciaPosicion)
                return false;

            // validar rotación
            float anguloActual = piezas[i].eulerAngles.z;
            float anguloCorrecto = rotacionesCorrectas[i];

            if(Mathf.Abs(Mathf.DeltaAngle(anguloActual, anguloCorrecto)) > toleranciaRotacion)
                return false;
        }
        return true;
    }
}
