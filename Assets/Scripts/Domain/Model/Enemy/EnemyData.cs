using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public float health = 100f;

    public int score = 10;

    [Range(0.1f, 10f)]
    public float fireInterval = 1f;

    public ConsoleColor color;

    public AudioClip onDieClip;
}