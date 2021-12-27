using System;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour, IFireable
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioClip onFireClip;

    public Transform SpawnPoint { get => spawnPoint; }

    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = spawnPoint.up * speed;
        PlayFireSound();
    }

    private void PlayFireSound()
    {
        if (onFireClip != null)
        {
            AudioSource.PlayClipAtPoint(onFireClip, spawnPoint.position);
        }
    }
}