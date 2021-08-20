using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject creator;
    private Renderer rend;
    private Color color;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform && creator.name != collision.transform.name)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            effect.GetComponent<Animation_Auto_Destroy>().SetColor(this.color);
            // Destroy(effect, 1);
            if(collision.transform.CompareTag("Enemy"))
            {
                Destroy(collision.transform.gameObject);
            }
            Destroy(gameObject);
        }
    }

    public void SetColor(Color colorToTurnTo) {
        this.color = colorToTurnTo;
        if (rend) {
            rend = GetComponent<Renderer>();
            rend.material.color = colorToTurnTo;
        }
    }
}
