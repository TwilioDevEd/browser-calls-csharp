﻿using BrowserCalls.Web.Domain.Twilio;
using Moq;
using NUnit.Framework;

namespace BrowserCalls.Web.Test.Domain.Twilio
{
    public class CapabilityTest
    {
        [TestCase]
        public void GivenAGenerateMethod_WhenAnyRoleIsGiven_ThenACapabilityTokenIsGenerated()
        {
            var mockCredentials = new Mock<ICredentials>();
            mockCredentials.Setup(c => c.AccountSID).Returns("account-sid");
            mockCredentials.Setup(c => c.ApiKey).Returns("api-key");
            mockCredentials.Setup(c => c.ApiSecret).Returns("api-secret");
            mockCredentials.Setup(c => c.TwiMLApplicationSID).Returns("twiml-app-sid");

            var token = new Capability(mockCredentials.Object);

            Assert.That(token, Is.Not.Null);
        }
    }
}
