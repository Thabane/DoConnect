using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoConnectTesting
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod, TestCategory("Smoke")]
        public void When_entering_empty_parameters()
        { 
            DataMan access = new DataMan();
            var result = access.Login(string.Empty, string.Empty);
            Assert.IsTrue(result == false,"Values are empty");
        }

        [TestMethod, TestCategory("Critical")]
        public void When_entering_incorrect_values()
        {
            DataMan access = new DataMan();
            Assert.IsTrue(access.Login("Madam", "Speaker") == false, "Values are incorrect");
        }

        [TestMethod, TestCategory("Smoke")]
        public void When_entering_incorrect_username()
        {
            DataMan access = new DataMan();
            Assert.IsTrue(access.Login("Madam", "12345") == false, "Username is Incorrect");
        }

        [TestMethod, TestCategory("Smoke")]
        public void When_entering_incorrect_password_for_correct_username()
        {
            DataMan access = new DataMan();
            Assert.IsTrue(access.Login("Bongani", "123455") == false, "Password is Incorrect");
        }

        [TestMethod, TestCategory("Critical")]
        public void When_entering_correct_values()
        {
            DataMan access = new DataMan();
            Assert.IsTrue(access.Login("Bongani!", "12345"), "Incorrect values entered.");
        }
        
    }
}
