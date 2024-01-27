using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    protected Rigidbody2D rigidbody;
    [SerializeField] protected float speed;

    protected void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
    }

    protected void Update()
    {
        if(this.transform.position.x <= -8)
        {
            GameManager.Instance.JugglerTakeDamage();
            Destroy(this.gameObject);
        }
    }
}
