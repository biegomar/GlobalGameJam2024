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

    [SerializeField]
    private Animator animator;
    
    private Vector3 actualPosition;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        this.actualPosition = transform.position;
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
        var localSpeed = Input.GetAxis("Horizontal") * this.speed * Time.deltaTime;

        if (localSpeed != 0f)
        {
            Debug.Log($"Speed: {localSpeed}");    
        }
        
        
        this.animator.SetFloat(Speed, localSpeed);
        
        return Math.Clamp(this.actualPosition.x + localSpeed, 
            leftBorderPosition, 
            rightBorderPosition);
    }
}
