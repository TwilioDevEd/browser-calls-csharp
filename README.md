# Browser Calls (ASP.NET MVC)

[![Build status](https://ci.appveyor.com/api/projects/status/tiltaaj3tg78i515?svg=true)](https://ci.appveyor.com/project/TwilioDevEd/browser-calls-csharp)

Learn how to use [Twilio Client](https://www.twilio.com/client) to make browser-to-phone and browser-to-browser calls with ease. The unsatisfied customers of the Birchwood Bicycle Polo Co. need your help.

[Read the full tutorial here](https://www.twilio.com/docs/tutorials/walkthrough/browser-calls/csharp/mvc)!

## Quickstart

### Create a TwiML App

This project is configured to use a **TwiML App**, which allows us to easily set the voice URLs for all Twilio phone numbers we purchase in this app.

Create a new TwiML app at https://www.twilio.com/user/account/apps/add and use its `Sid` as the `TWIML_APPLICATION_SID` environment variable wherever you run this app.

![Creating a TwiML App](http://howtodocs.s3.amazonaws.com/call-tracking-twiml-app.gif)

See the end of the "Local development" section for details on the exact URL to use in your TwiML app.

Once you have created your TwiML app, configure your Twilio phone number to use it ([instructions here](https://www.twilio.com/help/faq/twilio-client/how-do-i-create-a-twiml-app)). If you don't have a Twilio phone number yet, you can purchase a new number in your [Twilio Account Dashboard](https://www.twilio.com/user/account/phone-numbers/incoming).

### Local development

1. First clone this repository and `cd` into its directory:
   ```
   git clone git@github.com:TwilioDevEd/browser-calls-csharp.git

   cd browser-calls-csharp
   ```

2. Create a copy of `BrowserCalls.Web/Web.config.sample` and rename it to
   `BrowserCalls.Web/Web.config`.

3. Open `BrowserCalls.Web/Web.config` and update the following keys:
   ```
   <appSettings>
     <!-- omitted for clarity -->
     <add key="TwilioAccountSid" value="TWILIO_ACCOUNT_SID" />
     <add key="TwilioAuthToken" value="TWILIO_AUTH_TOKEN" />
     <add key="TwiMLApplicationSid" value="TWIML_APPLICATION_SID" />
     <add key="TwilioPhoneNumber" value="TWILIO_PHONE_NUMBER" />
   </appSettings>
   ```

4. Build the solution.

5. Run `Update-Database` at [Package Manager
   Console](https://docs.nuget.org/consume/package-manager-console) to execute the migrations.

6. Run the application.

7. Check it out at http://localhost:9932

That's it!

To actually forward incoming calls, your development server will need to be
publicly accessible. [We recommend using ngrok to solve this
problem](https://www.twilio.com/blog/2015/09/6-awesome-reasons-to-use-ngrok-when-testing-webhooks.html).

Once you have started ngrok, update your TwiML app's voice URL setting to use
your ngrok hostname, so it will look something like this:

```
http://<your-ngrok-subdomain>.ngrok.io/Call/Connect
```

## Meta

* No warranty expressed or implied. Software is as is. Diggity.
* [MIT License](http://www.opensource.org/licenses/mit-license.html)
* Lovingly crafted by Twilio Developer Education.
