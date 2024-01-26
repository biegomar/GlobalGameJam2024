using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int Speed;

    [SerializeField]
    private float Velocity;

    private Rigidbody2D Rigidbody;
    private Vector3 actualPosition;

    private void Start()
    {
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
        return this.actualPosition.x + Input.GetAxis("Horizontal") * this.Speed * Time.deltaTime;
    }
}
