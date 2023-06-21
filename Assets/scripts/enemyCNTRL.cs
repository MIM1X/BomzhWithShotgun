using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCNTRL : MonoBehaviour
{
    public float coolDownTime = 2;
    private float nextTime = 0;
    public float walkSpeed = 1f;
    public bool flipRight = false;
    private bool stayOrWalk;
    private int countBullets = 50;
    public int HP = 3;

    private Transform player;
    public Transform Gun;
    public Transform shotpos;
    public GameObject Bullet;

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
            Gun.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
            //
        }
        //
        //Кол-во выстрелов и потом кулдаун
        if (Time.time > nextTime)
        {
            if (countBullets > 0)
            {
                    Instantiate(Bullet, shotpos.transform.position, Gun.transform.rotation);
                    countBullets--;
            }
            else 
            {
                nextTime = Time.time + coolDownTime;
                countBullets += 50;
            } 
        }
        //
    }

    private void Flip()
    {
        flipRight = !flipRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") stayOrWalk = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player") stayOrWalk = false;
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}