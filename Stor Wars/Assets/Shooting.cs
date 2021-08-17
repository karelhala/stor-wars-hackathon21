using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;

    public float bulletForce = 20f;

    private Vector2 movement;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if(Input.GetKeyDown("space"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.AngleAxis(angle, Vector3.forward));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        bullet.GetComponent<Bullet>().creator = gameObject;
        bullet.GetComponent<Bullet>().SetColor(Color.red);

        if (sr.flipX)
        {
            rb.AddForce(movement.y != 0 ? firePoint.up : firePoint.right * (-1 * bulletForce), ForceMode2D.Impulse);
        } else {
            rb.AddForce(movement.y != 0 ? firePoint.up : firePoint.right * (1 * bulletForce), ForceMode2D.Impulse);
        }
    }
}
