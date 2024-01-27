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
    // the x and y lenght is changeable on size. (currently not supporting different numbers for now.)
    void Start()
    {
        createPuzzlePiece(0.1f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                //position told by index
                for (int i = 0; i < ?.Count; i++)
                {
                    if (?[i] == hit.transform)
                    {
                        if (SwapIfValid(i, -size, size)) { break; }
                        if (SwapIfValid(i, +size, size)) { break; }
                        if (SwapIfValid(i, -1, 0)) { break; }
                        if (SwapIfValid(i, +1, size - 1)) { break; }
                    }
                }
            }
        }
    }

    private void createPuzzlePiece(float gapboarder)
    {
        float width = 1 / (float)size;
        for (int row = 0; row < size; row++) //row of image piece
        {
            for (int col = 0; col < size; col++) //collumn of image piece
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

            }
        }
    }

    private bool SwapIfValid(int i, int offset, int colCheck)
    {
        if (((i % size) != colCheck) &&((i + offset) == emptySpace))
        {
            (?[i],?[i + offset]) + (?[i + offset], ?[i]);

            //update empty space
            emptySpace = i;
            return true;
        }
        return false;
    }
}
