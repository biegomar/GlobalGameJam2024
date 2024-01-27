using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    
    public float PigeonWaveYBaseSpeed = 3f;
    public int ActualArcheryHealth { get => actualArcheryHealth; set => actualArcheryHealth = Math.Max(0,value); }
    public int MaxArcheryHealth = 100;

    public bool CanReturnToKing { get => archeryCompleted && jugglingCompleted && picturepuzzleCompleted; }

    public bool archeryCompleted;
    public bool jugglingCompleted;
    public bool picturepuzzleCompleted;
    private int actualArcheryHealth;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
           Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void Reset()
    {
        archeryCompleted = false;
        jugglingCompleted = false;
        picturepuzzleCompleted = false;
    }
}
