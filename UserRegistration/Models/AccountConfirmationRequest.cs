using System;
using Newtonsoft.Json;

namespace UserRegistration.Models
{
    [JsonObject]
    public class AccountConfirmationRequest
    {
        [JsonProperty]
        public string ConfirmationId { get; private set; }
        [JsonProperty]
        public string AccountId { get; private set; }
        [JsonProperty]
        public string Name { get; private set; }
        [JsonProperty]
        public string Email { get; private set; }
        [JsonProperty]
        public string Password { get; private set; }
    }
}
