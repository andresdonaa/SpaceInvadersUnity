using UnityEngine;

internal interface IFireable
{
    Transform SpawnPoint { get; }
    void Fire();
}