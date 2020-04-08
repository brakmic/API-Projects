using System;
namespace UserRegistration.Models
{
    public class EmailSettings
    {
        public String Domain { get; set; }

        public int Port { get; set; }

        public String RegistrarEmail { get; set; }

        public String RegistrarName { get; set; }

        public String RegistrarPassword { get; set; }
    }
}
