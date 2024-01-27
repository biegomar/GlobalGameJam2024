using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPuzzle : MonoBehaviour
{
    [SerializeField] private Transform emptySpace;
    private Camera _camera;
    [SerializeField] private TilesMoves[] tiles;

    private int emptySpaceIndex = 15;

    void Start()
    {
        _camera = Camera.main;
        //Scramblingpuzzles();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)    
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 1.3)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesMoves thisTile = hit.transform.GetComponent<TilesMoves>();
                    emptySpace.position = hit.transform.position;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }
        }
    }

    public void Scramblingpuzzles()
    {
        if (emptySpaceIndex != 15)
        {
            var tileon15LastPos = tiles[15].targetPosition;
            tiles[15].targetPosition = emptySpace.position;
            emptySpace.position = tileon15LastPos;
            tiles[15] = null;
            emptySpaceIndex = 15;
        }

        int invertion;
        do
        {
            for (int i = 0; i <= 14; i++)
            {
                if (tiles[i] != null)
                {
                    var lastpos = tiles[i].targetPosition;
                    int randomIndex = Random.Range(0, 14);
                    tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                    tiles[randomIndex].targetPosition = lastpos;
                    var tile = tiles[i];
                    tiles[i] = tiles[randomIndex];
                    tiles[randomIndex] = tile;
                }
            }
            invertion = GetInversions();
            Debug.Log("Shuffled");
        } while (invertion % 2 != 0);

        int rightTilePos = 0;
        foreach (var a in tiles)
        {
            if (a != null)
            {
                if (a.isInOriginalPos)
                {
                    rightTilePos++;
                }
            }
        }
        if (rightTilePos == tiles.Length - 1)
        {
            Debug.Log("Winner");
        }
    }

    public int findIndex(TilesMoves ts)
    {
        for (int i =0; i<tiles.Length; i++) 
        { 
            if (tiles[i] != null)
            { 
                if (tiles[i] == ts)
                {
                    return i;
                } 
            }
        }
        return -1;
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }
}
