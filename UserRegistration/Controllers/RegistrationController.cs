using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Interfaces;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IEmailService emailService;
        private IWebHostEnvironment webEnv;
        private string webRoot = "";

        public RegistrationController(IEmailService emailService, IWebHostEnvironment env)
        {
            this.emailService = emailService;
            webEnv = env;
            webRoot = webEnv.WebRootPath;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<AccountRegistrationResponse> Register([FromBody] AccountRegistrationRequest request)
        {
            return await Task.Run(async () =>
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return new AccountRegistrationResponse(
                        Guid.NewGuid().ToString(),
                        "Email invalid.",
                        RegistrationStatus.EMAIL_INVALID
                    );
                }
                else
                {
                    try
                    {
                        var confirmationId = Guid.NewGuid().ToString(); // dummy
                        var content = GetConfirmationEmail(request, confirmationId);
                        await emailService.SendAsync("Registration", content, request.Email);
                        return new AccountRegistrationResponse(
                            Guid.NewGuid().ToString(),
                            "Registration email sent.",
                            RegistrationStatus.EMAIL_REGISTRATION_SENT
                        );
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            });
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<AccountConfirmationResponse> Confirm([FromBody] AccountConfirmationRequest request)
        {
            return await Task.Run(async () =>
            {
                var content = GetWelcomeEmail(request);
                await emailService.SendAsync("Welcome", content, request.Email);
                return new AccountConfirmationResponse(
                    Guid.NewGuid().ToString(),
                    "Account created.",
                    ConfirmationStatus.OK
                );
            });
        }

        // TODO - replace these two functions with a more intelligent logic
        private string GetConfirmationEmail(AccountRegistrationRequest request, string confirmationId)
        {
            var contentFile = webRoot +
                                      Path.DirectorySeparatorChar.ToString() +
                                      "templates" +
                                      Path.DirectorySeparatorChar.ToString() +
                                      "ConfirmAccount.html";
            var content = System.IO.File.ReadAllText(contentFile);
            return content.Replace("#AccountId", request.AccountId)
                          .Replace("#ConfirmationId", confirmationId)
                          .Replace("#Name", request.Name)
                          .Replace("#Email", request.Email);
        }

        private string GetWelcomeEmail(AccountConfirmationRequest request)
        {
            var contentFile = webRoot +
                                      Path.DirectorySeparatorChar.ToString() +
                                      "templates" +
                                      Path.DirectorySeparatorChar.ToString() +
                                      "WelcomeEmail.html";
            var content = System.IO.File.ReadAllText(contentFile);
            return content.Replace("#Name", request.Name)
                          .Replace("#AccountId", request.AccountId);
        }
    }
}