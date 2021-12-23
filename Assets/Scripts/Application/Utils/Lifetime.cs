using UnityEngine;

public class Lifetime : MonoBehaviour
{    
    [Tooltip("Zero for not destroy")]
    [SerializeField] private float timeToLive = 3f;
    
    private void Start()    
    {
        if(timeToLive > 0)
            Destroy(gameObject, timeToLive);
    }
}