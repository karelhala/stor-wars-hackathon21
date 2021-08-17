using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_animation : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;

    private string WALK = "WALK";
    private string WALK_UP = "WALK_UP";
    private string WALK_DOWN = "WALK_DOWN";
    private string SHOOTING = "Shooting";
    private string ATTACK = "Attack";

    private Vector2 movement;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if(movement.x > 0 || movement.x < 0)
        {
            anim.SetBool(WALK, true);
        } else
        {
            anim.SetBool(WALK, false);
        }

        if(movement.y > 0)
        {
            anim.SetBool(WALK_UP, true);
        }
        else
        {
            anim.SetBool(WALK_UP, false);
        }


        if (movement.y < 0)
        {
            anim.SetBool(WALK_DOWN, true);
        }
        else
        {
            anim.SetBool(WALK_DOWN, false);
        }

        if (Input.GetKeyDown("space"))
        {
            anim.Play(SHOOTING);
            anim.Play(ATTACK);
        }
    }
}
