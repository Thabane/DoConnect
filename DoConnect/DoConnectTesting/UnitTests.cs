﻿using System;
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
        [TestMethod]
        public void When_entering_empty_parameters()
        { 
            DataMan access = new DataMan();
            Assert.IsTrue(access.Login(string.Empty, string.Empty),"Values are empty");
        }

        [TestMethod]
        public void When_entering_incorrect_values()
        {
            DataMan access = new DataMan();
            Assert.IsTrue(access.Login("Madam", "Speaker"), "Values are incorrect");
        }

        [TestMethod]
        public void When_entering_incorrect_username()
        {
            DataMan access = new DataMan();
            Assert.IsTrue(access.Login("Madam", "12345"), "Username is Incorrect");
        }

        [TestMethod]
        public void When_entering_incorrect_password_for_correct_username()
        {
            DataMan access = new DataMan();
            Assert.IsTrue(access.Login("Bongani", "123455"), "Password is Incorrect");
        }

        [TestMethod]
        public void When_entering_correct_values()
        {
            DataMan access = new DataMan();
            Assert.IsTrue(access.Login("Bongani", "12345"), "Correct values");
        }
    }
}