using UnityEngine;

public class Player_Abilities : MonoBehaviour
{
    public GameObject bullet;
    public Player_Controller player;
    public float speed = 3000f;
    public float cooldown = 1f;

    private float tTime = 0f;
    private int facing = 1;
    private string wPlayer;
    void Start()
    {
        if (PlayerPrefs.GetString("Player2tag") == "Åsmund")
        {
            wPlayer = "-2";
        }
    }
    private void Update()
    {
        player.anim.SetBool("throw", false);
        if (Input.GetButtonDown("Fire1"+wPlayer))
        {
            shoot();
        }
    }
    public void shoot()
    {
        
        if (tTime > Time.time) return;
        if (player.sprite.flipX)
        {
            facing = -1;
        }
        else
        {
            facing = 1;
        }
        player.anim.SetBool("throw", true);
        Vector2 startPos = new Vector2(player.GetComponent<Rigidbody2D>().position.x + (1.5f * facing), player.GetComponent<Rigidbody2D>().position.y);
        Instantiate(bullet, startPos, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * facing, 0));
        tTime = Time.time + cooldown;
    }
}
