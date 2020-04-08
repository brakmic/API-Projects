using System;
using Newtonsoft.Json;

namespace UserRegistration.Models
{
    [JsonObject]
    public class EmailRegistrationRequest
    {
        [JsonProperty]
        public string Email { get; private set; }
    }
}
