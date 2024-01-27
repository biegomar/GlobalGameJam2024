using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private Stopper stopper;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
    }

    private void Update()
    {
        if(this.transform.position.x <= -8)
        {
            stopper.TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
