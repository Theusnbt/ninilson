using UnityEngine;

public class script : MonoBehaviour

{
    private Rigidbody2D myRigidbody2D;
    private float horizontal;
    private bool facingRight;
    
    [SerializeField] private float movimentoSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        movimentoSpeed = 10;

        facingRight = true;
    }

    // Update is called once per frame :F
    void Update()
    {
        horizontal = Input.GetAxis("horizontal");
        //Debug.Log(horizontal);
        HandMovimento(horizontal);
    }

    void FixedUpdate()
    {
        HandMovimento(horizontal);
        Flip(horizontal);
    }

    void HandMovimento(float horizontal)
    {
        myRigidbody2D.linearVelocity = new Vector2(horizontal * movimentoSpeed, myRigidbody2D.linearVelocity.y);
        Debug.Log(horizontal);
    }

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            //theScale.x *= theScale.x * -1

            theScale.x *= -1;
            transform.localScale = theScale;
            Debug.Log("o personagem virou");
        }
    }
}
