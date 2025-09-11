
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject gameOverScreen;
    public GameObject hpSlider;
    private Slider healthValue;
    public GameObject manaSlider;
    private Slider manaValue;
    public bool isPaused = false;
    //public bool playerLost = false;
    void Start()
    {
        healthValue = hpSlider.GetComponent<Slider>();
    }
    void Update()
    {
        //enable pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            mainMenu.SetActive(isPaused);
        }
        OnLose();
    }
    public void OnLose() //enable game over screen
    {
        if (healthValue.value == healthValue.minValue)
        {
            //playerLost = true;
            gameOverScreen.SetActive(true);
        }
    }
    public void OnResumePress() //when resume is pressed on the pause menu
    {
        mainMenu.SetActive(false);
        isPaused = !isPaused;
    }
    public void OnSettingsPress() //when settings is pressed on the pause menu
    {
        settings.SetActive(true);
    }
    public void OnExitPress() //when the x for leave current tab is pressed on the main menu
    {
        settings.SetActive(false);
    }
    public void OnQuitPress() //when quit to menu is pressed on the pause menu
    {
        SceneManager.LoadScene("Main Menu V01");
    }
    public void onPress()
    {
        healthValue.value = healthValue.value - 5f;
    }
}
