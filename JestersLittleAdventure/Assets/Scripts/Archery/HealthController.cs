using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;

    private void Update()
    {
        this.healthBar.SetHealth();
        
        if (GameManager.Instance.ActualArcheryHealth <= 0)
        {
            SceneManager.LoadScene(7);
        }
    }
}
