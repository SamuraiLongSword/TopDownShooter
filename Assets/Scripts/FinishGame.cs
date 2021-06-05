using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Finish game stuff
/// </summary>
public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject BossUIStuff;
    [SerializeField] private Image BossHPImage;

    [SerializeField] private Text MaxPoints;

    private HealthController _bossHealth;
    private GameObject _boss;
    private PlayerInput _pInput;

    private void Start()
    {
        _pInput = Player.GetComponent<PlayerInput>();

        Player.GetComponent<HealthController>().OnDie += HandleDie;
        _boss = null;
    }

    private void Update()
    {
        BackToMenu();
        FindBoss();
    }

    private void FindBoss()
    {
        // Find the boss, subscribe OnWin event, output boss's hp
        if(_boss == null)
        {
            _boss = GameObject.FindGameObjectWithTag("Boss");

            if (_boss != null)
            {
                _boss.GetComponent<EnemyForm>().OnWin += HandleWin;
                _bossHealth = _boss.GetComponent<HealthController>();
                BossUIStuff.SetActive(true);
            }
        }
        else
        {
            BossHPImage.fillAmount = _bossHealth.CurrentHealth / _bossHealth.GetMaxHealth;
        }
    }

    private void HandleDie()
    {
        LosePanel.SetActive(true);
    }

    private void HandleWin()
    {
        Player.GetComponent<PlayerInput>().IsOnControl = false;

        StartCoroutine(WinPanelAppear());
    }

    private IEnumerator WinPanelAppear()
    {
        yield return new WaitForSeconds(5);

        WinPanel.SetActive(true);
        int total = PointCounter.S.MaxPoints;
        int cur = PointCounter.S.CurrentPoints;
        int dif = total - cur;
        MaxPoints.text = $"Total money earned: {total}\n(Saved: {cur}/Spent: {dif})";
    }

    // UI button
    public void ToMenu()
    {
        SceneManager.LoadScene("_Start_Scene");
    }

    // UI button
    public void Replay()
    {
        SceneManager.LoadScene("_Level_Scene");
    }

    // Quit to the menu from the game
    private void BackToMenu()
    {
        if (_pInput.M)
        {
            ToMenu();
        }
    }
}
