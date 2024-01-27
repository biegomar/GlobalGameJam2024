using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteList : MonoBehaviour
{
    [SerializeField] private List<int> notePositionList;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject endNotePrefab;

    void Start()
    {
        for (int i = 0; i < notePositionList.Count; i++)
        {
            if(i == notePositionList.Count - 1)
            {
                Vector2 position = new Vector2(notePositionList[i], this.transform.position.y);
                Instantiate(endNotePrefab, position, endNotePrefab.transform.rotation);
            }
            else
            {
                Vector2 position = new Vector2(notePositionList[i], this.transform.position.y);
                Instantiate(notePrefab, position, notePrefab.transform.rotation);
            }
        }
    }
}
