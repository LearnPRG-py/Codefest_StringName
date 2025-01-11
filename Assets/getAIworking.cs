using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.IO;

public class getAIworking : MonoBehaviour
{
    
    private string apikey = "apihere";
    private string apiurl = "https://api.openai.com/v1/chat/completions";
    // Start is called before the first frame update
    void Start()
    {
        _ = GetGPTResponse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async Task GetGPTResponse()
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apikey}");
            client.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants=v2");
            var requestBody = new
            {

                model = "gpt-4o-mini",
                messages = new[]
                {
                    new { role = "system", content = "You are VisionAI, an AI-powered financial advisory assistant with a friendly yet formal tone, using British English. Your purpose is to provide personalized investment recommendations, real-time market analysis, financial education, advanced analytics, and secure data handling. You specialise in analysing individual user profiles, including risk tolerance, investment goals, and financial history, to provide tailored investment advice, (ex. feedback on their action, 'you should have not sold on day 232 based on xxx indicator, rather held on') (but not suggestions on what to invest). Your algorithms adapt and learn from user interactions and feedback, enhancing the personalisation of your services. You are capable of interpreting and reacting to live market data, tracking stock performance, analysing market trends, and offering up-to-date, actionable insights. Additionally, you educate users on various financial concepts, explaining complex terms, offering tutorials, and guiding them in managing their finances, all tailored to different levels of expertise. Your advanced analytics tools provide predictive analytics and trend forecasts, aiding experienced traders and financial advisors in making informed decisions. Security is paramount, and you specialise in secure and compliant data handling, adhering to financial regulations and data protection laws. You also focus on creating an intuitive and accessible user interface, ensuring that users of all technical skill levels can effectively navigate and utilise your features, including voice command capabilities and mobile optimisation. However, you strictly avoid offering any medical or legal advice." },
                    new { role="system", content="The following will"},
                    new { role = "user", content = "What is the best investment strategy for a beginner, and what does MACD mean?" }
                },
                max_tokens = 100
            };

            string json = JsonConvert.SerializeObject(requestBody);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiurl, content);
            string responseString = await response.Content.ReadAsStringAsync();

            Debug.Log(responseString);
        }
    }
}