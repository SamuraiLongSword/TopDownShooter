using UnityEngine;

public class Spawner : MonoBehaviour, ILaunch
{
    [SerializeField] private GameObject PrefabToSpawn;

    public void Launch(Launcher launcher)
    {
        Instantiate(PrefabToSpawn, launcher.transform.position, transform.rotation);
    }
}
