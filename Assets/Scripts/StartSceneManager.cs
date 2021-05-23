using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene("_Level_Scene");

    public void QuiteGame() => Application.Quit();
}
