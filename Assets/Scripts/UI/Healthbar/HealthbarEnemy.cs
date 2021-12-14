using UnityEngine.UI;

public class HealthbarEnemy : HealthbarBase
{
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(float value)
    {
        slider.maxValue = value;        
        slider.value = value;
    }

    public void UpdateHealthbar(float health)
    {
        UpdateHealth(health);
    }
}