using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

public class getAIworking : MonoBehaviour
{
    
    private string apikey = "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";
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

            var requestBody = new
            {

                model = "asst_HXGuiZpv7rZWc6kgQVYAFTMp",
                messages = new[]
                {
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