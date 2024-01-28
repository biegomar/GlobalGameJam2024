using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private GameObject toDisable;
    [SerializeField] private GameObject toEnable;
    [SerializeField] private int textBoxesLeft;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            textBoxesLeft -= 1;
        }

        if(textBoxesLeft <= 0)
        {
            toDisable.SetActive(false);
            toEnable.SetActive(true);
        }
    }
}
