using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    //private RectTransform text;
    //public float scrollSpeed = 170f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //text = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
    public void OnExitPress()
    {
        SceneManager.LoadScene("Main Menu V01");
    }
}
