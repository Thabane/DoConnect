using System;
using DataClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoConnectTesting
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void GetConditions()
        {
            Infermedica med = new Infermedica();
            var res = med.GetConditions();
            var finalRes = res.Result;
            Assert.IsTrue(!string.IsNullOrEmpty(finalRes));
        }
        [TestMethod]
        public void GetSymptoms()
        {
            Infermedica med = new Infermedica();
            var res = med.GetConditions();
            var finalRes = res.Result;
            Assert.IsTrue(!string.IsNullOrEmpty(finalRes));
        }
        [TestMethod]
        public void GetSymptomById()
        {
            Infermedica med = new Infermedica();
            var res = med.GetSymptomById("s_277");
            var finalRes = res.Result;
            Assert.IsTrue(!string.IsNullOrEmpty(finalRes));
        }
    }
}
