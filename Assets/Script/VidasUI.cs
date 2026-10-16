using UnityEngine;
using UnityEngine.UI;   // Necesario para usar Image (imágenes de UI)

public class VidasUI : MonoBehaviour
{
    [Header("Conexiones (se arrastran en el Inspector)")]
    public SaludJugador saludJugador;   // Script de vidas del personaje
    public Image[] corazones;           // Las 3 imágenes de corazón, en orden

    void Update()
    {
        // Recorre los corazones uno por uno: 0, 1, 2
        for (int i = 0; i < corazones.Length; i++)
        {
            // Regla importante:
            // el corazón número i se ve solo si i es MENOR que las vidas actuales.
            //
            // Ejemplo con vidas = 2:
            //   corazón 0 -> 0 < 2 -> se ve
            //   corazón 1 -> 1 < 2 -> se ve
            //   corazón 2 -> 2 < 2 -> NO se ve
            corazones[i].enabled = i < saludJugador.vidas;
        }
    }
}