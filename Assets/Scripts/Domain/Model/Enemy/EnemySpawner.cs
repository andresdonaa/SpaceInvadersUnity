using Scripts.Events;
using SuperMaxim.Messaging;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemiesConfiguration))]
public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Setup")]
    [SerializeField] private Transform initialPosition;
    [SerializeField] private EnemiesConfiguration enemiesConfiguration;
    [SerializeField] private int rows = 4;
    [SerializeField] private int columns = 8;

    private float spaceColumns = 1.5f, spaceRows = 1.25f;    
    private int totalEnemiesCount = 0;

    private List<EnemyController> spawnedEnemies;
    private EnemyFactory enemyFactory;

    private void Awake()
    {
        Messenger.Default.Subscribe<EnemyDestroyEvent>(OnEnemyDestroy);
        spawnedEnemies = new List<EnemyController>();
        enemyFactory = new EnemyFactory(enemiesConfiguration);
        Spawn();
        enemiesConfiguration.SetVariants(spawnedEnemies);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<EnemyDestroyEvent>(OnEnemyDestroy);
    }

    private void OnEnemyDestroy(EnemyDestroyEvent enemyDestroyEvent)
    {
        totalEnemiesCount--;
        
        if (totalEnemiesCount <= 0)
            Invoke(nameof(Respawn), 1f);
    }

    private void Respawn()
    {
        Messenger.Default.Publish(new WaveRespawnEvent());

        spawnedEnemies = new List<EnemyController>();
        Spawn();
        enemiesConfiguration.SetVariants(spawnedEnemies);
    }

    private void Spawn()
    {
        for (int r = 0; r < rows; r++)
        {
            float posY = initialPosition.position.y - (spaceRows * r);

            for (int c = 0; c < columns; c++)
            {
                Vector2 objectPosition = new Vector2(initialPosition.position.x + (spaceColumns * c), posY);
                GameObject enemyGO = enemyFactory.Create(objectPosition, Quaternion.identity);
                enemyGO.transform.SetParent(transform);
                spawnedEnemies.Add(enemyGO.GetComponent<EnemyController>());
            }
        }

        totalEnemiesCount = spawnedEnemies.Count;
    }
}