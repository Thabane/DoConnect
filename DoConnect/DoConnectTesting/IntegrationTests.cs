using System;
using DataClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoConnectTesting
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void Ping()
        {
            DataClient.Infermedica med = new Infermedica();
            //var userId = dl.CreateUser(1);
            var res = med.GetConditions();
            Assert.IsNotNull(res);
            //Assert.IsTrue(userId > 0, "Valid User Id");
        }
    }
}
