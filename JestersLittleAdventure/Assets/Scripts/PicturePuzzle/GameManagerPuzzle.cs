using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPuzzle : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TilesMoves[] tiles;

    void Start()
    {
        _camera = Camera.main;
        Scramblingpuzzles();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)    
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 1.5)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesMoves thisTile = hit.transform.GetComponent<TilesMoves>();
                    emptySpace.position = hit.transform.position;
                    hit.transform.position = lastEmptySpacePosition;
                }
            }
        }
    }

    public void Scramblingpuzzles()
    {
        for (int i = 0; i < 14; i++) 
        {
            if (tiles[i] != null)
            {
                var lastpos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 14);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastpos;
            }
        }
    }
}
