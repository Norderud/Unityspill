using UnityEngine;

public class Kick : MonoBehaviour {
    public Collider2D col;
    public float attackDuration;
    public int force;

    private bool dir = true;
    private float attackStart;
    private int facing;

    private void Start()
    {
        col.enabled = false;
    }
    private void Update()
    {
        if (Time.time - attackStart > attackDuration)
            col.enabled = false;
    }
    internal void kick()
    {
        attackStart = Time.time;
        col.enabled = true;

    }
    public void moveCollider(int facing)
    {
        this.facing = facing;
        if (facing > 0)
        {
            if (!dir)
            {
                col.transform.position = new Vector2(col.transform.position.x + 2.5f, col.transform.position.y);
                dir = true;
            }
        }
        else
        {
            if (dir)
            {
                col.transform.position = new Vector2(col.transform.position.x - 2.5f, col.transform.position.y);
                dir = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Åsmund")
        {
            switch (collision.collider.tag)
            {
                case ("Danay"):
                    collision.collider.gameObject.GetComponent<Controller>().enabled = false;
                    collision.collider.gameObject.GetComponent<Danay_Input>().enabled = false;
                    collision.collider.gameObject.GetComponent<Stats>().TakeDmg(10);
                    break;
                case ("Glenn"):
                    collision.collider.gameObject.GetComponent<Movement>().enabled = false;
                    collision.collider.gameObject.GetComponent<Stats>().TakeDmg(10);
                    break;
            }
            collision.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force * facing, force * 10));
        }
    }
}
