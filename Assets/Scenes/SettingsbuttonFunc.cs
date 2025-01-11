using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class SettingsbuttonFunc : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Settingsbutton;
    public SpriteRenderer SettingsbuttonRenderer;
    public Color SettingsbuttonColor;
    public TextMeshProUGUI homeText;
    public TextMeshProUGUI AIText;
    public TextMeshProUGUI settingsText;
    public TextMeshProUGUI LessonsText;
    public GameObject sideBar;
    public SpriteRenderer sideBarRenderer;
    void Start()
    {
        SettingsbuttonRenderer = Settingsbutton.GetComponent<SpriteRenderer>();
        SettingsbuttonColor = SettingsbuttonRenderer.color;
        sideBarRenderer = sideBar.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {
        SettingsbuttonColor.a = 0.5f;
        SettingsbuttonRenderer.color = SettingsbuttonColor;
        sideBarRenderer.transform.localScale = new Vector3(5f, 10f, 0f);
        homeText.text = "Home";
        AIText.text = "AI";
        settingsText.text = "Settings";
        LessonsText.text = "Lessons";
    }
    public void OnMouseExit()
    {
        SettingsbuttonColor.a = 1f;
        SettingsbuttonRenderer.color = SettingsbuttonColor;
        sideBarRenderer.transform.localScale = new Vector3(1f, 10f, 0f);
        homeText.text = "";
        AIText.text = "";
        LessonsText.text = "";
        settingsText.text = "";

    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Settings");
    }
}
