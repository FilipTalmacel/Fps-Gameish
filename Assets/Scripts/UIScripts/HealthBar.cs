using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Text healthNumber;

    private void Update()
    {
        healthNumber.text = (healthSlider.value + "/" + healthSlider.maxValue).ToString();
    }
    public void SliderMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
    }
    public void SliderCurrentHealth(int health)
    {
        healthSlider.value = health;
    }
}
