using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ChallengebuttonFunc : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Challengebutton;
    public SpriteRenderer ChallengebuttonRenderer;
    public Color ChallengebuttonColor;
    public TextMeshProUGUI homeText;
    public TextMeshProUGUI AIText;
    public TextMeshProUGUI challengeText;
    public TextMeshProUGUI settingsText;
    public TextMeshProUGUI LessonsText;
    public GameObject sideBar;
    public SpriteRenderer sideBarRenderer;
    void Start()
    {
        ChallengebuttonRenderer = Challengebutton.GetComponent<SpriteRenderer>();
        ChallengebuttonColor = ChallengebuttonRenderer.color;
        sideBarRenderer = sideBar.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {
        ChallengebuttonColor.a = 0.5f;
        ChallengebuttonRenderer.color = ChallengebuttonColor;
        sideBarRenderer.transform.localScale = new Vector3(6f, 10f, 0f);
        homeText.text = "Home";
        AIText.text = "AI Chatbot";
        settingsText.text = "Settings";
        LessonsText.text = "Lessons";
        challengeText.text = "Challenge";

    }
    public void OnMouseExit()
    {
        ChallengebuttonColor.a = 1f;
        ChallengebuttonRenderer.color = ChallengebuttonColor;
        sideBarRenderer.transform.localScale = new Vector3(1f, 10f, 0f);
        homeText.text = "";
        AIText.text = "";
        LessonsText.text = "";
        challengeText.text = "";
        settingsText.text = "";

    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Practice");
    }
}
