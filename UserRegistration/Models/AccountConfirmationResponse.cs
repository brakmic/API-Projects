using System;
namespace UserRegistration.Models
{
    public class AccountConfirmationResponse
    {
        public AccountConfirmationResponse(string id,
                                           string message,
                                           ConfirmationStatus code)
        {
            Id = id;
            Message = message;
            Status = code;
        }
        public string Id { get; private set; }
        public string Message { get; private set; }
        public ConfirmationStatus Status { get; private set; }
    }
}
