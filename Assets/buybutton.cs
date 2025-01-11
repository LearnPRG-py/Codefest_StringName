using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buybutton : MonoBehaviour
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
        if (data.money >(data.close[(int)data.days]+data.open[(int)data.days])/2){
        data.money -= (data.close[(int)data.days]+data.open[(int)data.days])/2;
        data.stocks += 1;
        }
    }
}
