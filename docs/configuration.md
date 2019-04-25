# Smtp server settings for email verification

Include the following section in your appsettings.json:

 `  "Smtp":
    {
       "Server": "server-address",
       "Port": 993,
       "From": "noreply@your.server",
       "UseSSL": true
    } `

Or provide this information to the configuration in another way as described [here](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.1).

You can use the following keys:

* Smtp:Server
* Smtp:Port
* Smtp:UseSSL
* Smtp:From