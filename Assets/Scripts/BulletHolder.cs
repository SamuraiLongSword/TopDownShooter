using UnityEngine;
using UnityEngine.UI;

public class BulletHolder : MonoBehaviour
{
    private int _maxClipAmount; // Max total amount
    private int _currentClipAmount; // Start amount
    private int _pointsForBuyClip; // Points to buy a clip
    private int _clipMaxBulletCount; // Clip amount
    private int _clipCurrentBulletCount; // Current bullets amount
    private bool _canBuy; // If player is in the buying point

    private ProjectileLauncher _pLauncher;
    private PlayerInput _pInput;

    public Text txt;

    private void Awake()
    {
        _maxClipAmount = 10;
        _currentClipAmount = 5;
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

        TMPShowText();
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
    }

    private void Recharge()
    {
        if (_pInput.R && _currentClipAmount > 0)
        {
            _clipCurrentBulletCount = _clipMaxBulletCount;
            _currentClipAmount--;
        }
    }

    private void BuyBullets()
    {
        if (_pInput.Q && PointCounter.S.CurrentPoints >= _pointsForBuyClip && _currentClipAmount < _maxClipAmount && _canBuy)
        {
            _currentClipAmount++;
            PointCounter.S.CurrentPoints -= _pointsForBuyClip;
        }
    }

    private void CanBuy()
    {
        _canBuy = !_canBuy;
    }

    public void TMPShowText()
    {
        txt.text = "Curr: " + _currentClipAmount + "\nClipCur: " + _clipCurrentBulletCount + "\nPoints: " + PointCounter.S.CurrentPoints;
    }
}
