using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private Text PlayerHP;
    [SerializeField] private Text PlayerPoints;
    [SerializeField] private Text PlayerClipsBullets;
    [SerializeField] private Image PlayerHPImage;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject ArrowToShow;
    [SerializeField] private GameObject AboutToOutOfBulletMessage;
    [SerializeField] private GameObject OutOfClipsMessage;
    [SerializeField] private GameObject NotEnoughPointsMessage;
    [SerializeField] private GameObject LimitOfClipsMessage;
    [SerializeField] private GameObject PausePanel;

    private HealthController _health;
    private BulletHolder _bullets;
    private GameObject _rechargeDot;
    private bool _isPaused;
    private PlayerInput _pInput;

    private void Start()
    {
        Time.timeScale = 1;

        _health = Player.GetComponent<HealthController>();
        _bullets = Player.GetComponentInChildren<BulletHolder>();
        _pInput = Player.GetComponent<PlayerInput>();

        _bullets.OnAboutToOutOfBullets += HandlerOutOfBullets;
        _bullets.OnRecharged += HandlerRecharged;

        _bullets.OnOutOfClips += HandlerOutOfClips;
        _bullets.OnBuyClip += HandlerBuyClip;

        _bullets.OnFullClip += HandlerFullClip;
        _bullets.OnOutOfMoney += HandlerOutOfMoney;

        _rechargeDot = null;
        _isPaused = false;

        GetParams();
    }

    private void Update()
    {
        GetParams();
        RotateArrowLogic();
        PauseGame();
    }

    private void GetParams()
    {
        PlayerHPImage.fillAmount = _health.CurrentHealth / _health.GetMaxHealth;

        PlayerHP.text = $"HP: {_health.CurrentHealth}";
        PlayerPoints.text = $": {PointCounter.S.CurrentPoints}";
        PlayerClipsBullets.text = $"Clips / Shots : { _bullets.CurrentClipAmount} / {_bullets.ClipCurrentBulletCount}";
    }

    private void HandlerOutOfBullets()
    {
        AboutToOutOfBulletMessage.SetActive(true);
    }

    private void HandlerRecharged()
    {
        AboutToOutOfBulletMessage.SetActive(false);
    }

    private void HandlerOutOfClips()
    {
        OutOfClipsMessage.SetActive(true);
    }

    private void HandlerBuyClip()
    {
        OutOfClipsMessage.SetActive(false);
    }

    private void HandlerFullClip()
    {
        StartCoroutine(FullClipMessage(LimitOfClipsMessage));
    }

    private void HandlerOutOfMoney()
    {
        StartCoroutine(FullClipMessage(NotEnoughPointsMessage));
    }

    private IEnumerator FullClipMessage(GameObject panel)
    {
        panel.SetActive(true);

        yield return new WaitForSeconds(2);

        panel.SetActive(false);
    }    

    private void RotateArrowLogic()
    {
        if(_rechargeDot == null) _rechargeDot = GameObject.FindGameObjectWithTag("RechargeDot");

        if(_rechargeDot != null && Player!= null)
        {
            ArrowToShow.SetActive(true);
            float angle = AngleBetweenTwoPoints(Player.transform.position, _rechargeDot.transform.position);
            ArrowToShow.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));
        }
        else
        {
            ArrowToShow.SetActive(false);
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) => Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;

    private void PauseGame()
    {
        if (_pInput.P)
        {
            _isPaused = !_isPaused;
            _pInput.IsOnControl = !_pInput.IsOnControl;
            
            if (_isPaused)
            {
                Time.timeScale = 0;
                PausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                PausePanel.SetActive(false);
            }
        }
    }
}
