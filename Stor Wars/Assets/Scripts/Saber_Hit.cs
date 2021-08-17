using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber_Hit : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject creator;
    private Renderer rend;
    private Color color;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (creator && creator.name != collision.transform.name)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            effect.GetComponent<Animation_Auto_Destroy>().SetColor(this.color);
        }
        Destroy(gameObject);
    }

    public void SetColor(Color colorToTurnTo) {
        this.color = colorToTurnTo;
    }
}
