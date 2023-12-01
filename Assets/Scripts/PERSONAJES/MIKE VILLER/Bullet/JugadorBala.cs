using UnityEngine;

public class JugadorBala : MonoBehaviour
{
    public float rapidezBala;
    Vector2 velocidadMike;
    Rigidbody2D rb2dBala;
    public Vector2 direction;
    Animator animacionBala;
    public float numeroDeBala;
   

    private void Awake()
    {
        rapidezBala = 10;
       
    }
    void Start()
    {
        animacionBala = GetComponent<Animator>();
        velocidadMike =GameObject.Find("Mike").GetComponent<Rigidbody2D>().velocity;
        rb2dBala = GetComponent<Rigidbody2D>();
      
        
        
          
    }

    void Update()
    {
       
        ReproducirAnimacionDelTipoDeBala();
        Movimiento();
    }

     void Movimiento()
    {
        rb2dBala.velocity = velocidadMike + rapidezBala * velocidadMike.normalized;
        
        if (velocidadMike == Vector2.zero)
        {
            rb2dBala.velocity = rapidezBala * Vector2.up;
        }

        Destroy(gameObject, 1);
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
