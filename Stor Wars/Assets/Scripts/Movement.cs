using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private AudioSource audio;
    private AudioClip blasterFire;

    private string WALK_RIGHT = "WalkRight";
    private string WALK_UP = "WalkUp";
    private string WALK_DOWN = "WalkDown";
    private string SHOOTING = "Shooting";

    void Start()
    {

        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        blasterFire = Resources.Load("Sounds/blaster") as AudioClip;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;

        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        if(h > 0 || h < 0)
        {
            anim.SetBool(WALK_RIGHT, true);
            if(h < 0)
            {
                sr.flipX = true;
            } else
            {
                sr.flipX = false;
            }
        } else
        {
            anim.SetBool(WALK_RIGHT, false);
        }

        if(v > 0)
        {
            anim.SetBool(WALK_UP, true);
        }
        else
        {
            anim.SetBool(WALK_UP, false);
        }


        if (v < 0)
        {
            anim.SetBool(WALK_DOWN, true);
        }
        else
        {
            anim.SetBool(WALK_DOWN, false);
        }

        transform.position = pos;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            audio.PlayOneShot(audio.clip);
            anim.Play(SHOOTING);
        }
    }
}
