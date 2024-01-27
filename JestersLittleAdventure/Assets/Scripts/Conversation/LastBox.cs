using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastBox : MonoBehaviour
{
    [SerializeField] int scene;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
