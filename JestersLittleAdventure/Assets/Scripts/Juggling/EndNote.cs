using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndNote : Note
{
    private void OnDestroy()
    {
        if(GameManager.Instance.GetJugglerHp() > 0)
        {
            GameManager.Instance.jugglingCompleted = true;
            SceneManager.LoadScene(1);
        }  
    }
}
