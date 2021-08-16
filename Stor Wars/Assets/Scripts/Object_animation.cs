using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_animation : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;

    private string WALK_RIGHT = "WalkRight";
    private string WALK_UP = "WalkUp";
    private string WALK_DOWN = "WalkDown";
    private string SHOOTING = "Shooting";

    private Vector2 movement;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if(movement.x > 0 || movement.x < 0)
        {
            anim.SetBool(WALK_RIGHT, true);
        } else
        {
            anim.SetBool(WALK_RIGHT, false);
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
        }
    }
}
