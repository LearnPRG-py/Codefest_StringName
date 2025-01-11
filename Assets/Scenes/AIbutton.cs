using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class AIbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sideBar;
    public SpriteRenderer sideBarRenderer;
    public GameObject aibutton;
    public SpriteRenderer aibuttonRenderer;
    public Color aibuttonColor;
    public TextMeshProUGUI homeText;
    public TextMeshProUGUI settingsText;
    public TextMeshProUGUI AIText;
    public TextMeshProUGUI LessonsText;
    void Start()
    {
        aibuttonRenderer = aibutton.GetComponent<SpriteRenderer>();
        sideBarRenderer = sideBar.GetComponent<SpriteRenderer>();

        sideBarRenderer = sideBar.GetComponent<SpriteRenderer>();
        aibuttonColor = aibuttonRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {
        aibuttonColor.a = 0.5f;
        aibuttonRenderer.color = aibuttonColor;
        sideBarRenderer.transform.localScale = new Vector3(5f, 10f, 0f);
        homeText.text = "Home";
        AIText.text = "AI";
        settingsText.text = "Settings";
        LessonsText.text = "Lessons";
    }
    public void OnMouseExit()
    {
        sideBarRenderer.transform.localScale = new Vector3(1f, 10f, 0f);
        homeText.text = "";
        AIText.text = "";
        LessonsText.text = "";
        settingsText.text = "";

        aibuttonColor.a = 1f;
        aibuttonRenderer.color = aibuttonColor;
    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Chatbot");
    }
}