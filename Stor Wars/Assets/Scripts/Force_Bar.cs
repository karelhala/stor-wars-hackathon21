using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Force_Bar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxForce(int force)
    {
        slider.maxValue = force;
        slider.value = force;
    }

    public void SetForce(int force)
    {
        slider.value = force;
    }
}
