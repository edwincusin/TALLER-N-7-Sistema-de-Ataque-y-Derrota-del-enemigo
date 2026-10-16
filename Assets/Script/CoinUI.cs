using UnityEngine;
using TMPro;   // Necesario para TextMeshPro

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;   // Se arrastra en el Inspector

    void Start()
    {
        // Reinicia el contador al empezar (el static no se borra solo al reiniciar la escena)
        Coin.monedasRecogidas = 0;
    }

    void Update()
    {
        // Actualiza el texto en cada frame
        textoMonedas.text = "Monedas: " + Coin.monedasRecogidas;
    }
}