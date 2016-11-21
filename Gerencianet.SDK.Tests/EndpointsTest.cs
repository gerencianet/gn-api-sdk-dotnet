using NUnit.Framework;

namespace Gerencianet.SDK.Tests
{
    [TestFixture]
    public class EndpointsTest
    {

        private dynamic gerencianet;

        [SetUp]
        public void Init()
        {
            this.gerencianet = new Endpoints("", "", true);
            this.gerencianet.PartnerToken = "my_partner_token";
        }

        [Test]
        public void TryInvokeMemberTest()
        {
            try
            {
                this.gerencianet.CreateCharge();
            }
            catch(GnException e)
            {
                Assert.IsFalse(e.ErrorType.Equals("invalid_endpoint"), "Endpoints instance should have a method named CreateCharge");
            }

            try
            {
                this.gerencianet.Charge();
                Assert.Fail("Endpoints instance should not have a method named 'Charge'");
            }
            catch (GnException e)
            {
                Assert.IsTrue(e.ErrorType.Equals("invalid_endpoint"), "Endpoints instance should not have a method named 'Charge'");
            }
        }
        
    }
}
