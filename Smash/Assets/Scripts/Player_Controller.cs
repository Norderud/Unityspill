using UnityEngine;


public class Player_Controller : MonoBehaviour {

    private bool jump, grounded, pointUp;
    private int airJumped = 0;
    private float velocity;

    public float horizontal;
    public Rigidbody2D rb;
    public float jumpForce = 100f;
    public float speed = 400f;
    public Animator anim;
    public SpriteRenderer sprite;
    public Shuriken shuriken;

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("throw", false);
        horizontal = Input.GetAxis("Horizontal");
        /*
        if (Input.GetButton("Up"))
        {
            pointUp = true;
        }
        else
        {
            pointUp = false;
        }*/
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
        if (Input.GetButtonDown("Fire1"))
        { 
            anim.SetBool("throw", true);
            shuriken.shoot(pointUp);
        }
    }
        private void FixedUpdate()
    {
        HandleMovement(horizontal, jump);
        jump = false;
    }
    void HandleMovement(float horizontal, bool jump)
    {
        velocity = rb.velocity.y;
        // Moving the rigidbody and animating it
        rb.velocity = new Vector2(speed * horizontal * Time.deltaTime, rb.velocity.y);
        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        // Jumps if double jump is available
        if (jump && airJumped < 2)
        {
            rb.velocity = new Vector2(0, 0); // resets the velocity before each jump
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            airJumped++;
            grounded = false;
        } 
        // flips the animation to face moving direction
        if (horizontal < 0)
        {
            sprite.flipX = true;
        } else if( horizontal > 0)
        {
            sprite.flipX = false;
        }
            anim.SetFloat("velocity", velocity);
            anim.SetBool("grounded", grounded);



    }
    // For detecting when on ground and not
    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        airJumped = 0;
    }
}
