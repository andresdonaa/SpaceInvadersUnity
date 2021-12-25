using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player")]    
public class PlayerDataSO : ScriptableObject
{
    [Range(1f, 50f)]
    public float speed = 5f;
    public float health = 100f;
    public AudioClip onDieClip;    
}