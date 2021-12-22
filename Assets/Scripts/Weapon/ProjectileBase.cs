using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField] public float damageAmount = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectileBase otherProjectile = collision.GetComponent<ProjectileBase>();

        if (otherProjectile != null)
        {            
            Destroy(gameObject);
        }
    }
}