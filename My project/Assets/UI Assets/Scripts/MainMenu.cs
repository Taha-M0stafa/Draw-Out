using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsTab;
    void Start()
    {

    }
    void Update()
    {

    }
    public void OnStartGamePress()
    {

    }
    public void OnSettingsPress()
    {
        settingsTab.SetActive(true);
    }
    public void OnCreditsPress()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnQuitPress()
    {
        Application.Quit();
    }
    public void OnExitPress()
    {
        settingsTab.SetActive(false);
    }
}
