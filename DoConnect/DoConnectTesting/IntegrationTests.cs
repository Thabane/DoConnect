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
            Infermedica med = new Infermedica();
            var res = med.GetConditions();
            var finalRes = res.Result;
            Assert.IsTrue(!string.IsNullOrEmpty(finalRes));
        }
    }
}
