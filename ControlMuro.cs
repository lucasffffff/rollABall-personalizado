using UnityEngine;
using System.Collections;

public class ControlMuro : MonoBehaviour
{
    public Transform muroTransform; // Transform del muro
    public Vector3 posicionElevada; // Posición final cuando el muro esté "elevado"
    private Vector3 posicionInicial; // Posición inicial del muro
    private bool muroElevado = false; // Estado actual del muro

    private int monedasRecogidas = 0; // Contador de monedas recogidas por el jugador
    public int monedasNecesarias = 5; // Número de monedas necesarias para levantar el muro

    void Start()
    {
        posicionInicial = muroTransform.position;
    }

    public void AumentarMonedasRecogidas()
    {
        monedasRecogidas++;

        // Si el número de monedas recogidas alcanza el umbral necesario y el muro no está elevado, levanta el muro
        if (monedasRecogidas >= monedasNecesarias && !muroElevado)
        {
            StartCoroutine(MoverMuroElevado(posicionElevada, 0f)); // Cambia 1f al tiempo deseado
        }
    }

    private IEnumerator MoverMuroElevado(Vector3 posicionFinal, float duracion)
    {
        float tiempoPasado = 0f;

        while (tiempoPasado < duracion)
        {
            muroTransform.position = Vector3.Lerp(posicionInicial, posicionFinal, tiempoPasado / duracion);
            tiempoPasado += Time.deltaTime;
            yield return null;
        }

        muroTransform.position = posicionFinal; // Asegúrate de que el muro esté exactamente en la posición final
        muroElevado = true; // Actualiza el estado del muro
    }
}
