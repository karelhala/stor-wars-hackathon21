using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebelEnemy : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private GameObject player;
    private string WALK = "Walk";
    private string SHOOTING = "Shooting";

    public const float TIME_TO_RELOAD = 5;

    public float timeRemaining = TIME_TO_RELOAD;
    private AudioSource audio;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        Vector3 playerPos = player.transform.position;

        if(timeRemaining < 10)
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

        if(Vector2.Distance(playerPos, pos) > 5)
        {
            anim.SetBool(WALK, true);

            transform.position = Vector3.MoveTowards(pos, playerPos, 0.03f);
        } else
        {
            anim.SetBool(WALK, false);

            if(timeRemaining >= TIME_TO_RELOAD)
            {
                timeRemaining = 0;
                audio.PlayOneShot(audio.clip);
                anim.Play(SHOOTING);
            }
        }
    }
}
