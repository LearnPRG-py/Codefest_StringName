using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidebarscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sideBar;
    public SpriteRenderer sideBarRenderer;
    public Color color;
    public float speed = 1f;
    public bool extend = false;
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
        Debug.Log("OnMouseOver ");
        sideBarRenderer.transform.localScale = new Vector3(2f, 0f, 0f);
    }
    public void OnMouseExit()
    {

    }
    public void OnMouseDown()
    {
        if (!extend)
        {
            sideBar.transform.Translate(Vector3.right * speed * Time.deltaTime);
            extend = true;
        }
        else
        {
            sideBar.transform.Translate(Vector3.right * speed * Time.deltaTime);
            extend = false;
        }
    }
}
