using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Button : MonoBehaviour
{
    public void LoadMinigame(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }
}
