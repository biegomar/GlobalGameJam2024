using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FireController : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;

    [SerializeField] 
    private float arrowFrequency;
    
    [SerializeField]
    private float arrowOffsetFromPlayer;
    
    private float actualArrowInterval;
    private Vector3 actualTransformPosition;

    private void Start()
    {
        this.actualArrowInterval = 0;
    }

    private void Update()
    {
        this.actualArrowInterval += Time.deltaTime;
        this.actualTransformPosition = transform.position;
        
        this.FeuerFrei();
    }

    private void FeuerFrei()
    {
        if (this.actualArrowInterval >= this.arrowFrequency && this.IsFirePressed())
        {

            Instantiate(arrow, new Vector3(
                this.actualTransformPosition.x,
                this.actualTransformPosition.y + arrowOffsetFromPlayer,
                this.actualTransformPosition.z), Quaternion.identity);            
            
            this.actualArrowInterval = 0;                
        }
    }
    
    private bool IsFirePressed()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
    }
}
