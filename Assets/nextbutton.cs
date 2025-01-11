using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextbutton : MonoBehaviour
{
    public sliderbehaviour data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown(){
        if(data.days < data.open.Count-1){
        data.days += 1;
        data.candup = true;
        }
    }
}
