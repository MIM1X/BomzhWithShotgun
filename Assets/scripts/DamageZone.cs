using System.Collections;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private bool yes;
    public float waitForAtack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        yes = true;
        StartCoroutine(MinusHP(collision));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        yes = false;
    }

    IEnumerator MinusHP(Collider2D collision)
    {
        while (yes == true)
        {
            yield return new WaitForSeconds(waitForAtack);
            if (collision.name == "Player")
            {
                if (yes == true)
                    collision.GetComponent<CharaCONTRL>().TakeDamage(1);
            }
            yield return null;
        }
    }
}