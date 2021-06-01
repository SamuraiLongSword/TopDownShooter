using System;
using UnityEngine;

public class BulletHolder : MonoBehaviour
{
    [SerializeField] private AudioSource AudioBuyClip;
    [SerializeField] private AudioSource AudioReloadClip;

    private int _maxClipAmount; // Max total amount
    private int _currentClipAmount; // Start amount
    private int _pointsForBuyClip; // Points to buy a clip
    private int _clipMaxBulletCount; // Clip amount
    private int _clipCurrentBulletCount; // Current bullets amount
    private bool _canBuy; // If player is in the buying point

    public int CurrentClipAmount
    {
        get { return _currentClipAmount; }
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

    private void Awake()
    {
        _maxClipAmount = 5;
        _currentClipAmount = 3;
        _pointsForBuyClip = 750;
        _clipMaxBulletCount = 100;
        _clipCurrentBulletCount = _clipMaxBulletCount;
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
        _clipCurrentBulletCount--;

        if(_clipCurrentBulletCount == 10)
        {
            OnAboutToOutOfBullets();
        }
    }

    private void Recharge()
    {
        if (_pInput.R && _currentClipAmount > 0)
        {
            OnRecharged();

            _clipCurrentBulletCount = _clipMaxBulletCount;
            _currentClipAmount--;
            AudioReloadClip.Play();

            if (_currentClipAmount == 0) OnOutOfClips();
        }
    }

    private void BuyBullets()
    {
        if (_pInput.F && PointCounter.S.CurrentPoints >= _pointsForBuyClip && _currentClipAmount < _maxClipAmount && _canBuy)
        {
            OnBuyClip();
            _currentClipAmount++;
            PointCounter.S.CurrentPoints -= _pointsForBuyClip;
            AudioBuyClip.Play();
        }
    }

    private void CanBuy()
    {
        _canBuy = !_canBuy;
    }
}
