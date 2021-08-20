using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 10;
    public int maxForce = 10;
    public int currentHealth;
    public int currentForce;

    public float period = 5f;

    private HealthBarScript healthBar;
    private Force_Bar forceBar;

    private bool healthRefreshing;
    private bool forcRefreshing;

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
        forceBar = GameObject.FindWithTag("ForceBar").GetComponent<Force_Bar>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentForce = maxForce;
        forceBar.SetMaxForce(maxForce);

        InvokeRepeating("Refreshing", 0f, 1f);
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

            if(GetComponent<SpriteRenderer>().flipX)
            {
                hit.transform.localScale = new Vector3(hit.transform.localScale.x * -1, hit.transform.localScale.y, hit.transform.localScale.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            currentForce -= 1;
            forceBar.SetForce(currentForce);
        }
    }

    void Refreshing()
    {
        if (healthRefreshing && currentHealth < maxHealth)
        {
            currentHealth += 1;
            healthBar.SetHealth(currentHealth);
        }
        if (forcRefreshing && currentForce < maxForce)
        {
            currentForce += 1;
            forceBar.SetForce(currentForce);
        }
    }

    private void FixedUpdate()
    {

        myBody.MovePosition(myBody.position + movement * speed * Time.fixedDeltaTime);
    }

    private void TakeHit()
    {
        currentHealth -= 2;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Bullet>() &&
            transform.name != collision.transform.GetComponent<Bullet>().creator.name
            )
        {
            TakeHit();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Health")
        {
            healthRefreshing = true;
        }
        else if (collision.transform.name == "Force")
        {
            forcRefreshing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        healthRefreshing = false;
        forcRefreshing = false;
    }
}
