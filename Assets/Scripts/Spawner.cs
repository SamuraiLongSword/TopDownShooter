using System;
using UnityEngine;

public class Spawner : MonoBehaviour, ILaunch
{
    [SerializeField] private GameObject PrefabToSpawn;
    [SerializeField] private AudioSource SpawnSound;

    public event Action OnSpawn = delegate { };

    public void Launch(Launcher launcher)
    {
        Instantiate(PrefabToSpawn, launcher.transform.position, transform.rotation);
        if (SpawnSound != null) SpawnSound.Play();
        OnSpawn();
    }
}
