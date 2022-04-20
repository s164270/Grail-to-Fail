using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    //GameObject slider;
    Slider slider;

    public void initHealthBar(int maxHealth, int currentHealth)
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    public void updateBar(int currentHealth)
    {
        slider.value = currentHealth;
    }

}
