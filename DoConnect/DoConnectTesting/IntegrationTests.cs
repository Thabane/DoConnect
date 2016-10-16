using System;
using DataClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoConnectTesting
{
    [TestClass]
    public class IntegrationTests
    {
        //NB
        //I am commenting out these tests because they are finishing up our usage quota for the Infermedica API


        //[TestMethod, TestCategory("Specific")]
        //public void GetConditions()
        //{
        //    Infermedica med = new Infermedica();
        //    var res = med.GetConditions();
        //    var finalRes = res.Result;
        //    Assert.IsTrue(!string.IsNullOrEmpty(finalRes));
        //}
        //[TestMethod, TestCategory("Specific")]
        //public void GetSymptoms()
        //{
        //    Infermedica med = new Infermedica();
        //    var res = med.GetSymptoms();
        //    var finalRes = res.Result;
        //    Assert.IsTrue(!string.IsNullOrEmpty(finalRes));
        //}
        //[TestMethod, TestCategory("Smoke")]
        //public void GetSymptomById()
        //{
        //    Infermedica med = new Infermedica();
        //    var res = med.GetSymptomById("s_277");
        //    var finalRes = res.Result;
        //    Assert.IsTrue(!string.IsNullOrEmpty(finalRes));
        //}
    }
}
