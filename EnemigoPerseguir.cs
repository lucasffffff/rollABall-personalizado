using UnityEngine;

public class EnemigoPerseguir : MonoBehaviour
{
    public Transform objetivo; // Referencia al transform del jugador
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del enemigo

    private void Start()
    {
        if (objetivo == null)
        {
            // Si no se asignó un objetivo, intenta encontrar automáticamente al jugador
            objetivo = GameObject.FindGameObjectWithTag("Damian")?.transform;
        }
    }

    private void Update()
    {
        if (objetivo != null)
        {
            // Calcula la dirección hacia la que debe moverse el enemigo para perseguir al jugador
            Vector3 direccion = (objetivo.position - transform.position).normalized;

            // Calcula el vector de movimiento utilizando la dirección y la velocidad
            Vector3 movimiento = direccion * velocidadMovimiento * Time.deltaTime;

            // Mueve al enemigo hacia el jugador
            transform.Translate(movimiento);
        }
    }
}
