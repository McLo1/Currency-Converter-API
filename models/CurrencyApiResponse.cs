using System.Text.Json.Serialization;

namespace models
{
    public class CurrencyApiResponse
    {
        public string Base { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }


}