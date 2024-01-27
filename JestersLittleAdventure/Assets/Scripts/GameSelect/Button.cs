using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Button : MonoBehaviour
{ 
    private bool finished;

    private void Start()
    {
        if(this.tag == "Archery")
        {
            finished = GameManager.Instance.archeryCompleted;
        }
        else if (this.tag == "Juggling")
        {
            finished = GameManager.Instance.jugglingCompleted;
        }
        else if (this.tag == "PicturePuzzle")
        {
            finished = GameManager.Instance.picturepuzzleCompleted;
        }

        if (finished == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void LoadMinigame(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }
}
