using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject aibutton;
    public SpriteRenderer buttonRenderer;
    public Color buttonColor;
    void Start()
    {
        buttonRenderer = aibutton.GetComponent<SpriteRenderer>();
        buttonColor = buttonRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {
        buttonColor.a = 0.5f;
        buttonRenderer.color = buttonColor;
    }
    public void OnMouseExit()
    {
        buttonColor.a = 1f;
        buttonRenderer.color = buttonColor;
    }
}
