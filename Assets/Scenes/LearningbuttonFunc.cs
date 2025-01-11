using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class Learningbuttonfunc : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Learningbutton;
    public SpriteRenderer LearningbuttonRenderer;
    public GameObject sideBar;
    public SpriteRenderer sideBarRenderer;
    public Color LearningbuttonColor;
    public TextMeshProUGUI homeText;
    public TextMeshProUGUI settingsText;
    public TextMeshProUGUI AIText;
    public TextMeshProUGUI LessonsText;
    void Start()
    {
        LearningbuttonRenderer = Learningbutton.GetComponent<SpriteRenderer>();
        sideBarRenderer = sideBar.GetComponent<SpriteRenderer>();

        LearningbuttonColor = LearningbuttonRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {
        LearningbuttonColor.a = 0.5f;
        LearningbuttonRenderer.color = LearningbuttonColor;
        sideBarRenderer.transform.localScale = new Vector3(5f, 10f, 0f);
        homeText.text = "Home";
        AIText.text = "AI";
        settingsText.text = "Settings";
        LessonsText.text = "Lessons";
    }
    public void OnMouseExit()
    {
        LearningbuttonColor.a = 1f;
        LearningbuttonRenderer.color = LearningbuttonColor;
        sideBarRenderer.transform.localScale = new Vector3(1f, 10f, 0f);
        homeText.text = "";
        AIText.text = "";
        LessonsText.text = "";
        settingsText.text = "";

    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Learn");
    }
}
