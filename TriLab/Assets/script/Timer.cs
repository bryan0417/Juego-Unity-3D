using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public float tiempo;
    [SerializeField] public TMP_Text texto;

    public int minutos, segundos;

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;

        if (tiempo < 0) tiempo = 0;

        minutos = (int)(tiempo / 60f);
        segundos = (int)(tiempo - minutos * 60f);

        texto.text = string.Format("{0:00}:{1:00}", minutos, segundos);

        if (tiempo == 0)
        {
            Destroy(this);
        }
    }
}
