using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject creator;
    private Renderer rend;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(creator.name);
        if (creator.name != collision.transform.name)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            effect.GetComponent<Animation_Auto_Destroy>().SetColor(Color.red);
            // Destroy(effect, 1);
            Destroy(gameObject);
        }
    }

    public void SetColor(Color colorToTurnTo) {
        rend = GetComponent<Renderer>();
        rend.material.color = colorToTurnTo;
    }
}
