using NUnit.Framework;
using System;

namespace Gerencianet.Tests
{
    [TestFixture]
    public class EndpointsTest
    {

        private dynamic gerencianet;

        [SetUp]
        public void Init()
        {
            this.gerencianet = new Endpoints("", "", true);
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

        [Test]
        public void AuthenticateTest()
        {
            try {
                this.gerencianet.createCharge();
            }
            catch (GnException e)
            {
                Assert.IsTrue(e.ErrorType.Equals("authorization_error"), "");
            }

            try
            {
                this.gerencianet.createCharge();
            }
            catch (GnException e)
            {
                Assert.IsTrue(e.ErrorType.Equals("authorization_error"), "");
            }
        }

    }
}
