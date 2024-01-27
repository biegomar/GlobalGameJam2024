using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonShitController : MonoBehaviour
{
    [SerializeField]
    private GameObject PigeonShitTemplate;
    
    private float fireInterval;
    private float elapsedTimeSinceLastShot;
    private Vector3 actualPosition;

    void Start()
    {
        this.actualPosition = transform.position;
        this.fireInterval = Random.Range(2f, 6f);
        this.elapsedTimeSinceLastShot = this.fireInterval - (this.fireInterval * .5f);
        //this.laserSound.enabled = true;
    }

    private void Update()
    {
        this.actualPosition = transform.position;
        this.elapsedTimeSinceLastShot += Time.deltaTime;
        this.FeuerFrei();          
    }
    
    private void FeuerFrei()
    {
        if (this.elapsedTimeSinceLastShot >= this.fireInterval)
        {
            //this.laserSound.Play();

            Instantiate(PigeonShitTemplate, new Vector3(
                this.actualPosition.x,
                this.actualPosition.y - 0.3f,
                PigeonShitTemplate.transform.position.z), Quaternion.identity);
            
            this.elapsedTimeSinceLastShot = 0;
        }
    }
    
}
