using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PigeonShitMovementController : MonoBehaviour
{
    [SerializeField] 
    private float pigeonShitDisappearYPosition;
    
    [SerializeField]
    private float pigeonShitSpeed;
    
    private Vector3 actualPosition;
    
    void Start()
    {
        this.actualPosition = transform.position;
    }
    
    void Update()
    {
        this.actualPosition = transform.position;
        if (this.actualPosition.y < pigeonShitDisappearYPosition)
        {
            Destroy(gameObject);
            return;
        }

        MoveVertical();
    }
    
    private void MoveVertical()
    {
        transform.position = new Vector3(
            this.actualPosition.x,
            CalculateNewYPosition(),
            this.actualPosition.z);
    }

    private float CalculateNewYPosition()
    {        
        return this.actualPosition.y - 1f * this.pigeonShitSpeed * Time.deltaTime;
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionObject = collision.gameObject;
        if (collisionObject.CompareTag("Player"))
        {
            GameManager.Instance.ActualArcheryHealth -= 1;

            Destroy(gameObject);
        }
    }
}
