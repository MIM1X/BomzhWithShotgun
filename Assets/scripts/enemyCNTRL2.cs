using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCNTRL2 : MonoBehaviour
{
    private Transform player;
    public Transform Gun;

    public float walkSpeed = 0.05f;
    private bool stayOrWalk;
    public bool flipRight = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
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
    private void Flip()
    {
        flipRight = !flipRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
