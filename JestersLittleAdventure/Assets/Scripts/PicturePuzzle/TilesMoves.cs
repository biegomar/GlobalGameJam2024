using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TilesMoves : MonoBehaviour
{ 
    public Vector3 targetPosition;
    private Vector3 OriginalPosition;
    public bool isInOriginalPos;
    public int number;
 
    // Start is called before the first frame update
    void Awake()
    {
    targetPosition = transform.position;
    OriginalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        if (targetPosition == OriginalPosition)
        {
            //Debug.Log("yay"); //the debug is spamming...
            isInOriginalPos = true;
        }
        else
        {
            //checkwin = false;
            isInOriginalPos = false;
        }
    }
}
