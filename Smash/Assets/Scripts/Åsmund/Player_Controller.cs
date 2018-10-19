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

    public string player;           // Reference to if the character is player1 or player2


    private void Start() {
        if (PlayerPrefs.GetString("Player2tag") == "Åsmund")
            player = "-2";
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
=======
        anim.SetBool("throw", false);
        horizontal = Input.GetAxis("Horizontal"+ player);
        if (Input.GetButtonDown("Jump"+ player)) {
            jump = true;
        }
        if (Input.GetButtonDown("Fire1"+player))
        { 
            shuriken.shoot();
        }
>>>>>>> ac3bd6a7346095e08595019724574ac552d59844
    }
        private void FixedUpdate()
    {
        HandleMovement(horizontal, jump);
        jump = false;
        anim.SetFloat("velocity", velocity);

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
        }
        // flips the animation to face moving direction
        if (horizontal < 0)
        {
            sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            sprite.flipX = false;
        }
    }
    // For detecting when on ground and not
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
        anim.SetBool("grounded", grounded);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        airJumped = 0;
        anim.SetBool("grounded", grounded);
    }
}
