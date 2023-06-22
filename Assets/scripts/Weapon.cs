using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform shotpos;
    public GameObject Bullet;

    float fireElapsedTime = 0;
    public float fireDelay;

    void Update()
    {
        fireElapsedTime += Time.deltaTime;

        //ѕовороты оружи€ при нажатии на стрелочки
        if (Input.GetKey(KeyCode.UpArrow)) this.transform.rotation = Quaternion.Euler(0, 0, 90);
        else if (Input.GetKey(KeyCode.DownArrow)) this.transform.rotation = Quaternion.Euler(0, 0, -90);
        else if (Input.GetKey(KeyCode.LeftArrow)) this.transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (Input.GetKey(KeyCode.RightArrow)) this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && fireElapsedTime >= fireDelay)
        {
            fireElapsedTime = 0;
            Instantiate(Bullet, shotpos.transform.position, transform.rotation);
        }
    }
}