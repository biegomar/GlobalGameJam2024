using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField] TMP_Text nextText;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            nextText.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
