using UnityEngine;

public class EnemyCNTRL2 : MonoBehaviour
{
    private Transform player;
    public Transform Gun;

    public float walkSpeed = 0.05f;
    private bool stayOrWalk;
    public bool flipRight = false;
    public int HP = 3;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        //Проверка ХП
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        if (HP == 2)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f);
        }
        else if (HP == 1)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
        //
        //Проверка на существование игрока
        if (player != null)
        {
            //Ходьба
            if (stayOrWalk == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, walkSpeed);
            }
            //
            //Поворот тела
            if (player.transform.position.x < this.transform.position.x && !flipRight)
            {
                Flip();
            }

            else if (player.transform.position.x > this.transform.position.x && flipRight)
            {
                Flip();
            }
            //
            //Поворот пушки
            Vector3 difference = player.transform.position - transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Gun.transform.rotation = Quaternion.Euler(0f, 0f, (float)(rotation_z));
            //
        }
        //
    }
    private void Flip()
    {
        flipRight = !flipRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet") 
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}
