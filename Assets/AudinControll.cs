using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudinControll : MonoBehaviour
{
    public Slider slider;
    public Slider slider_2;
    public AudioListener AudioListener;
    public void controllLisener()
    {
        slider_2.value = slider.value;
        slider.value = slider_2.value;
        if (slider.value == slider.maxValue) AudioListener.enabled = true;
        else AudioListener.enabled = false;

    }
}
