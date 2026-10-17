using System.Collections;
using UnityEngine;

// Trampa de pinchos que se activa y se desactiva sola cada cierto tiempo
public class TrampaPinchos : MonoBehaviour
{
    [Header("Ajustes de tiempo")]
    public float tiempoEspera = 2f;    // Segundos con los pinchos escondidos (trampa segura)
    public float tiempoActivo = 1f;    // Segundos con los pinchos fuera (trampa peligrosa)

    [Header("Ajustes de daño")]
    public int cantidadDano = 1;       // Vidas que le quita al jugador

    [Header("Estado de la trampa")]
    public bool esPeligrosa = false;   // true = lastima / false = es segura


    private Animator animador;

    void Start()
    {
        // Busca el Animator que está en este mismo objeto
        animador = GetComponent<Animator>();

        // Arranca el "reloj" de la trampa
        StartCoroutine(RutinaTrampa());
    }

    // Se llama una vez cuando algo entra en la zona de la trampa
    // (el collider de la trampa debe tener "Is Trigger" activado)
    private void OnTriggerEnter2D(Collider2D otro)
    {
        AplicarDano(otro);
    }

    // Se llama constantemente mientras algo sigue dentro de la zona
    private void OnTriggerStay2D(Collider2D otro)
    {
        AplicarDano(otro);
    }

    // Corrutina: se pausa en cada "yield" y continúa desde ahí.
    // El while (true) hace que el ciclo se repita siempre.
    IEnumerator RutinaTrampa()
    {
        while (true)
        {
            // 1. La trampa empieza segura y espera
            esPeligrosa = false;
            yield return new WaitForSeconds(tiempoEspera);

            // 2. Lanza la animación de los pinchos
            if (animador != null)
            {
                animador.SetTrigger("Activar");
            }

            // 3. Ahora sí lastima, durante "tiempoActivo" segundos
            esPeligrosa = true;
            yield return new WaitForSeconds(tiempoActivo);

            // 4. Vuelve a ser segura y el ciclo se repite
            esPeligrosa = false;
        }
    }

    // Decide si lo que tocó la trampa recibe daño
    void AplicarDano(Collider2D otro)
    {
        if (esPeligrosa)
        {
            // Intenta obtener el script de vida del objeto que tocó la trampa
            SaludJugador vidaJugador = otro.GetComponent<SaludJugador>();

            // Si no es null, es el jugador
            if (vidaJugador != null)
            {
                // Se envía la posición de la trampa (para el empujón) y el daño
                vidaJugador.RecibirDano(transform, cantidadDano);
            }
        }
    }
}