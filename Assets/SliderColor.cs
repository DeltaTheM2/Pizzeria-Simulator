using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{
    public Transform slider;
    public void UpdateColor()
    {
        if(this.GetComponent<Slider>().value < 70)
        {
            slider.GetComponent<Image>().color = Color.yellow;
        }
       else if(this.GetComponent<Slider>().value < 30)
        {
            slider.GetComponent <Image>().color = Color.red;
        }
        else
        {
            slider.GetComponent<Image>().color = Color.white;
        }
    }
}
