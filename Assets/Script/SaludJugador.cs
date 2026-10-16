using UnityEngine;
using UnityEngine.SceneManagement;   // Para reiniciar el nivel
using System.Collections;            // Para usar corrutinas

public class SaludJugador : MonoBehaviour
{
    [Header("Vidas")]
    public int vidas = 3;

    [Header("Invulnerabilidad y rechazo")]
    public float tiempoInvulnerable = 1f;   // Segundos sin recibir daño
    public float fuerzaRechazoX = 6f;       // Empujón horizontal
    public float fuerzaRechazoY = 5f;       // Empujón hacia arriba
    public float duracionRechazo = 0.3f;    // Tiempo sin control del jugador

    private bool invulnerable = false;

    // El script de movimiento lee esta variable
    [HideInInspector] public bool enRechazo = false;

    private Rigidbody2D cuerpoRigido;
    private Animator animador;

    void Start()
    {
        cuerpoRigido = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
    }

    // Al tocar un enemigo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            RecibirDano(collision.transform.position);
        }
    }

    // Si sigue tocando al enemigo cuando termina la invulnerabilidad
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            RecibirDano(collision.transform.position);
        }
    }

    void RecibirDano(Vector2 posicionEnemigo)
    {
        // Si es invulnerable, ignora el golpe
        if (invulnerable) return;

        vidas--;
        animador.SetTrigger("Golpe");

        // Sin vidas: reinicia el nivel
        if (vidas <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        // Empuja al jugador lejos del enemigo
        float direccion = transform.position.x > posicionEnemigo.x ? 1f : -1f;
        cuerpoRigido.linearVelocity = new Vector2(direccion * fuerzaRechazoX, fuerzaRechazoY);

        StartCoroutine(RutinaDano());
    }

    // Controla el tiempo de rechazo e invulnerabilidad
    IEnumerator RutinaDano()
    {
        invulnerable = true;
        enRechazo = true;

        yield return new WaitForSeconds(duracionRechazo);
        enRechazo = false;

        yield return new WaitForSeconds(tiempoInvulnerable - duracionRechazo);
        invulnerable = false;
    }
}