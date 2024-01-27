using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteList : MonoBehaviour
{
    [SerializeField] private List<GameObject> wavePrefabList;
    [SerializeField] private float wavecooldown;
    [SerializeField] private float currentWaveCooldown;
    [SerializeField] private int wavesLeft;

    private void Update()
    {
        currentWaveCooldown -= Time.deltaTime;

        if (currentWaveCooldown <= 0 && wavesLeft > 0)
        {
            SendWave();
            currentWaveCooldown = wavecooldown;
        }
    }

    void SendWave()
    {
        int randomwave = Random.Range(0, wavePrefabList.Count);
        Instantiate(wavePrefabList[randomwave], this.transform.position, wavePrefabList[randomwave].transform.rotation);
        wavesLeft -= 1;
    } 
}
