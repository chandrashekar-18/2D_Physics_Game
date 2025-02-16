using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController playerHealth;
    public Image fillImage;
    private Slider _slider;
    //private int _maxHealth = 5;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if(_slider.value<=_slider.minValue)
        {
            fillImage.enabled = false;
        }
        if(_slider.value>_slider.minValue && fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillvalue = playerHealth._health / 5;
        if(fillvalue<=_slider.maxValue/3)
        {
            fillImage.color = Color.white;
        }
        else if (fillvalue > _slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }
        _slider.value = fillvalue;
    }
}
