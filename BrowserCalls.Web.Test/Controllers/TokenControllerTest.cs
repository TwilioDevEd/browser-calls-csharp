using BrowserCalls.Web.Controllers;
using BrowserCalls.Web.Domain.Twilio;
using Moq;
using NUnit.Framework;

namespace BrowserCalls.Web.Test.Controllers
{
    public class TokenControllerTest : ControllerTest
    {
        [Test]
        public void GivenATokenRequest_ThenATokenIsGenerated()
        {
            var mockCredentials = new Mock<ICredentials>();

            mockCredentials.Setup(c => c.AccountSID).Returns("Your Twilio Account SID");
            mockCredentials.Setup(c => c.AuthToken).Returns("Your Twilio Auth Token");
            mockCredentials.Setup(c => c.TwiMLApplicationSID).Returns("Your Twilio Phone Number");

            var controller = new TokenController(mockCredentials.Object);
            const string currentPage = "/";
            var result = controller.Generate(currentPage);

            result.ExecuteResult(MockControllerContext.Object);

            string token = (result.Data as dynamic).token;
            Assert.That(token, Is.Not.Null);
        }
    }
}
