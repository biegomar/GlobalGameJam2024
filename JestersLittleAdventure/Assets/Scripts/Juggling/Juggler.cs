using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Juggler : MonoBehaviour
{
    [SerializeField] private int jugglerHp;
    [SerializeField] TMP_Text text;

    public void Start()
    {
        text.text = "Current HP: " + jugglerHp;
    }

    public void JugglerTakeDamage()
    {
        jugglerHp -= 1;
        text.text = "Current HP: " + jugglerHp;
        if (jugglerHp <= 0)
        {
            SceneManager.LoadScene(7);
        }
    }

    public int GetJugglerHp()
    {
        return jugglerHp;
    }
}
