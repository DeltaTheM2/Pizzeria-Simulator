using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{
    private Transform slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = this.transform.Find("Fill Area").Find("Fill");
    }

    // Update is called once per frame
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
