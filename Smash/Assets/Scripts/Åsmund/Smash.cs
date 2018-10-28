using UnityEngine;

public class Smash : MonoBehaviour {
    public Collider2D col;
    public float smashDuration;
    public Player_Controller player;
    public int force;

    private float smashStart;
    private int facing;

    // Use this for initialization
    void Start () {
        col.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - smashStart > smashDuration)
            col.enabled = false;
        smash();
	}
    public void smash()
    {
        if (!player.inAir && player.isSmashing)
        {
            smashStart = Time.time;
            col.enabled = true;
            player.isSmashing = false;
        }
        //Destroy(Instantiate(smash_ground, gameObject.transform.position, Quaternion.identity), 1f);

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Rigidbody2D>().transform.position.x < player.transform.position.x)
            facing = -1;
        else
            facing = 1;
        Debug.Log(facing);

        if (collision.collider.tag != "Åsmund")
        {
            switch (collision.collider.tag)
            {
                case ("Danay"):
                    collision.collider.gameObject.GetComponent<Controller>().enabled = false;
                    collision.collider.gameObject.GetComponent<Danay_Input>().enabled = false;
                    collision.collider.gameObject.GetComponent<Stats>().TakeDmg(20);
                    break;
                case ("Glenn"):
                    collision.collider.gameObject.GetComponent<Movement>().enabled = false;
                    collision.collider.gameObject.GetComponent<Stats>().TakeDmg(20);
                    break;
            }
            collision.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force * facing, force * 5
                ));
        }
    }
}
