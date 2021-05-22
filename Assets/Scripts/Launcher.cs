using UnityEngine;

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

    private void Update()
    {
        LaunchLogic();
    }

    private void LaunchLogic()
    {
        _launchTimer += Time.deltaTime;

        if (CanLaunch())
        {
            _launcher.Launch(this);
            _launchTimer = 0;
        }
    }

    protected void LaunchLogic(PlayerInput pInput)
    {
        _launchTimer += Time.deltaTime;

        if (CanLaunch() && pInput.MouseLeft)
        {
            _launcher.Launch(this);
            _launchTimer = 0;
        }
    }

    private bool CanLaunch()
    {
        return _launchTimer >= LaunchRate;
    }
}
