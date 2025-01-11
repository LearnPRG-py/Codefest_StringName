using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderbehaviour : MonoBehaviour
{
    public GameObject investmentcontainer;
    public GameObject indicatorcontainer;
    public List<int> open;
    public List<int> close;
    public List<int> high;
    public List<int> low;
    public List<GameObject> candles;
    public GameObject samplecandle;
    // Start is called before the first frame update
    void Start()
    {
        updatecandles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void movecontainer(float x){
        investmentcontainer.transform.position = new Vector3(50-x*investmentcontainer.transform.localScale.x, investmentcontainer.transform.localPosition.y, investmentcontainer.transform.localPosition.z);
        indicatorcontainer.transform.position = new Vector3(50-x*indicatorcontainer.transform.localScale.x, indicatorcontainer.transform.localPosition.y, indicatorcontainer.transform.localPosition.z);
    }
    public void updatecandles(){
        foreach (GameObject can in candles){
            Destroy(can);
        }
        for(int i = 0; i < open.Count; i++){
            GameObject can = Instantiate(samplecandle, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, samplecandle.transform.parent);
            candles[i].transform.localScale = new Vector3(0.0025f, (float)(high[i]-low[i])/300, 1f);
            candles[i].transform.localPosition = new Vector3(0, (float)(high[i]+low[i])/2, 0);
        }
    }
}
