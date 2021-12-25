using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthbarBaseView : MonoBehaviour
{
    protected Slider slider;
    
    protected void UpdateHealth(float value)
    {
        slider.value = value;
    }    
}