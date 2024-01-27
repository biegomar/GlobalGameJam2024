using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public bool archeryCompleted = false;
    public bool jugglingCompleted = false;
    public bool picturepuzzleCompleted = false;

    private int JugglerHp;

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

    public void SetJugglerHp(int hp)
    {
        JugglerHp = hp;
    }

    public void JugglerTakeDamage()
    {
        JugglerHp -= 1;
        if (JugglerHp <= 0)
        {
            Time.timeScale = 0;
        }
    }

    public int GetJugglerHp()
    {
        return JugglerHp;
    }
}
