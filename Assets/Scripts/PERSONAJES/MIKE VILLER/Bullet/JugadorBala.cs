using UnityEngine;

public class JugadorBala : MonoBehaviour
{
    public float rapidezBala;
    Vector2 velocidadMike;
    Rigidbody2D rb2dBala;
    Animator animacionBala;
    public float numeroDeBala;
    public Vector2 direccionBala;
   

    private void Awake()
    {
        rapidezBala = 10;
       
    }
    void Start()
    {
        //Debug.Log(direccionBala);
        animacionBala = GetComponent<Animator>();
        velocidadMike =GameObject.Find("Mike").GetComponent<Rigidbody2D>().velocity;
        rb2dBala = GetComponent<Rigidbody2D>();
        direccionBala = GameObject.Find("Mike").GetComponent<MikeDisparo>().referencia;
        Destroy(gameObject, 4);
         
    }

    void Update()
    {
      
        ReproducirAnimacionDelTipoDeBala();
        Movimiento();
    }

    void Movimiento()
    {
        rb2dBala.velocity = direccionBala*rapidezBala;
        
       

    }
    void ReproducirAnimacionDelTipoDeBala()
    {
        
            animacionBala.SetFloat("TipoDeBala", numeroDeBala);      
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("TileCollider"))
        {
            Destroy(gameObject);
        }
       
    }

   
}
