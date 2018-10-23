using UnityEngine;


public class Player_Controller : MonoBehaviour {

    private bool jump, pointUp;
    private int airJumped = 0;
    private float velocity;

    public float horizontal;
    public Rigidbody2D rb;
    public float jumpForce = 100f;
    public float speed = 400f;
    public Animator anim;
    public SpriteRenderer sprite;
    public Collider2D kick;

    public string player;           // Reference to if the character is player1 or player2

    private void Start() {
        if (PlayerPrefs.GetString("Player2tag") == "Åsmund")
            player = "-2";
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"+player)) {
            jump = true;
        }
        horizontal = Input.GetAxis("Horizontal"+ player);
        if (Input.GetButtonDown("Jump"+ player)) {
            jump = true;
        }
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
        anim.SetBool("djump", false);
        // Jumps if double jump is available
        if (jump && airJumped < 2)
        {
          rb.velocity = new Vector2(0, 0); // resets the velocity before each jump
          rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
          if(airJumped== 1)
            {
                anim.SetBool("djump", true);
            }
          airJumped++;
        }
        // flips the animation to face moving direction
        if (horizontal < 0)
        {
            sprite.flipX = true;
            kick.transform.position = new Vector2(kick.transform.position.x - 2.5f, kick.transform.position.y);
        }
        else if (horizontal > 0)
        {
            sprite.flipX = false;
            Debug.Log("");
            kick.transform.position = new Vector2(kick.transform.position.x + 2.5f, kick.transform.position.y);
        }
    }
    // For detecting when on ground and not
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("grounded", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            airJumped = 0;
            anim.SetBool("grounded", true);
        }
    }
}
