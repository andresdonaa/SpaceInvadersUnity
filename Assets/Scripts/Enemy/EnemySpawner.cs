using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Transform InitialPosition;
    [SerializeField] private EnemyData[] EnemyTypes;

    [SerializeField] private int Rows = 4;
    [SerializeField] private int Columns = 8;

    private float waveStepRight = 1f, spaceColumns = 0.3f, spaceRows = 0.3f;
    private List<EnemyController> spawnedEnemies = new List<EnemyController>();

    private void Awake()
    {
        Spawn();
        SetVariants();
    }

    private void SetVariants()
    {
        foreach (EnemyController enemy in spawnedEnemies)
        {
            enemy.enemyData = EnemyTypes[Random.Range(0, EnemyTypes.Length)];
            enemy.InitData();
            enemy.SetColor();
        }
    }

    private void Spawn()
    {
        for (int r = 0; r < Rows; r++)
        {
            float posY = InitialPosition.position.y - (spaceRows * r);

            for (int c = 0; c < Columns; c++)
            {
                Vector2 objectPosition = new Vector2(InitialPosition.position.x + (spaceColumns * c), posY);
                GameObject go = Instantiate(EnemyPrefab, objectPosition, Quaternion.identity);
                go.transform.SetParent(transform);
                go.name = "Enemy" + (c + 1) + "-Row:" + (r + 1);

                spawnedEnemies.Add(go.GetComponent<EnemyController>());
            }
        }
    }
}