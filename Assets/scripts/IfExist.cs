using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfExist : MonoBehaviour
{
    public GameObject Dleft;
    public GameObject Dright;
    public GameObject Dup;
    public GameObject Ddown;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Enemy2")
        {
            if (Dleft != null)
                Dleft.SetActive(false);
            else if (Dright != null)
                Dright.SetActive(false);
            else if (Ddown != null)
                Ddown.SetActive(false);
            else if (Dup != null)
                Dup.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Enemy2")
        {
            if (Dleft != null)
                Dleft.SetActive(true);
            else if (Dright != null)
                Dright.SetActive(true);
            else if (Ddown != null)
                Ddown.SetActive(true);
            else if (Dup != null)
                Dup.SetActive(true);
        }
    }
}
