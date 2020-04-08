using System;
namespace UserRegistration.Models
{
    public enum ConfirmationStatus
    {
        OK = 0,
        ERROR_USER_ALREADY_CONFIRMED,
        ERROR_USER_UNKNOWN,
        ERROR_CONFIRMATION_TIMEOUT
    }
}
