using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControl : MonoBehaviour
{
    [Header("X Lenght")]
    [SerializeField] int MaxXLenght = 4;

    [Header("Y Lenght")]
    [SerializeField] int MaxYLenght = 4;


    void Start()
    {
        
    }


    void Update()
    {

        for (int y = 0; y < MaxYLenght; y++)
        {
            for (int x = 0; x < MaxXLenght; x++)
            {
                if () { break; }
            }
        }
    }
}
