using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameManagerPuzzle : MonoBehaviour
{
    //HEHE STUFFTRANSFORM
    [SerializeField] private Transform stuffTransform;
    [SerializeField] private Transform PrefabPieces;

    private int emptySpace;
    private int size;

    void Start()
    {
        size = 4;
        createPuzzlePiece(0.1f);
    }

     void Update()
    {
        
    }

    private void createPuzzlePiece(float gapboarder)
    {
        float width = 1 / (float)size;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++) 
            {
                Transform puzzlePiece = Instantiate(PrefabPieces, stuffTransform);

                puzzlePiece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                                                        +1 - (2 * width * row) - width, 0);
                puzzlePiece.localScale = ((2 * width) - gapboarder) * Vector3.one;

                if ((row == size - 1) && (col == size - 1))
                {
                    emptySpace = (size * size) - 1;
                    puzzlePiece.gameObject.SetActive(false);
                }
            }
        }
    }
}
