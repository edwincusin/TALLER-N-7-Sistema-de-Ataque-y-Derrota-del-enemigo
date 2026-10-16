using UnityEngine;

public class CameraFlow : MonoBehaviour
{
     //a cual vamos a seguir con la camara en este caso el personaje seria el principal objetivo   
    public Transform personaje;

    //a que velocidad va a seguir al personaje la camara 
    public float velocidaAlcanceCamara = 5f;

    public Vector3 distancia = new Vector3(0,2,-10);


    //metodo que se ejecuta luego de que exista movimiento de frame
    public void LateUpdate()
    {
        //validamos que exista un personaje o objetivo para que se mueva si no no hace nada
        if (personaje != null)
        {
            //definimos posicion de la camara en relacion al objetivo -- calculando distancia 
            Vector3 posicionDeseada = personaje.position + distancia;

            //acercamiento calculo de cuanto debe acercarse 
            Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidaAlcanceCamara * Time.deltaTime);

            //IGUALO O MODIFICO LAS PROPIEDADES DE POSICION DE LA CAMARA SEGUN POSICION CALCULADA
            transform.position = posicionSuavizada;
        }

        
    }
}
