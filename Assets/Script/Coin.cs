using UnityEngine;

public class Coin : MonoBehaviour
{
    // static = un solo contador compartido por todas las monedas
    public static int monedasRecogidas = 0;

    // Se ejecuta cuando algo entra en el trigger de la moneda
    void OnTriggerEnter2D(Collider2D otro)
    {
        // Solo reacciona si es el jugador
        if (otro.CompareTag("Jugador"))
        {
            monedasRecogidas++;     // Suma 1 al contador
            Destroy(gameObject);    // Elimina esta moneda
        }
    }
}