
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            mainMenu.SetActive(isPaused);
        }
    }
    public void OnResumePress()
    {
        mainMenu.SetActive(false);
    }
    public void OnSettingsPress()
    {
        settings.SetActive(true);
    }
    public void OnExitPress()
    {
        settings.SetActive(false);
    }
    public void OnQuitPress()
    {
        SceneManager.LoadScene("Main Menu V01");
    }
}
