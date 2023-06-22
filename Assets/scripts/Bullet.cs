using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public LayerMask whatIsSolid;
    public float distance;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyCNTRL>().TakeDamage(1);
            }
            else if (hitInfo.collider.CompareTag("Enemy2"))
            {
                hitInfo.collider.GetComponent<EnemyCNTRL2>().TakeDamage(1);
            }
            Destroy(gameObject);
        }
        Destroy(gameObject, destroyTime);
    }
}