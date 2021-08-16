using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_choose : MonoBehaviour
{

    private SpriteRenderer sr;
    private Vector2 movement;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if(movement.x != 0)
        {
            if(movement.x < 0)
            {
                sr.flipX = true;
            } else
            {
                sr.flipX = false;
            }
        }
    }
}
