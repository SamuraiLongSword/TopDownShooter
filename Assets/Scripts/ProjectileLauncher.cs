using UnityEngine;

public class ProjectileLauncher : Launcher
{
    [SerializeField] private PlayerInput PlayerInput;

    private void Update()
    {
        base.LaunchLogic(PlayerInput);
    }
}
