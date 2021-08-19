using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public static string heroName;

    private Transform player;

    private Vector3 tempPos;
    public GameObject lukeHero;
    public GameObject darthVaderHero;

    [SerializeField]
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 zeroLoc;
        zeroLoc.x = 0;
        zeroLoc.y = 0;
        player = Instantiate(heroName == "Vader" ? darthVaderHero : lukeHero, zeroLoc, Quaternion.identity).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;

        if (tempPos.x < minX){
            tempPos.x = minX;
        }

        if (tempPos.x > maxX) {
            tempPos.x = maxX;
        }

        if (tempPos.y < minY){
            tempPos.y = minY;
        }

        if (tempPos.y > maxY) {
            tempPos.y = maxY;
        }

        transform.position = tempPos;
    }
}
