using UnityEngine;

[CreateAssetMenu(fileName = "GameRules", menuName = "Rules")]
public class GameRules : ScriptableObject
{
    public int lives = 3;

    [Range(1.1f, 5f)]
    public float increaseDifficultyFactor = 1.25f;
}