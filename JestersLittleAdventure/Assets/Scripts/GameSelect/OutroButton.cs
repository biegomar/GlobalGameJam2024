using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroButton : MonoBehaviour
{
    void Start()
    {
        if(GameManager.Instance.archeryCompleted != true||
           GameManager.Instance.jugglingCompleted != true||
           GameManager.Instance.jugglingCompleted != true)
        {
            this.gameObject.SetActive(false);
        }
    }

    void PlayOutro()
    {
        SceneManager.LoadScene(6);
    }
}
