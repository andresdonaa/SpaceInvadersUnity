using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarEnemy : HealthbarBase
{
    [SerializeField] private EnemyController enemy;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {    
        if(enemy)
            SetMaxHealth(enemy.enemyData.health);
    }

    public void UpdateHealthbar(float health)
    {
        UpdateHealth(health);
    }    
}