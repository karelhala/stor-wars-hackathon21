using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Auto_Destroy : MonoBehaviour
{
    public float delay = 0f;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
    }

    public void SetColor(Color colorToTurnTo)
    {
        rend = GetComponent<Renderer>();
        rend.material.color = colorToTurnTo;
    }
}
