using System;
using UnityEngine;

public class Spawner : MonoBehaviour, ILaunch
{
    [SerializeField] private GameObject PrefabToSpawn;

    public event Action OnSpawn = delegate { };

    public void Launch(Launcher launcher)
    {
        Instantiate(PrefabToSpawn, launcher.transform.position, transform.rotation);
        OnSpawn();
    }
}
