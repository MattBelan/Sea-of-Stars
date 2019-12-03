using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    public Slider slider;

    private float val;

    public float Val
    {
        get { return val; }
        set
        {
            val = value;
            slider.value = val;
        }   
    }
    
    // Start is called before the first frame update
    void Start()
    {
        val = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
