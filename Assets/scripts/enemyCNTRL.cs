using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCNTRL : MonoBehaviour
{

    public float walkSpeed = 1f;
    public bool flipRight = false;
    private bool stayOrWalk;

    public Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (stayOrWalk == false) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, walkSpeed);
        }

        if (player.transform.position.x < this.transform.position.x && !flipRight)
        {
            Flip();
        }

        else if (player.transform.position.x > this.transform.position.x && flipRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        flipRight = !flipRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stayOrWalk = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        stayOrWalk = false;
    }
}