using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stopper : MonoBehaviour
{
    [SerializeField] private LayerMask noteLayer;
    [SerializeField] public int hp;
    [SerializeField] TMP_Text text;

    public void Start()
    {
       text.text = "Current HP: " + hp;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Collider2D note = Physics2D.OverlapBox(this.transform.position, new Vector2(0.3f, 2), 0, noteLayer);

            if(note == null)
            {
                TakeDamage();
            }
            else
            {
                Destroy(note.gameObject);
            }
        }
    }

    public void TakeDamage()
    {
        hp -= 1;
        text.text = "Current HP: " + hp;
    }
}
