using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonShitController : MonoBehaviour
{
    [SerializeField]
    private GameObject PigeonShitTemplate;
    
    private float fireInterval;
    private float rayCastInterval;
    private float elapsedTimeSinceLastShot;
    private float elapsedTimeSinceLastRayCastHit;
    private Vector3 actualPosition;
    private const float rayLength = 9.7f;
    private RaycastHit2D rayHit;

    void Start()
    {
        this.actualPosition = transform.position;
        this.fireInterval = Random.Range(2f, 6f);
        this.rayCastInterval = 2.0f;
        this.elapsedTimeSinceLastShot = this.fireInterval - (this.fireInterval * .5f);
        this.elapsedTimeSinceLastRayCastHit = .5f;
        //this.laserSound.enabled = true;
    }

    private void Update()
    {
        this.actualPosition = transform.position;
        this.elapsedTimeSinceLastShot += Time.deltaTime;
        this.elapsedTimeSinceLastRayCastHit += Time.deltaTime;
        this.FeuerFrei();          
    }
    
    private void FeuerFrei()
    {
        this.rayHit = Physics2D.Raycast(this.actualPosition + Vector3.down * .3f, Vector3.down, rayLength);
        
        if (this.elapsedTimeSinceLastShot >= this.fireInterval || IsRayCastHit())
        {
            //this.laserSound.Play();

            Instantiate(PigeonShitTemplate, new Vector3(
                this.actualPosition.x,
                this.actualPosition.y - 0.3f,
                PigeonShitTemplate.transform.position.z), Quaternion.identity);
            
            this.elapsedTimeSinceLastShot = 0;
        }
        
    }
    
    private bool IsRayCastHit()
    {
        if (this.rayHit.collider != null && this.rayHit.collider.gameObject.CompareTag("Player") 
                                         && this.elapsedTimeSinceLastRayCastHit >= this.rayCastInterval)
        {
            this.elapsedTimeSinceLastRayCastHit = 0;
            return true;
        }

        return false;
    }
    
}
