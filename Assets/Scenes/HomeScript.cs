using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool challengelockedstate = true;
    public GameObject locked;
    public SpriteRenderer lockedrenderer;
    public GameObject unlocked;
    public SpriteRenderer unlockedrenderer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lockedrenderer = locked.GetComponent<SpriteRenderer>();
        if (challengelockedstate)
        {
            // lockedrenderer.transform.localScale = new Vector3(-8.7f, 1.2f, -1f);
            // unlockedrenderer.transform.localScale = new Vector3(-9.7f, 1.2f, -1f);
        }
        else
        {
            // unlockedrenderer.transform.localScale = new Vector3(-8.7f, 1.2f, -1f);
            // lockedrenderer.transform.localScale = new Vector3(-9.7f, 1.2f, -1f);
        }
    }

}
