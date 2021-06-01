using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject Player;

    [SerializeField] private Text MaxPoints;

    private GameObject _boss;

    private void Start()
    {
        Player.GetComponent<HealthController>().OnDie += HandleDie;
        _boss = null;
    }

    private void Update()
    {
        _boss = GameObject.FindGameObjectWithTag("Boss");

        if (_boss != null)
        {
            _boss.GetComponent<EnemyForm>().OnWin += HandleWin;
        }
    }

    private void HandleDie()
    {
        LosePanel.SetActive(true);
    }

    private void HandleWin()
    {
        Player.GetComponent<PlayerInput>().IsOnControl = false;
        WinPanel.SetActive(true);
        int total = PointCounter.S.MaxPoints;
        int cur = PointCounter.S.CurrentPoints;
        int dif = total - cur;
        MaxPoints.text = $"Total money earned: {total}\n(Save: {cur}/Spent: {dif})";
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("_Start_Scene");
    }

    public void Replay()
    {
        SceneManager.LoadScene("_Level_Scene");
    }
}
