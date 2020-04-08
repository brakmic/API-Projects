using System;
namespace UserRegistration.Models
{
    public class AccountRegistrationResponse
    {
        public AccountRegistrationResponse(string id,
                                           string message,
                                           RegistrationStatus code)
        {
            Id = id;
            Message = message;
            Status = code;
        }
        public string Id { get; private set; }
        public string Message { get; private set; }
        public RegistrationStatus Status { get; private set; }
    }
}
