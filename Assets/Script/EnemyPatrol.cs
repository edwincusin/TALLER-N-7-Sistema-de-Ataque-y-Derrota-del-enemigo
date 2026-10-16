using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [Header("Ajustes de movimiento")]
    public float velocidad = 3f;
    private bool mirandoDerecha = true; // false =izquierda

    [Header("Detectores")]
    public Transform puntoSuelo; // objeto hijo checkGround
    public float distanciaSuelo = 0.5f;
    public float distanciaPared = 0.5f;

    public LayerMask capaSueloLayer; //capa groundLayer

    private Rigidbody2D cuerpoEnemigo;

    void Start()
    {
        cuerpoEnemigo = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO DER-IZQ
        float direcccionX = mirandoDerecha ? velocidad:-velocidad;
        cuerpoEnemigo.linearVelocity = new Vector2(direcccionX, cuerpoEnemigo.linearVelocityY);

        //SENSORES RAYOS
        Vector2 direccion = mirandoDerecha ? Vector2.right : Vector2.left;

        //RAYO EN Y HACIA ABAJO -- parametros(origen,direccion,distancia,capalayer)
        RaycastHit2D hayPiso = Physics2D.Raycast(puntoSuelo.position, Vector2.down, distanciaSuelo, capaSueloLayer);

        //RAYO EN X PAREDES--()
        RaycastHit2D hayPared= Physics2D.Raycast(transform.position, direccion, distanciaPared, capaSueloLayer);

        //llamar voltear de acuerdo a condiciones
        if (hayPiso.collider == null || hayPared.collider != null)
        {
            Voltear();
        }


    }


    //Metodo Voltear
    void Voltear()
    {
        mirandoDerecha = !mirandoDerecha;

        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }


    //PINTAR RAYOS
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (puntoSuelo != null)
        {
            Gizmos.DrawRay(puntoSuelo.position, Vector2.down*distanciaSuelo);
        }
        Vector2 direccion = mirandoDerecha ? Vector2.right : Vector2.left;
        Gizmos.DrawRay(transform.position, direccion * distanciaPared);
    }
}
