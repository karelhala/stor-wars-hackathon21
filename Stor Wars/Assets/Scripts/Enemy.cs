using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private GameObject player;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private GameObject gameDirector;

    public Color bulletColor;

    private string WALK = "WALK";
    private string SHOOTING = "Shooting";

    public float TIME_TO_RELOAD = 5;
    public float MINIMAL_DISTANCE = 5;
    public float SPEED = 0.03f;

    public int score = 10;

    public float timeRemaining = 0;
    private AudioSource audio;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        gameDirector = GameObject.FindGameObjectsWithTag("GameDirector")[0];

        gameDirector.GetComponent<GameDirector>().AddEnemy();
    }

    public void SetStats(float timeToReload, float minimalDistance, float speed, int scoreMultiplier)
    {
        TIME_TO_RELOAD = timeToReload;
        MINIMAL_DISTANCE = minimalDistance;
        SPEED = speed;

        score = scoreMultiplier * score;
    }

    private void OnDestroy()
    {
        gameDirector.GetComponent<GameDirector>().RemoveEnemy(score);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("m"))
        {
            Destroy(gameObject);
        }


        Vector2 pos = transform.position;
        Vector3 playerPos = player.transform.position;

        if(timeRemaining < TIME_TO_RELOAD)
        {
            timeRemaining += Time.deltaTime;
        }

        if (playerPos.x < pos.x)
        {
            sr.flipX = true;
        } else
        {
            sr.flipX = false;
        }

        if(Vector2.Distance(playerPos, pos) > MINIMAL_DISTANCE)
        {
            anim.SetBool(WALK, true);

            transform.position = Vector3.MoveTowards(pos, playerPos, SPEED);
        } else
        {
            anim.SetBool(WALK, false);

            if(timeRemaining >= TIME_TO_RELOAD)
            {
                timeRemaining = 0;
                audio.PlayOneShot(audio.clip);
                anim.Play(SHOOTING);
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector3 playerPos = player.transform.position;
        float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.AngleAxis(angle, Vector3.forward));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        bullet.GetComponent<Bullet>().creator = gameObject;
        bullet.GetComponent<Bullet>().SetColor(bulletColor);

        var normalizedVector = Vector3.Normalize(playerPos - firePoint.position);

        rb.AddForce(normalizedVector * 4f, ForceMode2D.Impulse);
    }
}
