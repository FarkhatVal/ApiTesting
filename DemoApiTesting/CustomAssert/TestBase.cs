using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApiTesting.PostReqresTests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace DemoApiTesting.CustomAssert
{
    public class TestBase
    {
        private static List<string> ErrorMessage;

        [SetUp]
        public void Setup()
        {
            ErrorMessage = new List<string>();  
        }

        [TearDown]
        public void AfterTest()
        {
            Assert.IsEmpty(ErrorMessage, $"Значение не соответсвует ожидаемомупо полям:{ string.Join("\n", ErrorMessage)}");
        }

        protected static void CustomAssertAreEqual(string expected, string actual, string message)
        {
            if (expected != actual) {ErrorMessage.Add(message);}
        }

        protected static void CustomAssertIsNotEmpty(string actual, string message)
        {
            if (String.IsNullOrEmpty(actual)) { ErrorMessage.Add(message); }
        }

        

    }
}