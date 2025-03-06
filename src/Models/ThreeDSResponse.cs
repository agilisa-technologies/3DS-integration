using System.Text.Json.Serialization;

namespace ThreeDS.Models
{
    public class ThreeDSResponse
    {
        [JsonPropertyName("methodURL")]
        public string MethodURL { get; set; }

        [JsonPropertyName("protocolVersion")]
        public string protocolVersion { get; set; }

        [JsonPropertyName("correlationId")]
        public string correlationId { get; set; }

        [JsonPropertyName("transactionId")]
        public string transactionId { get; set; }

        [JsonPropertyName("threeDSMethodData")]
        public string threeDSMethodData { get; set; }

        [JsonPropertyName("scaIndicator")]
        public bool scaIndicator { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("creq")]
        public string creq { get; set; }

        [JsonPropertyName("authenticationType")]
        public string authenticationType { get; set; }

        [JsonPropertyName("challengeWindowURL")]
        public ChallengeWindowURL challengeWindowURL { get; set; }

        [JsonPropertyName("dsTransId")]
        public string dsTransId { get; set; }

        [JsonPropertyName("acsTransId")]
        public string acsTransId { get; set; }

        [JsonPropertyName("acsURL")]
        public string acsURL { get; set; }

        [JsonPropertyName("transStatusReasonDetail")]
        public string transStatusReasonDetail { get; set; }

        [JsonPropertyName("transStatusReason")]
        public string transStatusReason { get; set; }
    }

    public class ChallengeWindowURL
    {
        [JsonPropertyName("href")]
        public string href { get; set; }

        [JsonPropertyName("rel")]
        public string rel { get; set; }

        [JsonPropertyName("type")]
        public string type { get; set; }
    }
}
