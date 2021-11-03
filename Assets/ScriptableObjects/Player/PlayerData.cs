using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player")]    
public class PlayerData : ScriptableObject
{
    [Range(0.1f, 10f)]
    public float speed = 1f;
    public float health = 100f;
    public AudioClip onDieClip;    
}