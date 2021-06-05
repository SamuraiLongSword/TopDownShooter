using UnityEngine;

/// <summary>
/// Launching projectile
/// </summary>
public class ProjectileLauncher : Launcher
{
    [SerializeField] private PlayerInput PlayerInput;

    private bool _canFire = true;
    public bool CanFire
    {
        get { return _canFire; }
        set { _canFire = value; }
    }

    private void Update()
    {
        LaunchingMethod();
    }

    private void LaunchingMethod()
    {
        // The launching is available only if there are bullets
        if (CanFire)
        {
            base.LaunchLogic(PlayerInput);
        }
    }
}
