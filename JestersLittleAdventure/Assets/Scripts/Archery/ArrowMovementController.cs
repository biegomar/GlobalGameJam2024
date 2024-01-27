using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovementController : MonoBehaviour
{
    [SerializeField] 
    private float arrowDisappearYPosition;

    [SerializeField]
    private float arrowSpeed;
    
    private Vector3 actualPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        this.actualPosition = transform.position;
    }
    
    void Update()
    {
        this.actualPosition = transform.position;
        
        if (this.actualPosition.y > arrowDisappearYPosition)
        {
            Destroy(gameObject);
            return;
        }
        
        this.MoveVertical();
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
        return this.actualPosition.y + 1f * this.arrowSpeed * Time.deltaTime;
    }
}
