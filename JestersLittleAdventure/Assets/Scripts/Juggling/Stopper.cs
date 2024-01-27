using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    [SerializeField] private LayerMask noteLayer;
    [SerializeField] public int hp;
    [SerializeField] AudioSource fail;
    [SerializeField] Juggler juggler;


    void Update()
    {
        Collider2D note = Physics2D.OverlapBox(this.transform.position, new Vector2(0.3f, 2), 0, noteLayer);

        if (Input.GetKeyDown("up"))
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

        if (Input.GetKeyDown("down"))
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

        if (Input.GetKeyDown("left"))
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

        if (Input.GetKeyDown("right"))
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
