using UnityEngine;

public class Movimento : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private float horizontal;

    private bool facingRight;

    [SerializeField] private float movimentoSpeed;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        movimentoSpeed = 10;

        facingRight = true;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    // Melhoria FixedUpdate consome menos recurso da maquina
    void FixedUpdate()
    {
        HandMovimento(horizontal);

        Flip(horizontal);
    }

    void HandMovimento(float horizontal)
    {
        myRigidbody2D.linearVelocity =
            new Vector2(horizontal * movimentoSpeed, myRigidbody2D.linearVelocity.y);

        // Debug.Log(horizontal);
    }

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector2 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;

            Debug.Log("O personagem virou");
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Objetos")
        {
            Debug.Log("Colidiu com o objeto " + colisao.gameObject.tag);
        }
    }

    void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Objetos")
        {
            Debug.Log("Saiu da colisão com o objeto " + colisao.gameObject.tag);
        }
    }

    void OnCollisionStay2D(Collision2D colisao)
    {
        Debug.Log("Player continua colidindo com o objeto")
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        //Debug.Log("Colidiu com Trigger");
        if (colisao.gameObject.tag == "Objetos");
        {
            Destroy(colisao.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D colisao)
    {
        Debug.Log("Deixou de colidir com objeto Trigger");
    }
     void OnTriggerStay2D(Collider2D colisao)
    {
        Debug.Log("Player continua colidindo com objeto TRIGGER");
    }
}