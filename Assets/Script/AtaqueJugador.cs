using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    [Header("Ajustes de ataque")]
    public Transform puntoAtaque;      // AttackPoint: objeto hijo delante de la espada
    public float rangoAtaque = 0.6f;   // Radio del círculo de golpe
    public LayerMask capaEnemigos;     // Capa Enemy
    public int danioAtaque = 1;        // Daño por espadazo

    private Animator animador;         // Para la animación de ataque
    void Start()
    {
        // Busca el Animator del personaje
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tecla Z o clic izquierdo = atacar
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            Atacar();
        }
    }

    void Atacar()
    {
        // Activa la animación
        if (animador != null)
        {
            animador.SetTrigger("Atacar");
        }

        // Círculo invisible que guarda todos los enemigos que toque
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(puntoAtaque.position, rangoAtaque, capaEnemigos);

        // Recorre cada enemigo golpeado y le quita vida
        foreach (Collider2D enemigo in enemigosGolpeados)
        {
            SaludEnemigo saludEnemigo = enemigo.GetComponent<SaludEnemigo>();

            if (saludEnemigo != null)
            {
                saludEnemigo.TakeDamage(danioAtaque);
            }
        }


    }
    // Dibuja el círculo rojo en la Scene para ver el alcance
    void OnDrawGizmosSelected()
    {
        if (puntoAtaque == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoAtaque.position, rangoAtaque);
    }
}
