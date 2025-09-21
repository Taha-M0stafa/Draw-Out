using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using spellSystem;
using UnityEngine;
using UnityEngine.UI;

public class ManaManagement : MonoBehaviour
{
    public GameObject manaOrb;
    private Slider manaSlider;
    private float currentMana;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manaSlider = manaOrb.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //ManaRegen();
        Debug.Log(manaSlider.value);
    }
    public float GetMana()
    {
        currentMana = manaSlider.value;
        return currentMana;
    }
    public void UpdateMana(float manaCost)
    {
        manaSlider.value -= manaCost;
    }
    private void ManaRegen()
    {
        float regenAmount = 0.1f;
        if (manaSlider.value < manaSlider.maxValue)
        {
            manaSlider.value += regenAmount;
        }
    }
}
