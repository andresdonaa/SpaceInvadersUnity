using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings")]
public class GameSettings : ScriptableObject
{
    public int lives = 3;

    [Range(1.1f, 5f)]
    public float increaseDifficultyFactor = 1.25f;
}