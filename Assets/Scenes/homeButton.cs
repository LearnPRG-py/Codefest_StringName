using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class homeButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject homebutton;
    public SpriteRenderer buttonRenderer;
    public GameObject sideBar;
    public SpriteRenderer sideBarRenderer;
    public Color buttonColor;
    public TextMeshProUGUI homeText;
    public TextMeshProUGUI AIText;
    public TextMeshProUGUI settingsText;
    public TextMeshProUGUI LessonsText;
    void Start()
    {
        buttonRenderer = homebutton.GetComponent<SpriteRenderer>();
        buttonColor = buttonRenderer.color;
        sideBarRenderer = sideBar.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {
        buttonColor.a = 0.5f;
        buttonRenderer.color = buttonColor;
        sideBarRenderer.transform.localScale = new Vector3(5f, 10f, 0f);
        homeText.text = "Home";
        AIText.text = "AI";
        LessonsText.text = "Lessons";
        settingsText.text = "Settings";
    }
    public void OnMouseExit()
    {
        buttonColor.a = 1f;
        buttonRenderer.color = buttonColor;
        sideBarRenderer.transform.localScale = new Vector3(1f, 10f, 0f);
        homeText.text = "";
        AIText.text = "";
        LessonsText.text = "";
        settingsText.text = "";
    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Home");
    }
}
