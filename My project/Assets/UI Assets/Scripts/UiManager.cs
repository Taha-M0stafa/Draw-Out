using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
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
    public GameObject tint1;
    public GameObject tint2;
    public GameObject tint3;
    public GameObject tint4;

    public GameObject cooldownTime;
    public bool isPaused = false;
    public bool ability1Ready = true;
    public bool ability1Used = false;
    public bool ability2Ready = true;
    public bool ability2Used = false;
    public bool ability3Ready = true;
    public bool ability3Used = false;
    public bool ability4Ready = true;
    public bool ability4Used = false;

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
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        //enable game-over screen
        OnLose();
    }
    public void OnLose() //enable game over screen
    {
        if (healthValue.value == healthValue.minValue)
        {
            //playerLost = true;
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
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
    public IEnumerator Ability1Cooldown() //cooldown management
    {
        float maxTime = 3f; //three seconds cd
        float elapsedTime = 0;
        while (elapsedTime < maxTime)
        {
            tint1.GetComponent<Image>().fillAmount = Mathf.Lerp(1, 0, elapsedTime / maxTime); //maxTime - elapsed time = text
            elapsedTime += Time.deltaTime;
            //float displayedTime = maxTime - elapsedTime;
            //cooldownTime.GetComponent<TextMeshPro>().text = displayedTime.ToString();
            yield return null;

        }
        tint1.SetActive(false);
        //cooldownTime.SetActive(false);
        ability1Ready = true;
    }
    public IEnumerator Ability2Cooldown() //cooldown management
    {
        float maxTime = 3f; //three seconds cd
        float elapsedTime = 0;
        while (elapsedTime < maxTime)
        {
            tint2.GetComponent<Image>().fillAmount = Mathf.Lerp(1, 0, elapsedTime / maxTime); //maxTime - elapsed time = text
            elapsedTime += Time.deltaTime;
            //float displayedTime = maxTime - elapsedTime;
            //cooldownTime.GetComponent<TextMeshPro>().text = displayedTime.ToString();
            yield return null;

        }
        tint2.SetActive(false);
        //cooldownTime.SetActive(false);
        ability2Ready = true;
    }
    public IEnumerator Ability3Cooldown() //cooldown management
    {
        float maxTime = 3f; //three seconds cd
        float elapsedTime = 0;
        while (elapsedTime < maxTime)
        {
            tint3.GetComponent<Image>().fillAmount = Mathf.Lerp(1, 0, elapsedTime / maxTime); //maxTime - elapsed time = text
            elapsedTime += Time.deltaTime;
            //float displayedTime = maxTime - elapsedTime;
            //cooldownTime.GetComponent<TextMeshPro>().text = displayedTime.ToString();
            yield return null;

        }
        tint3.SetActive(false);
        //cooldownTime.SetActive(false);
        ability3Ready = true;
    }
    public IEnumerator Ability4Cooldown() //cooldown management
    {
        float maxTime = 3f; //three seconds cd
        float elapsedTime = 0;
        while (elapsedTime < maxTime)
        {
            tint4.GetComponent<Image>().fillAmount = Mathf.Lerp(1, 0, elapsedTime / maxTime); //maxTime - elapsed time = text
            elapsedTime += Time.deltaTime;
            //float displayedTime = maxTime - elapsedTime;
            //cooldownTime.GetComponent<TextMeshPro>().text = displayedTime.ToString();
            yield return null;

        }
        tint4.SetActive(false);
        //cooldownTime.SetActive(false);
        ability4Ready = true;
    }

    public void Ability1Usage()
    {
        if (ability1Ready)
        {
            tint1.SetActive(true);
            //cooldownTime.SetActive(true);
            ability1Ready = false;
            tint1.GetComponent<Image>().fillAmount = 1f;
            StartCoroutine(Ability1Cooldown());
        }
    }
    public void Ability2Usage()
    {
        if (ability2Ready)
        {
            tint2.SetActive(true);
            //cooldownTime.SetActive(true);
            ability2Ready = false;
            tint2.GetComponent<Image>().fillAmount = 1f;
            StartCoroutine(Ability2Cooldown());
        }
    }
    public void Ability3Usage()
    {
        if (ability3Ready)
        {
            tint3.SetActive(true);
            //cooldownTime.SetActive(true);
            ability3Ready = false;
            tint3.GetComponent<Image>().fillAmount = 1f;
            StartCoroutine(Ability3Cooldown());
        }
    }
        public void Ability4Usage()
    {
        if (ability4Ready)
        {
            tint4.SetActive(true);
            //cooldownTime.SetActive(true);
            ability4Ready = false;
            tint4.GetComponent<Image>().fillAmount = 1f;
            StartCoroutine(Ability4Cooldown());
        }
    }
}
