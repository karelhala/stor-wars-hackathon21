using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipAsParent : MonoBehaviour
{
    private GameObject obj;
    private SpriteRenderer parRend;
    private float originalX;

    // Start is called before the first frame update
    void Start()
    {
        obj = transform.parent.gameObject;
        parRend = obj.GetComponent<SpriteRenderer>();
        originalX = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(
            parRend.flipX ? transform.parent.position.x - originalX : transform.parent.position.x + originalX, transform.position.y, transform.position.z);
    }
}
