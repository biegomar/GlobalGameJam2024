using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float leftBorderPosition;
    
    [SerializeField]
    private float rightBorderPosition;

    private Rigidbody2D Rigidbody;
    private Vector3 actualPosition;

    private void Start()
    {
        this.actualPosition = transform.position;
        this.Rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        this.actualPosition = transform.position;
        this.MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        transform.position = new Vector3(
            CalculateNewXPosition(),
            this.actualPosition.y,
            this.actualPosition.z);
    }

    private float CalculateNewXPosition()
    {        
        return Math.Clamp(this.actualPosition.x + Input.GetAxis("Horizontal") * this.speed * Time.deltaTime, 
            leftBorderPosition, 
            rightBorderPosition);
    }
}
