using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sidebarscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sideBar;
    public SpriteRenderer sideBarRenderer;
    public TextMeshProUGUI homeText;
    public TextMeshProUGUI AIText;
    public TextMeshProUGUI LessonsText;
    // public Color color;
    // public float speed = 1f;
    // public bool extend = false;
    void Start()
    {
        sideBarRenderer = sideBar.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
        sideBarRenderer.transform.localScale = new Vector3(5f, 10f, 0f);
        homeText.text = "Home";
        AIText.text = "AI";
        LessonsText.text = "Lessons";
    }
    public void OnMouseExit()
    {
        sideBarRenderer.transform.localScale = new Vector3(1f, 10f, 0f);
        homeText.text = "";
        AIText.text = "";
        LessonsText.text = "";
    }
    public void OnMouseDown()
    {
        // if (!extend)
        // {
        //     sideBar.transform.Translate(Vector3.right * speed * Time.deltaTime);
        //     extend = true;
        // }
        // else
        // {
        //     sideBar.transform.Translate(Vector3.right * speed * Time.deltaTime);
        //     extend = false;
        // }
    }
}
