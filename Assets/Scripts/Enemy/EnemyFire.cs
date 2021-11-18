using System.Collections;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private IFireable projectile;
    private float fireInterval;

    public float FireInterval { get => fireInterval; set => fireInterval = value; }

    private void Awake()
    {
        projectile = GetComponent<IFireable>();
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        if (projectile != null)
        {
            while (true)
            {
                yield return new WaitForSeconds(FireInterval);
                projectile.Fire();
            }
        }
    }
}