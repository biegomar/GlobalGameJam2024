using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private static readonly object lockObject = new object();
    private static GameManager instance = null;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new GameManager();
                    }
                }
            }
            return instance;
        }
    }
}
