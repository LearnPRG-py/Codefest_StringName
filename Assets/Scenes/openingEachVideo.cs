using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openingEachVideo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject picture;
    public SpriteRenderer pictureSpriteRenderer;
    void Start()
    {
        pictureSpriteRenderer = picture.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        SceneManager.LoadScene(picture.name);
    }
}
