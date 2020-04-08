using System;
using System.Threading.Tasks;

namespace UserRegistration.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string subject, string content, string recipient);
        void Send(string subject, string content, string recipient);
    }
}
