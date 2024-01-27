using System;
using System.Collections;
using System.Collections.Generic;
using Archery.Pigeons;
using UnityEngine;

public class PigeonWaveMovementController : MonoBehaviour
{
    private PigeonSpawnController enemyController;
    private PigeonItem pigeonItem;
    private IMovementStrategy activeMovementStrategy;

    private void Start()
    {
        GameObject go = GameObject.Find("Pigeons");
        if (go != null)
        {
            this.enemyController = go.GetComponent<PigeonSpawnController>();
            if (this.enemyController != null)
            {
                this.pigeonItem = this.enemyController.Pigeons[gameObject.GetInstanceID()];
            }
            else
            {
                Debug.Log("go.GetComponent<PigeonSpawnController>() is null");
            }
        }
        else
        {
            Debug.Log("GameObject.Find(Enemies) is null");
        }
        
        this.activeMovementStrategy = new XPingPongLerpMovement(this.pigeonItem.StartPosition);
    }
    
    private void Update()
    {
        transform.position = new Vector3(
            CalculateNewXPosition(),
            CalculateNewYPosition(),
            transform.position.z);

        TryToSwitchToXPingPongMovement();
    }
    
    private float CalculateNewXPosition()
    {
        return this.activeMovementStrategy.CalculateNewXPosition(gameObject);        
    }

    private float CalculateNewYPosition()
    {        
        return this.activeMovementStrategy.CalculateNewYPosition(gameObject);
    }
    
    private void TryToSwitchToXPingPongMovement()
    {
        if (this.activeMovementStrategy.GetType() != typeof(XPingPongMovement))
        {
            if (Math.Abs(transform.position.x - this.pigeonItem.StartPosition.x) < 0.03f)
            {
                this.activeMovementStrategy = new XPingPongMovement(this.pigeonItem.StartPosition);
            } 
        }
    }
}
