using UnityEngine;

public class Shuriken : MonoBehaviour {
    private Rigidbody2D rb;

    public Animator anim;
    public GameObject blood;

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
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Shuriken" || collision.collider.tag == "Åsmund") return;
        switch (collision.collider.tag)
        {
            case ("Danay"):
                collision.collider.gameObject.GetComponent<Stats>().TakeDmg(5);
                break;
            case ("Glenn"):
                collision.collider.gameObject.GetComponent<Stats>().TakeDmg(5);
                break;
        }
        Destroy(Instantiate(blood, gameObject.transform.position, Quaternion.identity), 1f);
        Destroy(gameObject, 0);
       
    }
}
