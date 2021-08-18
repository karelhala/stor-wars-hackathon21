using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 10;
    public int currentHealth;

    private HealthBarScript healthBar;

    private Rigidbody2D myBody;
    public AudioSource saberSwing;
    public AudioSource saberHit;
    public GameObject saberPrefab;
    public Color color;

    private Vector2 movement;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        healthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBarScript>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space"))
        {
            saberSwing.PlayOneShot(saberSwing.clip);
            GameObject hit = Instantiate(saberPrefab, myBody.position, Quaternion.identity);
            hit.GetComponent<Saber_Hit>().creator = gameObject;
            hit.GetComponent<Saber_Hit>().SetColor(color);
        }

    }

    private void FixedUpdate()
    {

        myBody.MovePosition(myBody.position + movement * speed * Time.fixedDeltaTime);
    }

    private void TakeHit()
    {
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.GetComponent<Bullet>() + " this is bulet! " + transform.name + "  " + collision.transform.GetComponent<Bullet>().creator.name);
        if (collision.transform.GetComponent<Bullet>() &&
            transform.name != collision.transform.GetComponent<Bullet>().creator.name
            )
        {
            TakeHit();
        }
    }
}
