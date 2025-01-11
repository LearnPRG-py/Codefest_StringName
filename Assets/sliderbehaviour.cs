using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sliderbehaviour : MonoBehaviour
{
    public GameObject investmentcontainer;
    public GameObject indicatorcontainer;
    public List<float> open;
    public List<float> close;
    public List<float> high;
    public List<float> low;
    public List<float> HCLopen;
    public List<float> HCLclose;
    public List<float> HCLhigh;
    public List<float> HCLlow;
    public List<float> TSopen;
    public List<float> TSclose;
    public List<float> TShigh;
    public List<float> TSlow;
    public List<float> WIPROopen;
    public List<float> WIPROclose;
    public List<float> WIPROhigh;
    public List<float> WIPROlow;
    private List<float> shareslist;
    private List<float> moneylist;
    private List<float> dayslist;
    public List<GameObject> candles;
    public GameObject samplecandle;
    public float scale = 10f;
    public GameObject previouscandle;
    public float spacing =0.3f;
    private Transform wick;
    public float days;
    public float stocks;
    public float money = 1000f;
    public bool candup;
    public TextMeshProUGUI daystxt;
    public TextMeshProUGUI moneytxt;
    public TextMeshProUGUI sharestxt;
    public float randomset;
    // Start is called before the first frame update
    void Start()
    {
        randomset = (int)UnityEngine.Random.Range(1, 4);
        if (randomset==1){
                    open = HCLopen;
        close = HCLclose;
        high = HCLhigh;
        low = HCLlow;
        }
        else if (randomset==2){
                    open = TSopen;
        close = TSclose;
        high = TShigh;
        low = TSlow;
        }
        else if (randomset==3){
                    open = WIPROopen;
        close = WIPROclose;
        high = WIPROhigh;
        low = WIPROlow;
        }
        
        updatecandles();
    }

    // Update is called once per frame
    void Update()
    {
        if (candup == true){
            updatecandles();
            candup = false;
        }
        daystxt.text = "Days: " + days.ToString();
        moneytxt.text = "Money: " + money.ToString();
        sharestxt.text = "Shares: " + stocks.ToString();
    }
    public void movecontainer(float x){
        investmentcontainer.transform.position = new Vector3(50-x*investmentcontainer.transform.localScale.x, investmentcontainer.transform.localPosition.y, investmentcontainer.transform.localPosition.z);
        indicatorcontainer.transform.position = new Vector3(50-x*indicatorcontainer.transform.localScale.x, indicatorcontainer.transform.localPosition.y, indicatorcontainer.transform.localPosition.z);
    }
    public void updatecandles(){
        foreach (GameObject can in candles){
            Destroy(can);
        }
        previouscandle=samplecandle;
        for(int i = 0; i < days; i++){
            GameObject can = Instantiate(samplecandle, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, samplecandle.transform.parent);
            can.SetActive(true);
            can.transform.localScale = new Vector3(0.0025f, (float)(open[i]-close[i])/(3f*scale), 1f);
            can.transform.position = new Vector3(previouscandle.transform.position.x+spacing, 1f+(float)((open[i]+close[i])-1400f)/(2*scale), 0);
            wick = can.transform.GetChild(0);
            wick.position = new Vector3(can.transform.position.x, 1f+(float)(high[i]+low[i]-1400f)/(2f*scale), 0f);
            wick.localScale = new Vector3(0.2f, (float)(high[i]-low[i])/(3f*scale*can.transform.localScale.y), 1f);
            if (open[i] > close[i]){
                can.GetComponent<SpriteRenderer>().color = Color.red;
                wick.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else{
                can.GetComponent<SpriteRenderer>().color = Color.green;
                wick.GetComponent<SpriteRenderer>().color = Color.green;
            }
            candles.Add(can);
            previouscandle=can;
        }
    }
}
