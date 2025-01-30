using Newtonsoft.Json;

namespace DanAutoPower.Models
{
    public class CarHistory
    
        
    {

            public string Vin { get; set; }
            public string AccidentHistory { get; set; }
            public string ServiceHistory { get; set; }
            public string PreviousOwners { get; set; }
            public string EstimatedValue { get; set; }
        
    }  


        public class CarHistoryService
        {
            private static readonly HttpClient client = new HttpClient();

            public async Task<CarHistory> GetCarHistoryAsync(string vin)
            {
                string apiUrl = $"https://api.example.com/car-history?vin={vin}";
                var response = await client.GetStringAsync(apiUrl);
                return JsonConvert.DeserializeObject<CarHistory>(response);
            }
        }

    
}
