using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    private float remainingTime = 10;

    void Update()
    {

        remainingTime -= Time.deltaTime;

        if(remainingTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
