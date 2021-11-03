using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthbarBase : MonoBehaviour
{
    protected Slider slider;
    
    protected void UpdateHealth(float value)
    {
        slider.value = value;
    }

    protected void SetMaxHealth(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
}