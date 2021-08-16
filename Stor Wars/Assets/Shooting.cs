using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Rigidbody2D myBody;

    public float bulletForce = 20f;

    private Vector2 movement;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
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
        GameObject bulltet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bulltet.GetComponent<Rigidbody2D>();

        bulltet.GetComponent<Bullet>().creator = gameObject;
        rb.AddForce(movement.y != 0 ? firePoint.up : firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
