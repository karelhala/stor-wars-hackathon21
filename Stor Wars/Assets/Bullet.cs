using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject creator;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(creator.name);
        if (creator.name != collision.transform.name)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            // Destroy(effect, 1);
            Destroy(gameObject);
        }
    }
}
