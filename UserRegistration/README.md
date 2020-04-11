# User Registration

### Prerequisites

Insert your mail server credentals in [appsettings.json](https://github.com/brakmic/API-Projects/blob/master/UserRegistration/appsettings.json#L10)

For example, register a free [gmail.com account](http://gmail.com/) and fill in the needed properties.

```json
"EmailSettings": {
    "Domain": "smtp.gmail.com",
    "Port": "587",
    "RegistrarEmail": "youremail@gmail.com",
    "RegistrarName": "Your Display Name in Email",
    "RegistrarPassword": "your_password"
  }
```

### Installation

* At the initial start, go to directory **ClientApp** and install node packages with `npm install`.
* Start the SPA with `npm start`. A development webserver will start listening on https://localhost:5001
* Start the .NET Core backend from your Visual Studio with F5 or right-click on project + "Start Debugging Project".
* Open https://localhost:5001 and follow the below usage tutorial.

**Hint**: As the server generates self-signed certificates you will have to accept them manually.

**Hint 2**: By default, Visual Studio starts its own [Angular Cli](https://cli.angular.io/) instance which is less optimal when doing live coding & debugging.
Therefore, this project has this feature disabled, which is the reason why one has to start Angular manually. But if you prefer the standard behavior, change it [here](https://github.com/brakmic/API-Projects/blob/master/UserRegistration/Startup.cs#L79) and restart your .NET project (and don't forget to close any running Angular instances as well).

----

### Usage

* To create a new account go to Register Account

  Enter new user's `Name` and `E-Mail` there - a confirmation email will be sent to the user
  
![register](https://raw.githubusercontent.com/brakmic/API-Projects/master/UserRegistration/ClientApp/src/assets/img/register_account.png)

* Open the confirmation email and click the link - a registration web form will be opened

![confirm](https://raw.githubusercontent.com/brakmic/API-Projects/master/UserRegistration/ClientApp/src/assets/img/confirmation_email.png)

* Confirm registration by entering your new password (and optionally change the given account name).

![confirm_form](https://raw.githubusercontent.com/brakmic/API-Projects/master/UserRegistration/ClientApp/src/assets/img/confirmation_form.png)

* Finally, a welcome email will be sent.
            
![welcome](https://raw.githubusercontent.com/brakmic/API-Projects/master/UserRegistration/ClientApp/src/assets/img/welcome_email.png)
    
