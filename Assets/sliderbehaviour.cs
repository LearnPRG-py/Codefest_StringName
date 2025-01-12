using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Scripting.Python;

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
    public List<float> ROC;
    public List<float> SMA;
    public List<GameObject> candles;
    public GameObject samplecandle;
    public float scale = 10f;
    public GameObject previouscandle;
    public float spacing =0.3f;
    private Transform wick;
    public float days = 30f;
    public float stocks;
    public float money = 1000f;
    public bool candup;
    public TextMeshProUGUI daystxt;
    public TextMeshProUGUI moneytxt;
    public TextMeshProUGUI sharestxt;
    public float randomset;
    public LineRenderer indicatorchart;
    public LineRenderer indicatorchart2;
    public LineRenderer indicatorchart3;
    public LineRenderer indicatorchart4;
    public LineRenderer indicatorchart5;
    public GameObject indicatorplotter;
    public GameObject indicatorplotter2;
    public GameObject indicatorplotter3;
    public GameObject indicatorplotter4;
    public GameObject indicatorplotter5;
    public GameObject buttonbuyE;
    public GameObject buttonsellE;
    public GameObject buttonbuyH;
    public GameObject buttonsellH;
    public GameObject next;
    public GameObject sidebar;
    public GameObject Home;
    public GameObject chat;
    public GameObject learning;
    public GameObject settings;
    public GameObject challenge;
    public GameObject locked;
    public GameObject unlocked;
    public float sum14;
    public float HH9;
    public float LL9;
    public float HH26;
    public float LL26;
    public float HH52;
    public float LL52;
    public List<float> tks;
    public List<float> kjs;
    public List<float> senA;
    public List<float> senB;
    public List<float> chikou;
    // Start is called before the first frame update
    void Start()
    {
        randomset = (int)UnityEngine.Random.Range(1, 4);
        open = HCLopen;
        close = HCLclose;
        high = HCLhigh;
        low = HCLlow;
        
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
        transform.position = new Vector3(100f*x, transform.position.y, transform.position.z);
        buttonbuyE.transform.position = new Vector3(-3.5f+100f*x, buttonbuyE.transform.position.y, buttonbuyE.transform.position.z);
        buttonsellE.transform.position = new Vector3(-6f+100f*x, buttonsellE.transform.position.y, buttonsellE.transform.position.z);
        buttonbuyH.transform.position = new Vector3(-3.5f+100f*x, buttonbuyH.transform.position.y, buttonbuyH.transform.position.z);
        buttonsellH.transform.position = new Vector3(-6f+100f*x, buttonsellH.transform.position.y, buttonsellH.transform.position.z);
        next.transform.position = new Vector3(-1f+100f*x, next.transform.position.y, next.transform.position.z);
        sidebar.transform.position = new Vector3(-8.5f+100f*x, sidebar.transform.position.y, sidebar.transform.position.z);
        Home.transform.position = new Vector3(-8.45f+100f*x, Home.transform.position.y, Home.transform.position.z);
        chat.transform.position = new Vector3(-8.4f+100f*x, chat.transform.position.y, chat.transform.position.z);
        learning.transform.position = new Vector3(-8.4f+100f*x, learning.transform.position.y, learning.transform.position.z);
        settings.transform.position = new Vector3(-8.45f+100f*x, settings.transform.position.y, settings.transform.position.z);
        challenge.transform.position = new Vector3(-8.45f+100f*x, challenge.transform.position.y, challenge.transform.position.z);
        locked.transform.position = new Vector3(-8.7f+100f*x, locked.transform.position.y, locked.transform.position.z);
        unlocked.transform.position = new Vector3(-9.5f+100f*x, unlocked.transform.position.y, unlocked.transform.position.z);
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
            can.transform.position = new Vector3(previouscandle.transform.position.x+spacing, 1f+(float)((open[i]+close[i])-1400f)/(2f*scale), 0);
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
        calculatesum14();
        HH90();
        LL90();
        HH260();
        LL260();
        HH520();
        LL520();

        PythonRunner.RunFile("Assets/ROC Indicator.py");
        PythonRunner.RunFile("Assets/SMA Indicator.py");
        PythonRunner.RunFile("Assets/ichimokucloud.py");
        drawindicator();
    }
    public void calculatesum14(){
        int sum = 0;
        for (int i = (int)(days); i > (int)(days-14f); i--){
            sum += (int)(close[i]);
        }
        sum14=(float)sum;
    }
    public void HH90(){
        float HH = 0f;
        for (int i = (int)(days); i > (int)(days-9f); i--){
            if (high[i] > HH){
                HH = high[i];
            }
        }
        HH9 = HH;
    }
    public void LL90(){
        float LL = 1000000000000000000000f;
        for (int i = (int)(days); i > (int)(days-9f); i--){
            if (low[i] < LL){
                LL = low[i];
            }
        }
        LL9 = LL;
    }
    public void HH260(){
        float HH = 0f;
        for (int i = (int)(days); i > (int)(days-26f); i--){
            if (high[i] > HH){
                HH = high[i];
            }
        }
        HH26 = HH;
    }
    public void LL260(){
        float LL = 1000000000000000000000f;
        for (int i = (int)(days); i > (int)(days-26f); i--){
            if (low[i] < LL){
                LL = low[i];
            }
        }
        LL26 = LL;
    }
    public void HH520(){
        float HH = 0f;
        for (int i = (int)(days); i > (int)(days-52f); i--){
            if (high[i] > HH){
                HH = high[i];
            }
        }
        HH52 = HH;
    }
    public void LL520(){
        float LL = 1000000000000000000000f;
        for (int i = (int)(days); i > (int)(days-52f); i--){
            if (low[i] < LL){
                LL = low[i];
            }
        }
        LL52 = LL;
    }
    public void drawindicator(){
        List<Vector3> indipoints = new List<Vector3>();
        List<Vector3> indipoints2 = new List<Vector3>();
        List<Vector3> indipoints3 = new List<Vector3>();
        List<Vector3> indipoints4 = new List<Vector3>();
        List<Vector3> indipoints5 = new List<Vector3>();
        // for (int i = 0; i < ROC.Count; i++){
        //     indipoints.Add((new Vector3(9f+spacing*i, -1f+(float)(ROC[i])/10f, -5f)));
        // }
        // for (int i = 0; i < SMA.Count; i++){
        //     indipoints.Add((new Vector3(18.6f+spacing*i, -2f+(float)(SMA[i])/800f, -5f)));
        // }
        for (int i = 0; i < tks.Count; i++){
            indipoints.Add((new Vector3(18.6f+spacing*i, 1f+(float)((tks[i])-700f)/(2f*scale), -5f)));
        }
        for (int i = 0; i < kjs.Count; i++){
            indipoints2.Add((new Vector3(18.6f+spacing*i, 1f+(float)((kjs[i])-700f)/(2f*scale), -5f)));
        }
        for (int i = 0; i < senA.Count; i++){
            indipoints3.Add((new Vector3(18.6f+spacing*i, 1f+(float)((senA[i])-700f)/(2f*scale), -5f)));
        }
        for (int i = 0; i < senB.Count; i++){
            indipoints4.Add((new Vector3(18.6f+spacing*i, 1f+(float)((senB[i])-700f)/(2f*scale), -5f)));
        }
        for (int i = 0; i < chikou.Count; i++){
            indipoints5.Add((new Vector3(18.6f+spacing*i, 1f+(float)((chikou[i])-700f)/(2f*scale), -5f)));
        }
        indicatorchart.positionCount = indipoints.Count;
        indicatorchart.startWidth = 0.01f;
        indicatorchart.endWidth = 0.01f;
        indicatorchart.SetPositions(indipoints.ToArray());
        indicatorchart.startColor = Color.red;
        indicatorchart.endColor = Color.red;
        indicatorchart2.positionCount = indipoints2.Count;
        indicatorchart2.startWidth = 0.01f;
        indicatorchart2.endWidth = 0.01f;
        indicatorchart2.SetPositions(indipoints2.ToArray());
        indicatorchart2.startColor = Color.red;
        indicatorchart.endColor = Color.red;
        indicatorchart3.positionCount = indipoints3.Count;
        indicatorchart3.startWidth = 0.01f;
        indicatorchart3.endWidth = 0.01f;
        indicatorchart3.SetPositions(indipoints3.ToArray());
        indicatorchart3.startColor = Color.red;
        indicatorchart.endColor = Color.red;
        indicatorchart4.positionCount = indipoints2.Count;
        indicatorchart4.startWidth = 0.01f;
        indicatorchart4.endWidth = 0.01f;
        indicatorchart4.SetPositions(indipoints2.ToArray());
        indicatorchart4.startColor = Color.red;
        indicatorchart.endColor = Color.red;
        indicatorchart5.positionCount = indipoints3.Count;
        indicatorchart5.startWidth = 0.01f;
        indicatorchart5.endWidth = 0.01f;
        indicatorchart5.SetPositions(indipoints3.ToArray());
        indicatorchart5.startColor = Color.red;
        indicatorchart.endColor = Color.red;

    }
}
