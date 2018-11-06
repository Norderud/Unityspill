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
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Rigidbody2D>().transform.position.x < player.transform.position.x)
            facing = -1;
        else
            facing = 1;
        Debug.Log(facing);

        if (col.tag != "Åsmund")
        {
            switch (col.tag)
            {
                case ("Danay"):
                    col.gameObject.GetComponent<Controller>().enabled = false;
                    col.gameObject.GetComponent<Danay_Input>().enabled = false;
                    col.gameObject.GetComponent<Stats>().TakeDmg(20);
                    break;
                case ("Glenn"):
                    col.gameObject.GetComponent<Movement>().enabled = false;
                    col.gameObject.GetComponent<Stats>().TakeDmg(20);
                    break;
            }
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force * 3 * facing, force * 5
                ));
        }
    }
}
