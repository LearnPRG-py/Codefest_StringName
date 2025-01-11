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
    public float scale = 10f;
    public GameObject previouscandle;
    public float spacing =0.3f;
    private Transform wick;
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
            can.SetActive(true);
            can.transform.localScale = new Vector3(0.0025f, (float)(open[i]-close[i])/(3f*scale), 1f);
            can.transform.position = new Vector3(previouscandle.transform.position.x+spacing, 1f+(float)(open[i]+close[i])/(2*scale), 0);
            wick = can.transform.GetChild(0);
            wick.position = new Vector3(can.transform.position.x, 1f+(float)(high[i]+low[i])/(2f*scale), 0f);
            wick.localScale = new Vector3(0.2f, (float)(high[i]-low[i])/(3f*scale*can.transform.localScale.y), 1f);
            candles.Add(can);
            previouscandle=can;
        }
    }
}
