using System;
using System.Text.Json.Serialization;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests.Models
{
    public class ApplicationData
    {
        [JsonPropertyName("applicant_id")]
        public int applicant_id { get; set; }

        [JsonPropertyName("user_id")]
        public int user_id { get; set; }

        [JsonPropertyName("phone_number")]
        public string phone_number { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("linkedin")]
        public string LinkedIn { get; set; }

        public string Github { get; set; }

        public string HomePage { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }

}
