using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myBody;
    private AudioSource audio;
    private AudioClip blasterFire;

    private Vector2 movement;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

        blasterFire = Resources.Load("Sounds/blaster") as AudioClip;
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space"))
        {
            audio.PlayOneShot(audio.clip);
        }
    }

    private void FixedUpdate()
    {

        myBody.MovePosition(myBody.position + movement * speed * Time.fixedDeltaTime);
    }
}
