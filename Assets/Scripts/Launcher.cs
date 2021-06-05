using UnityEngine;

/// <summary>
/// The base logic of shooting, spawning enemies, spawning recharge zones, getting damage, spawning waves
/// Pass an instance of itself to a class that implements the ILaunch interface after established time
/// </summary>
public class Launcher : MonoBehaviour
{
    [SerializeField] private float LaunchRate;

    private ILaunch _launcher;
    private float _launchTimer;

    private void Awake()
    {
        _launcher = GetComponent<ILaunch>();
        _launchTimer = 0;
    }

    private void Update() => LaunchLogic();

    private void LaunchLogic()
    {
        _launchTimer += Time.deltaTime;

        if (CanLaunch())
        {
            _launcher.Launch(this);
            _launchTimer = 0;
        }
    }

    // Reloaded method to implement player shooting
    protected void LaunchLogic(PlayerInput pInput)
    {
        _launchTimer += Time.deltaTime;        

        if (CanLaunch() && pInput.MouseLeft)
        {
            _launcher.Launch(this);
            _launchTimer = 0;
        }
    }

    private bool CanLaunch() => _launchTimer >= LaunchRate;
}
