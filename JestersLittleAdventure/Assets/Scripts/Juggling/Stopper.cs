using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    [SerializeField] private LayerMask noteLayer;
    [SerializeField] AudioSource fail;
    [SerializeField] Juggler juggler;


    void Update()
    {
        Collider2D note = Physics2D.OverlapBox(this.transform.position, new Vector2(0.3f, 2), 0, noteLayer);

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if(note == null || note.gameObject.layer != 6)
            {
                juggler.JugglerTakeDamage();
                fail.Play();
            }
            else
            {
                Destroy(note.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (note == null || note.gameObject.layer != 7)
            {
                juggler.JugglerTakeDamage();
                fail.Play();
            }
            else
            {
                Destroy(note.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (note == null || note.gameObject.layer != 8)
            {
                juggler.JugglerTakeDamage();
                fail.Play();
            }
            else
            {
                Destroy(note.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (note == null || note.gameObject.layer != 9)
            {
                juggler.JugglerTakeDamage();
                fail.Play();
            }
            else
            {
                Destroy(note.gameObject);
            }
        }
    }
}
