using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour
{
    public Sprite[] spriteMassive;

    void Start()
    {
        int rnd = Random.Range(0, spriteMassive.Length);
        GetComponent<Image>().sprite = spriteMassive[rnd];
    }
}
