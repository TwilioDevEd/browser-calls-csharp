using BrowserCalls.Web.Controllers;
using BrowserCalls.Web.Domain.Twilio;
using Moq;
using NUnit.Framework;

// ReSharper disable PossibleNullReferenceException

namespace BrowserCalls.Web.Test.Controllers
{
    public class CallControllerTest : ControllerTest
    {
        [Test]
        public void GivenACallConnectRequest_WhenAPhoneNumberIsPresent_ThenDialsToThatPhoneNumber()
        {
            var mockCredentials = new Mock<ICredentials>();
            const string twilioPhoneNumber = "+13035550142";
            mockCredentials.Setup(c => c.PhoneNumber).Returns(twilioPhoneNumber);
            var controller = new CallController(mockCredentials.Object);
            const string phoneNumber = "+12025550165";
            var result = controller.Connect(phoneNumber);

            result.ExecuteResult(MockControllerContext.Object);
            var document = LoadXml(Result.ToString());

            Assert.That(document.SelectSingleNode("Response/Dial").Attributes["callerId"].Value,
                Is.EqualTo(twilioPhoneNumber));
            Assert.That(document.SelectSingleNode("Response/Dial/Number").InnerText, Is.EqualTo(phoneNumber));
        }

        [Test]
        public void GivenACallConnectRequest_WhenAPhoneNumberIsNotPresent_ThenDialsToClientSupportAgent()
        {
            var controller = new CallController();
            var result = controller.Connect(null);

            result.ExecuteResult(MockControllerContext.Object);
            var document = LoadXml(Result.ToString());

            Assert.That(document.SelectSingleNode("Response/Dial/Client").InnerText, Is.EqualTo("support_agent"));
        }
    }
}
