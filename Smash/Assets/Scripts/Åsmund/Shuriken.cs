using UnityEngine;

public class Shuriken : MonoBehaviour {
    private Rigidbody2D rb;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") return;
        if(collision.collider.tag != "Åsmund")
        {
            Destroy(gameObject, 0);
        }
    }
}
