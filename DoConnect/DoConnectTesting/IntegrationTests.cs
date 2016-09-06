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
            var res = med.GetConditions();
            Assert.IsNotNull(res);
        }
    }
}
