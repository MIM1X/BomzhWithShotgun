using UnityEngine;
using UnityEngine.UI;

public class CharaCONTRL : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public Text staminaText;
    public Camera cam;

    private bool godMod = false;
    public float timeGodMod;
    public float coolDownTime = 3;
    private float nextTime = 0;
    private float nextTimee = 0;
    public float runSpeed = 5f;
    public float superRunSpeed = 20f;
    private float runSP;
    public bool flipRight = true;
    public int HP = 3;
    public int HowFastDeleteStamina;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        runSP = runSpeed;
    }

    private void FixedUpdate()
    {
        //�������� ��
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        else if (HP == 3 && godMod == false)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
        else if (HP == 2 && godMod == false)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f);
        }
        else if (HP == 1 && godMod == false)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
        //
        if (Time.time > nextTimee)
        {
            godMod = false;
        }
        Move();
    }

    private void Move()
    {
        int zaza = int.Parse(staminaText.text);
        //���
        if (Time.time > nextTime)
        {
            if (Input.GetKey(KeyCode.LeftShift) && zaza > 0)
            {
                runSpeed = superRunSpeed;
                zaza -= HowFastDeleteStamina;
            }
            else
            {
                if (zaza <= 0)
                {
                    nextTime = Time.time + coolDownTime;
                }
                runSpeed = runSP;
            }
        }
        if (zaza < 100) zaza++;
        //
        staminaText.text = zaza.ToString();
        //������
        rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, Input.GetAxisRaw("Vertical") * runSpeed);
        //

        //�������� ���� � ����������� ������
        if (Input.GetAxis("Horizontal") > 0 && !flipRight)
        {
            Flip();
        }

        else if (Input.GetAxis("Horizontal") < 0 && flipRight)
        {
            Flip();
        }
        //
    }
    private void Flip()
    {
        flipRight = !flipRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void TakeDamage(int damage)
    {
        if (Time.time > nextTimee)
        {
            HP -= damage;
            godMod = true;
            this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
            nextTimee = Time.time + timeGodMod;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Dleft")
        {
            transform.position -= new Vector3(3f, 0, 0);
            cam.transform.position -= new Vector3(18f, 0, 0);
        }
        else if (collision.name == "Dright")
        {
            transform.position += new Vector3(3f, 0, 0);
            cam.transform.position += new Vector3(18f, 0, 0);
        }
        else if (collision.name == "Dup")
        {
            transform.position += new Vector3(0, 4.4f, 0);
            cam.transform.position += new Vector3(0, 10, 0);
        }
        else if (collision.name == "Ddown")
        {
            transform.position -= new Vector3(0, 4.4f, 0);
            cam.transform.position -= new Vector3(0, 10, 0);
        }
    }
}
