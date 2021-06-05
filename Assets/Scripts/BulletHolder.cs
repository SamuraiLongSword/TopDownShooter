using System;
using UnityEngine;

/// <summary>
/// Contains all the stuff about the projectiles and the clips
/// </summary>
public class BulletHolder : MonoBehaviour
{
    [SerializeField] private AudioSource AudioBuyClip;
    [SerializeField] private AudioSource AudioReloadClip;
    [SerializeField] private int PointsForBuyClip; // Points to buy a clip
    [SerializeField] private int MaxClipAmount; // Max total clips amount
    [SerializeField] private int currentClipAmount; // Start clips amount
    [SerializeField] private int ClipMaxBulletCount; // The max amount of the bullets in one clip

    private int _clipCurrentBulletCount; // Current bullets amount
    private bool _canBuy; // If player is in the buying area

    public int CurrentClipAmount
    {
        get { return currentClipAmount; }
    }

    public int ClipCurrentBulletCount
    {
        get { return _clipCurrentBulletCount; }
    }

    private ProjectileLauncher _pLauncher;
    private PlayerInput _pInput;

    public event Action OnAboutToOutOfBullets = delegate { };
    public event Action OnRecharged = delegate { };

    public event Action OnOutOfClips = delegate { };
    public event Action OnBuyClip = delegate { };
    public event Action OnFullClip = delegate { };

    public event Action OnOutOfMoney = delegate { };

    private void Awake()
    {
        _clipCurrentBulletCount = ClipMaxBulletCount;
        _canBuy = false;

        GetComponent<Spawner>().OnSpawn += HandlerSpawn;

        _pLauncher = GetComponent<ProjectileLauncher>();
        _pInput = GetComponentInParent<PlayerInput>();
    }

    private void Update()
    {
        CheckOutOfBullets();
        Recharge();
        BuyBullets();
    }

    private void CheckOutOfBullets()
    {
        // Can't fire if the player out of the bullets
        if (_clipCurrentBulletCount == 0)
        {
            _pLauncher.CanFire = false;
        }
        else
        {
            _pLauncher.CanFire = true;
        }
    }

    private void HandlerSpawn()
    {
        // Decrease bullets amount after shoot
        _clipCurrentBulletCount--;

        if(_clipCurrentBulletCount == 10)
        {
            OnAboutToOutOfBullets();
        }
    }

    private void Recharge()
    {
        // Recharge clip logic
        if (_pInput.R && currentClipAmount > 0)
        {
            OnRecharged();

            _clipCurrentBulletCount = ClipMaxBulletCount;
            currentClipAmount--;
            AudioReloadClip.Play();

            if (currentClipAmount == 0) OnOutOfClips();
        }
    }

    private void BuyBullets()
    {
        if (PointCounter.S.CurrentPoints < PointsForBuyClip && _canBuy && _pInput.F) OnOutOfMoney();

        if (_pInput.F && PointCounter.S.CurrentPoints >= PointsForBuyClip && currentClipAmount <= MaxClipAmount && _canBuy)
        {
            if(currentClipAmount == MaxClipAmount)
            {
                OnFullClip();
                return;
            }

            OnBuyClip();
            currentClipAmount++;
            PointCounter.S.CurrentPoints -= PointsForBuyClip;
            AudioBuyClip.Play();
        }
    }

    // This method is calling from the ProjectileLauncher script
    private void CanBuy()
    {
        _canBuy = !_canBuy;
    }
}
