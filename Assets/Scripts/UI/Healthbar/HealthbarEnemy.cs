using UnityEngine.UI;

public class HealthbarEnemy : HealthbarBase
{
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(float value)
    {
        base.SetMaxHealth(value);
    }

    public void UpdateHealthbar(float health)
    {
        UpdateHealth(health);
    }
}