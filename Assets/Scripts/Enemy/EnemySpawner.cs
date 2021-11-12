using Scripts.Events;
using SuperMaxim.Messaging;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform initialPosition;
    [SerializeField] private EnemyData[] enemyTypes;

    [SerializeField] private int rows = 4;
    [SerializeField] private int columns = 8;

    private float waveStepRight = 1f, spaceColumns = 1.5f, spaceRows = 1.5f;
    private List<EnemyController> spawnedEnemies = new List<EnemyController>();
    private int totalEnemiesCount = 0;

    private void Awake()
    {
        Messenger.Default.Subscribe<EnemyDestroyEvent>(OnEnemyDestroy);
        Spawn();
        SetVariants();
    }

    private void OnEnemyDestroy(EnemyDestroyEvent enemyDestroyEvent)
    {
        totalEnemiesCount--;

        if(totalEnemiesCount <= 0)
            Messenger.Default.Publish(new GameOverEvent());
    }

    private void SetVariants()
    {
        foreach (EnemyController enemy in spawnedEnemies)
        {
            enemy.enemyData = enemyTypes[Random.Range(0, enemyTypes.Length)];
            enemy.InitData();
            enemy.SetColor();
        }
    }

    private void Spawn()
    {
        for (int r = 0; r < rows; r++)
        {
            float posY = initialPosition.position.y - (spaceRows * r);

            for (int c = 0; c < columns; c++)
            {
                Vector2 objectPosition = new Vector2(initialPosition.position.x + (spaceColumns * c), posY);
                GameObject go = Instantiate(enemyPrefab, objectPosition, Quaternion.identity);
                go.transform.SetParent(transform);
                go.name = "Enemy" + (c + 1) + "-Row:" + (r + 1);

                spawnedEnemies.Add(go.GetComponent<EnemyController>());
            }
        }

        totalEnemiesCount = spawnedEnemies.Count;
    }
}