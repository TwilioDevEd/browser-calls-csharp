<a  href="https://www.twilio.com">
<img  src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg"  alt="Twilio"  width="250"  />
</a>

# Browser Calls (ASP.NET MVC)

![](https://github.com/TwilioDevEd/browser-calls-csharp/workflows/NetFx/badge.svg)
[![Build status](https://ci.appveyor.com/api/projects/status/tiltaaj3tg78i515?svg=true)](https://ci.appveyor.com/project/TwilioDevEd/browser-calls-csharp)

> We are currently in the process of updating this sample template. If you are encountering any issues with the sample, please open an issue at [github.com/twilio-labs/code-exchange/issues](https://github.com/twilio-labs/code-exchange/issues) and we'll try to help you.

## About

Learn how to use [Twilio Client](https://www.twilio.com/client) to make browser-to-phone and browser-to-browser calls with ease. The unsatisfied customers of the Birchwood Bicycle Polo Co. need your help.

[Read the full tutorial here](https://www.twilio.com/docs/tutorials/walkthrough/browser-calls/csharp/mvc)!

Implementations in other languages:

| PHP | Java | Python | Ruby | Node |
| :--- | :--- | :----- | :-- | :--- |
| [Done](https://github.com/TwilioDevEd/browser-calls-laravel)  | [Done](https://github.com/TwilioDevEd/browser-calls-spark)  | [Done](https://github.com/TwilioDevEd/browser-calls-django)  | [Done](https://github.com/TwilioDevEd/browser-calls-rails) | [Done](https://github.com/TwilioDevEd/browser-calls-node)  |

<!--
### How it works

**TODO: Describe how it works**
-->

## Set up

### Requirements

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- A Twilio account - [sign up](https://www.twilio.com/try-twilio)
- [ngrok](https://ngrok.com)

### Create a TwiML App

This project is configured to use a **TwiML App**, which allows us to easily set the voice URLs for all Twilio phone numbers we purchase in this app.

Create a new TwiML app and save its `Sid`. You will need it to setup your app settings.
  
  Using the [twilio-cli](https://www.twilio.com/docs/twilio-cli) ?
  ```
  twilio api:core:applications:create --friendly-name browser-calls --voice-url [your-app-url]
  ```

  If not you can do it at https://www.twilio.com/console/voice/twiml/apps/create
  See the end of the "Local development" section for details on the exact URL to use in your TwiML app.

Once you have created your TwiML app, configure your Twilio phone number to use it ([instructions here](https://support.twilio.com/hc/en-us/articles/223180928-How-Do-I-Create-a-TwiML-App-)).
If you don't have a Twilio phone number yet, you can purchase a new number in the [Twilio Console](https://www.twilio.com/console/phone-numbers/incoming).

### Twilio Account Settings

This application should give you a ready-made starting point for writing your
own application. Before we begin, we need to collect
all the config values we need to run the application:

| Config&nbsp;Value | Description                                                                                                                                                  |
| :---------------- | :----------------------------------------------------------------------------------------------------------------------------------------------------------- |
`TwilioAccountSid` | Your primary Twilio account identifier - find this [in the console here](https://www.twilio.com/console).
`TwilioTwimlAppSid` | The TwiML application with a voice URL configured to access your server running this app - create one [in the console here](https://www.twilio.com/console/voice/twiml/apps). Also, you will need to configure the Voice "REQUEST URL" on the TwiML app once you've got your server up and running.
`TwilioCallerId` | A Twilio phone number in [E.164 format](https://en.wikipedia.org/wiki/E.164) - you can [get one here](https://www.twilio.com/console/phone-numbers/incoming)
`TwilioApiKey` / `TwilioApiSecret` | Your REST API Key information needed to create an [Access Token](https://www.twilio.com/docs/iam/access-tokens) - create [one here](https://www.twilio.com/console/project/api-keys).

### Local development

After the above requirements have been met:

1. Clone this repository and `cd` into it

```bash
git clone git@github.com:TwilioDevEd/browser-calls-csharp.git
cd browser-calls-csharp
```

2. Set your configuration variables

```bash
cd BrowserCalls.Web
copy Web.config.sample Web.config
```

See [Twilio Account Settings](#twilio-account-settings) to locate the necessary environment variables.

3. Build the solution

4. Run `Update-Database` at [Package Manager Console](https://docs.nuget.org/consume/package-manager-console) to execute the migrations.

5. Run the application

6. Run ngrok (or use the [ngrok Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=DavidProthero.NgrokExtensions))

```bash
ngrok http -host-header="localhost:9932" 9932
```

> [Learn 6 awesome reasons why to use ngrok](https://www.twilio.com/blog/2015/09/6-awesome-reasons-to-use-ngrok-when-testing-webhooks.html).

7. Once you have started ngrok, update your TwiML app's voice URL setting to use your ngrok hostname, so it will look something like this:

```
https://<your-ngrok-subdomain>.ngrok.io/Call/Connect
```

If you make changes to your ASP.NET application and restart it, there is no need to restart the ngrok tunnel. Leaving it running will avoid getting a new ngrok subdomain and requiring you to update your TwiML app's voice URL.

> **Note:** You must set your webhook urls to the `https` ngrok tunnel created.

That's it!

### Try it out

1. To create a support ticket go to the home page.
   On this page you could fill some fields and create a ticket or you can call to support.

   ```
   https://<your-ngrok-subdomain>.ngrok.io
   ```

   __Note:__ Make sure you use the `https` version of your ngrok URL as some
   browsers won't allow access to the microphone unless you are using a secure
   SSL connection.

2. To respond to support tickets go to the Dashboard page (you should open two windows or tabs).
   On this page you could call customers and answers phone calls.

   ```
   https://<your-ngrok-subdomain>.ngrok.io/Dashboard

## Resources

- The CodeExchange repository can be found [here](https://github.com/twilio-labs/code-exchange/).

## Contributing

This template is open source and welcomes contributions. All contributions are subject to our [Code of Conduct](https://github.com/twilio-labs/.github/blob/master/CODE_OF_CONDUCT.md).

[Visit the project on GitHub](https://github.com/twilio-labs/sample-template-dotnet)

## License

[MIT](http://www.opensource.org/licenses/mit-license.html)

## Disclaimer

No warranty expressed or implied. Software is as is.

[twilio]: https://www.twilio.com
