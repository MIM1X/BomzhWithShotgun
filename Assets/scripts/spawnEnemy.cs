using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    public float x1;
    public float y1;
    public float x2;
    public float y2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (enemy1 != null)
            {
                Vector2 pos1 = new(x1, y1);
                GameObject gm1 = Instantiate(enemy1, pos1, Quaternion.identity) as GameObject;
                Instantiate(gm1);
            }
            else if (enemy2 != null)
            {
                Vector2 pos2 = new(x2, y2);
                GameObject gm2 = Instantiate(enemy2, pos2, Quaternion.identity) as GameObject;
                Instantiate(gm2);
            }
            Destroy(gameObject);
        }
    }
}
