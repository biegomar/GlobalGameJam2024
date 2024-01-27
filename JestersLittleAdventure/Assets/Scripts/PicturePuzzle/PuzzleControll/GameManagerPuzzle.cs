using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameManagerPuzzle : MonoBehaviour
{

    [SerializeField] private GameObject PrefabPieces;
    [SerializeField] private Vector3 StartPosition;

    private int emptySpace;
    [Header("exclemation factorial number")]
    [SerializeField] private int size = 3;
    //the amount of puzzle pieces is the product of the number of each positive number value below the number
    void Start()
    {
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
                var puzzlePiece = Instantiate(PrefabPieces, StartPosition, Quaternion.identity);

                puzzlePiece.transform.localPosition = new Vector3((2 * width * col) + width,
                                                        (2 * width * row) - width, 0);
                puzzlePiece.transform.localScale = ((2 * width) - gapboarder) * Vector3.one;

                if ((row == size - 1) && (col == size - 1))
                {
                    emptySpace = (size * size) - 1;
                    puzzlePiece.gameObject.SetActive(false);
                }
                else
                {
                   // float gap = gapboarder / 2;
                   // Mesh mesh = puzzlePiece.GetComponent<MeshFilter>().mesh;
                   // Vector2[] coordinate = new Vector2[4];

                   //uv[0] = new Vector2((width*col)+gap, );
                }
            }
        }
    }
}
