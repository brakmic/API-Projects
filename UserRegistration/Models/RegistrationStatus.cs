using System;
namespace UserRegistration.Models
{
    public enum RegistrationStatus
    {
        OK = 0,
        ACCOUNT_UNKNOWN,
        ACCOUNT_EXPIRED,
        PASSWORD_INVALID,
        EMAIL_CONFIRMATION_SENT,
        EMAIL_REGISTRATION_SENT,
        EMAIL_INVALID,
        EMAIL_ALREADY_REGISTERED,
        REGISTRATION_LINK_INVALID
    }
}
