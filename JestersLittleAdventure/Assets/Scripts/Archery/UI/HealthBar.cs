using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    private void Start()
    {
        this.slider.maxValue = GameManager.Instance.MaxArcheryHealth;
        GameManager.Instance.ActualArcheryHealth = GameManager.Instance.MaxArcheryHealth;
    }
    
    public void SetHealth()
    {
        slider.value = GameManager.Instance.ActualArcheryHealth;
    }
}
