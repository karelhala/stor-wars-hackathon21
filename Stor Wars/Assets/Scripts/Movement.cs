using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 10;
    public int currentHealth;

    public HeathBarScript heathBar;

    private Rigidbody2D myBody;
    private AudioSource audio;
    private AudioClip blasterFire;

    private Vector2 movement;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

        blasterFire = Resources.Load("Sounds/blaster") as AudioClip;

        currentHealth = maxHealth;
        heathBar.SetMaxHealth(maxHealth);
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

    private void TakeHit()
    {
        currentHealth -= 1;
        heathBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.GetComponent<Bullet>());
        if (collision.transform.GetComponent<Bullet>() &&
            transform.name != collision.transform.GetComponent<Bullet>().creator.name
            )
        {
            TakeHit();
        }
    }
}
