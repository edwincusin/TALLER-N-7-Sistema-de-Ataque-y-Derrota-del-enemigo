using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{

    [Header("Salud del enemigo")]
    public int vidaMaxima = 3;   // Vidas con las que nace el enemigo
    public int vidaActual;       // Vidas que le quedan

    void Start()
    {
        // Al empezar, el enemigo tiene toda su vida
        vidaActual = vidaMaxima;
    }

    // Se llama cuando el jugador golpea al enemigo
    // cantidadDanio = cuántas vidas le quita el golpe
    public void TakeDamage(int cantidadDanio)
    {
        // Restamos el daño a la vida actual
        vidaActual -= cantidadDanio;

        // Si se quedó sin vida, muere
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    // Elimina al enemigo del juego
    void Morir()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
