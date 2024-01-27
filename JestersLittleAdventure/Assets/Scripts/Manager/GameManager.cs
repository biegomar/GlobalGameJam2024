using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public bool archeryCompleted;
    public bool jugglingCompleted;
    public bool picturepuzzleCompleted;

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
