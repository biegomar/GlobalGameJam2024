using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Archery.Pigeons;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PigeonSpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject PigeonTemplate;
    
    [SerializeField]
    private GameObject LootTemplate;
    
    public IDictionary<int, PigeonItem> Pigeons;
    
    private float WaveTimer;
    private bool IsFirstFormationReleased;
    private bool IsSecondFormationReleased;
    private bool IsThirdFormationReleased;
    private bool IsWaveSpawned;
    
    private Vector2 startPositionLeft;
    private Vector2 startPositionRight;

    private void Start()
    {
        this.InitializeWave();
    }

    private void Update()
    {
        if (!this.IsWaveSpawned)
        {
            this.SpawnWave();
        }
        else
        {
            if (!this.Pigeons.Any())
            {
                GameManager.Instance.archeryCompleted = true;
                if (GameManager.Instance.CanReturnToKing)
                {
                    SceneManager.LoadScene(1);
                }
                SceneManager.LoadScene(8);
            }
        }
    }

    private void InitializeWave()
    {
        this.WaveTimer = 0f;
        
        this.startPositionLeft = new Vector2(-6.5f, 3.5f);
        this.startPositionRight = new Vector2(6.5f, 2.5f);

        this.IsFirstFormationReleased = false;
        this.IsSecondFormationReleased = false;
        this.IsThirdFormationReleased = false;
        this.IsWaveSpawned = false;
        
        this.Pigeons = new Dictionary<int, PigeonItem>();
    }
    
    private void SpawnWave()
    {
        WaveTimer += Time.deltaTime;
        
        if (!this.IsFirstFormationReleased && WaveTimer > 1f && WaveTimer < 1.1f)
        {
            this.SpawnWaveInternal();
            IsFirstFormationReleased = true;
        }
        
        if (!this.IsSecondFormationReleased && WaveTimer > 2f && WaveTimer < 2.1f)
        {
            this.SpawnWaveInternal();
            IsSecondFormationReleased = true;
        }
        
        if (!this.IsThirdFormationReleased && WaveTimer > 3f && WaveTimer < 3.1f)
        {
            this.SpawnWaveInternal();
            this.IsWaveSpawned = true;
        }
    }
    
    private void SpawnWaveInternal()
    {
        var waveId = Guid.NewGuid();
        //var gameObjects = new List<PigeonItem>();
        var distance = 0;
        
        AddLeftFormationItem(waveId, distance);
        AddRightFormationItem(waveId, distance);
        distance += 2;
        
        AddLeftFormationItem(waveId, distance);
        AddRightFormationItem(waveId, distance);
        distance += 2;
        
        AddLeftFormationItem(waveId, distance);
        AddRightFormationItem(waveId, distance);
    }
    
    private void AddLeftFormationItem(Guid waveId, int distance)
    {
        PigeonItem enemyItem = CreateNewEnemyItem(waveId, startPositionLeft, 2 * Vector2.left, distance);
        this.Pigeons.Add(enemyItem.Enemy.GetInstanceID(), enemyItem);
    }

    private void AddRightFormationItem(Guid waveId, int distance)
    {
        PigeonItem enemyItem = CreateNewEnemyItem(waveId, startPositionRight,2 * Vector2.right, distance);
        this.Pigeons.Add(enemyItem.Enemy.GetInstanceID(), enemyItem);
    }
    
    private PigeonItem CreateNewEnemyItem(Guid waveId, Vector2 startPosition, Vector2 lerpCorrector, float distance)
    {
        var startVector = new Vector3(
            startPosition.x,
            startPosition.y - distance,
            0);
        
        var vector = new Vector3(
            startPosition.x + lerpCorrector.x,
            startPosition.y + lerpCorrector.y - distance,
            0);

        return new PigeonItem
        {
            FormationId = waveId,
            Health = 2,
            Enemy = Instantiate(PigeonTemplate, vector, Quaternion.identity),
            StartPosition = startVector
        };
    }
}
