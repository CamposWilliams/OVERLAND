using UnityEngine;
using UnityEngine.UI;

public class CambiadorDeArmas : MonoBehaviour
{
    public Sprite[] imagenes;
    private Image imagen;
    private int indiceActual;
    GameObject Mike;
    GameObject Guardador;
    private void Awake()
    {
        Mike = GameObject.Find("Mike");
        Guardador = GameObject.Find("GuardaDatosEntreEscena");
    }

    void Start()
    {
        imagen = GetComponent<Image>();
        imagen.sprite = imagenes[Guardador.GetComponent<GuardaDatos>().armaActual];


    }
    private void Update()
    {
        ActualizarImagen();
    }
    void ActualizarImagen()
    {
      
        if((int)Mike.GetComponent<JugadorDisparo>().CambioArma<=imagenes.Length && (int)Mike.GetComponent<JugadorDisparo>().CambioArma >0) imagen.sprite = imagenes[(int)Mike.GetComponent<JugadorDisparo>().CambioArma];
        else if((int)Mike.GetComponent<JugadorDisparo>().CambioArma==0 || (int)Mike.GetComponent<JugadorDisparo>().CambioArma==4) imagen.sprite = imagenes[0];

    }
}
